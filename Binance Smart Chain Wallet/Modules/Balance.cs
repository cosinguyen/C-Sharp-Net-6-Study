using Binance_Smart_Chain_Wallet.Models;
using Nethereum.Util;
using Nethereum.Web3;
using System.Numerics;

namespace Binance_Smart_Chain_Wallet.Modules
{
    internal class Balance
    {
        internal static async Task<decimal> GetBalanceAsync(string network, string address)
        {
            Web3 web3 = new(network);
            var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
            return Web3.Convert.FromWei(balance.Value);
        }
        internal static async Task<BigDecimal> GetContractBalanceAsync(string network, string contractAddress, string address)
        {
            Web3 web3 = new(network);
            var balanceOfFunctionMessage = new BalanceOfFunction() { Owner = address };
            var handler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
            var contractBalance = await handler.QueryAsync<BigInteger>(contractAddress, balanceOfFunctionMessage);
            return Web3.Convert.FromWeiToBigDecimal(contractBalance);
        }
        internal static async Task<decimal> GetMaximumAmountCanSendAsync(string network, string address, int gasPrice, ulong gasAmount)
        {
            var currentBalance = await GetBalanceAsync(network, address);
            var pricePerGas = Web3.Convert.FromWei(gasPrice, UnitConversion.EthUnit.Gwei);
            return currentBalance - (pricePerGas * gasAmount);
        }
        internal static async Task<BigDecimal> GetMaximumTokenAmountCanSendAsync(string network, string contractAddress, string address)
        {
            return await GetContractBalanceAsync(network, contractAddress, address);
        }
    }
}