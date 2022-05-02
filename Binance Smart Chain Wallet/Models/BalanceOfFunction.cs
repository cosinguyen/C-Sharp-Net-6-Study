using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace Binance_Smart_Chain_Wallet.Models
{
    [Function("balanceOf", "uint256")]
    public class BalanceOfFunction : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public string? Owner { get; set; }
    }
}
