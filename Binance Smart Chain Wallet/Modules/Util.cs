using Nethereum.Util;

namespace Binance_Smart_Chain_Wallet.Modules
{
    internal class Util
    {
        private static readonly AddressUtil _addressUtil = new();

        internal static bool IsValidAddress(string address)
        {
            return _addressUtil.IsValidEthereumAddressHexFormat(address)
                && _addressUtil.IsChecksumAddress(address);
        }
        internal static bool IsValidAddressHexFormat(string address)
        {
            return _addressUtil.IsValidEthereumAddressHexFormat(address);
        }
    }
}