using Binance_Smart_Chain_Wallet.Models;
using NBitcoin;

namespace Binance_Smart_Chain_Wallet.Modules
{
    internal class Wallet
    {
        internal static Nethereum.HdWallet.Wallet CreateNewWallet()
        {
            Nethereum.HdWallet.Wallet newWallet = new(Wordlist.English, WordCount.Twelve);
            return newWallet;
        }

        internal static Nethereum.HdWallet.Wallet RecoverWallet(string words)
        {
            Nethereum.HdWallet.Wallet recoverWallet = new(words, null);
            return recoverWallet;
        }

        internal static WalletDetail GetDetail(Nethereum.HdWallet.Wallet wallet)
        {
            var account = wallet.GetAccount(0);
            return new WalletDetail()
            {
                PrivateKey = account.PrivateKey,
                Address = account.Address,
                SeedWords = string.Join(" ", wallet.Words)
            };
        }
    }
}