using System.Runtime.Serialization;

namespace Coinpayments.NET.Models
{
    public class GetCallbackAddressRespone : ResponseModelFoundation<GetCallbackAddressRespone.Item>
    {
        [DataContract]
        public class Item
        {
            /// <summary>
            /// The address to deposit the selected coin into your CoinPayments Wallet.
            /// </summary>
            [DataMember(Name = "address")]
            public string? Address { get; set; }
            /// <summary>
            /// NXT Only: The pubkey to attach the 1st time you send to the address to activate it.
            /// </summary>
            [DataMember(Name = "pubkey")]
            public string? Pubkey { get; set; }
            /// <summary>
            /// For coins needing a destination tag, payment ID, etc. (like Ripple or Monero) to set for depositing into your CoinPayments Wallet.
            /// </summary>
            [DataMember(Name = "dest_tag")]
            public long DestTag { get; set; }
            /// <summary>
            /// Optional alternate representation of an address such as X-address format for Ripple or legacy V-prefix for Velas EVM.
            /// </summary>
            [DataMember(Name = "alt_address")]
            public string? AltAddress { get; set; }
        }
    }
}