using CheckEVMBalance.Models;
using Nethereum.Util;
using Nethereum.Web3;
using System.Numerics;
using System.Text;

namespace CheckEVMBalance
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        static async Task<decimal> GetBalanceAsync(string network, string address)
        {
            Web3 web3 = new(network);
            var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
            return Web3.Convert.FromWei(balance.Value);
        }

        static async Task<BigDecimal> GetContractBalanceAsync(string network, string contractAddress, string address)
        {
            Web3 web3 = new(network);
            var balanceOfFunctionMessage = new BalanceOfFunction() { Owner = address };
            var handler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
            var contractBalance = await handler.QueryAsync<BigInteger>(contractAddress, balanceOfFunctionMessage);
            return Web3.Convert.FromWeiToBigDecimal(contractBalance);
        }

        private async void ButtonCheck_Click(object sender, EventArgs e)
        {
            var addressList = rtbAddress.Text.Split(new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            var rpcAddress = txtRPC.Text.Trim();
            var contractAddress = txtContract.Text.Trim();

            var results = new List<(string Address, BigDecimal Balance)>(addressList.Count);

            if (!string.IsNullOrWhiteSpace(rpcAddress) && addressList.Count > 0)
            {
                rtbOutput.Clear();
                if (string.IsNullOrWhiteSpace(contractAddress))
                {
                    await Task.WhenAll(addressList.Select(async address =>
                    {
                        try
                        {
                            var balance = await GetBalanceAsync(rpcAddress, address);
                            lock (results)
                            { results.Add((address, balance)); }
                        }
                        catch (Exception)
                        {
                            lock (results)
                            { results.Add((address, -1)); }
                        }
                    }));
                }
                else
                {
                    await Task.WhenAll(addressList.Select(async address =>
                    {
                        try
                        {
                            var balance = await GetContractBalanceAsync(rpcAddress, contractAddress, address);
                            lock (results)
                            { results.Add((address, balance)); }
                        }
                        catch (Exception)
                        {
                            lock (results)
                            { results.Add((address, -1)); }
                        }
                    }));
                }

                var sortedResults = results.OrderBy(r => addressList.IndexOf(r.Address));

                var resultText = new StringBuilder();
                foreach (var (Address, Balance) in sortedResults)
                {
                    var miniAddress = Address[..6] + "…" + Address[^4..];
                    var humanBalance = Balance >= 0 ? string.Format("{0:#,0.######}", Balance) : "Error";
                    resultText.AppendLine($"{miniAddress}|{humanBalance}");
                }
                rtbOutput.Text = resultText.ToString();
            }
        }
    }
}