using Binance_Smart_Chain_Wallet.Models;
using Binance_Smart_Chain_Wallet.Modules;
using Nethereum.Web3;
using Newtonsoft.Json;
using System.Numerics;

namespace Binance_Smart_Chain_Wallet
{
    public partial class MainForm : Form
    {
        private readonly string _password = "CQzo5uzEeTK6";
        private string _usdtContractAddress = string.Empty;
        private string _network = string.Empty;
        public MainForm()
        {
            InitializeComponent();
            cbbNetwork.SelectedIndex = 1;
        }

        internal static string? OpenDialog(string title, string filter = "Lacosi files|*.lacosi")
        {
            OpenFileDialog theDialog = new()
            {
                Title = title.ToString(),
                Filter = filter
            };
            DialogResult result = theDialog.ShowDialog();
            if (result == DialogResult.OK) return theDialog.FileName.ToString();
            else return null;
        }
        internal static string? SaveDialog(string title, string filter = "Lacosi files|*.lacosi")
        {
            SaveFileDialog theDialog = new()
            {
                Title = title.ToString(),
                Filter = filter
            };
            DialogResult result = theDialog.ShowDialog();
            if (result == DialogResult.OK) return theDialog.FileName.ToString();
            else return null;
        }

        private async void SaveMainWallet_ClickAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMainAddress.Text) && !string.IsNullOrWhiteSpace(txtMainPrivateKey.Text))
            {
                string? path = SaveDialog("Save Main Wallet");
                var mainWallet = new { publickey = txtMainAddress.Text, privatekey = txtMainPrivateKey.Text };
                string json = JsonConvert.SerializeObject(mainWallet);
                if (path != null)
                {
                    await Encryption.FileEncryptAsync(path, _password, json);
                    MessageBox.Show("Lưu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            { MessageBox.Show("Không được để trống Địa chỉ ví hoặc Private Key", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void LoadMainWallet_Click(object sender, EventArgs e)
        {
            string? path = OpenDialog("Import Main Wallet");
            if (path != null)
            {
                string line = await Encryption.FileDecryptAsync(path, _password);
                dynamic? results = JsonConvert.DeserializeObject<dynamic>(line);
                if (results != null)
                {
                    txtMainAddress.Text = results.publickey;
                    txtMainPrivateKey.Text = results.privatekey;
                }
            }
        }

        private async void CheckMainBalance_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMainAddress.Text) && !string.IsNullOrWhiteSpace(txtMainPrivateKey.Text) && _network != string.Empty)
            {

                Web3 web3 = new(_network);
                var balance = await web3.Eth.GetBalance.SendRequestAsync(txtMainAddress.Text);
                var bnbAmount = Web3.Convert.FromWei(balance.Value);

                var balanceOfFunctionMessage = new BalanceOfFunction() { Owner = txtMainAddress.Text };
                var handler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
                var contractBalance = await handler.QueryAsync<BigInteger>(_usdtContractAddress, balanceOfFunctionMessage);
                var contractAmount = Web3.Convert.FromWeiToBigDecimal(contractBalance);

                lblMainBNB.Text = string.Format("{0:#,0.######}", bnbAmount) + " BNB";
                lblMainUSDT.Text = string.Format("{0:#,0.######}", contractAmount) + " USDT";
            }
            else
            { MessageBox.Show("Không được để trống Địa chỉ ví, Private Key và RPC (Web3) Url", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Network_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox cbb)
            {
                if ((string)cbb.SelectedItem == "MainNet")
                {
                    _usdtContractAddress = "0x55d398326f99059ff775485246999027b3197955";
                    _network = "https://bsc-dataseed1.binance.org:443";
                }
                else if ((string)cbb.SelectedItem == "TestNet")
                {
                    //Use LINK token instead of USDT
                    //LINK TOKEN https://faucets.chain.link/chapel, get alot of LINK token for testnet
                    //LINK BEP20 testnet contract address: 0x84b9b910527ad5c03a9ca831909e21e236ea7b06
                    //USDT BEP20 testnet contract address: 0x337610d27c682E347C9cD60BD4b3b107C9d34dDd
                    _usdtContractAddress = "0x84b9b910527ad5c03a9ca831909e21e236ea7b06";
                    _network = "https://data-seed-prebsc-1-s1.binance.org:8545";
                }
            }
        }
    }
}