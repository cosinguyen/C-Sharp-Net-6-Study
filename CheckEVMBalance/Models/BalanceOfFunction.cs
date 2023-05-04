using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace CheckEVMBalance.Models
{
    [Function("balanceOf", "uint256")]
    public class BalanceOfFunction : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public string? Owner { get; set; }
    }
}