using System.Runtime.Serialization;

namespace Coinpayments.NET.Models
{
    public class CreateTransactionResponse : ResponseModelFoundation<CreateTransactionResponse.Item>
    {
        [DataContract]
        public class Item
        {
            /// <summary>
            /// The amount for the buyer to send in the destination currency (currency2).
            /// </summary>
            [DataMember(Name = "amount")]
            public decimal Amount { get; set; }
            /// <summary>
            /// The address the buyer needs to send the coins to.
            /// </summary>
            [DataMember(Name = "address")]
            public string? Address { get; set; }
            /// <summary>
            /// Optional alternate representation of an address such as X-address format for Ripple or legacy V-prefix for Velas EVM.
            /// </summary>
            [DataMember(Name = "alt_address")]
            public string? AltAddress { get; set; }
            /// <summary>
            /// The tag buyers need to attach for the payment to complete. (only included for coins that require them such as XRP/XMR/etc.)
            /// </summary>
            [DataMember(Name = "dest_tag")]
            public string? DestTag { get; set; }
            /// <summary>
            /// The CoinPayments.net transaction ID.
            /// </summary>
            [DataMember(Name = "txn_id")]
            public string? TxnId { get; set; }
            /// <summary>
            /// The number of confirms needed for the transaction to be complete.
            /// </summary>
            [DataMember(Name = "confirms_needed")]
            public int ConfirmsNeeded { get; set; }
            /// <summary>
            /// How long the buyer has to send the coins and have them be confirmed in seconds.
            /// </summary>
            [DataMember(Name = "timeout")]
            public int Timeout { get; set; }
            /// <summary>
            /// While normally you would be designing the full checkout experience on your site you can use this URL to provide the final payment page to the buyer.
            /// </summary>
            [DataMember(Name = "checkout_url")]
            public string? CheckOutUrl { get; set; }
            /// <summary>
            /// A longer-term URL where the buyer can view the payment status and leave feedback for you.
            /// </summary>
            [DataMember(Name = "status_url")]
            public string? StatusUrl { get; set; }
            /// <summary>
            /// A URL to a QR code you can display for buyer's paying with a QR supporting wallet.
            /// </summary>
            [DataMember(Name = "qrcode_url")]
            public string? QRCodeUrl { get; set; }
        }
    }
}
