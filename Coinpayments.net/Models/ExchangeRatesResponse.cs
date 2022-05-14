using System.Runtime.Serialization;

namespace Coinpayments.NET.Models
{
    public class ExchangeRatesResponse : ResponseModelFoundation<Dictionary<string, ExchangeRatesResponse.Item>>
    {
        [DataContract]
        public class Item
        {
            /// <summary>
            /// If the coin is a fiat currency
            /// </summary>
            [DataMember(Name = "is_fiat")]
            public bool IsFiat { get; set; }
            /// <summary>
            /// The exchange rate to Bitcoin.
            /// </summary>
            [DataMember(Name = "rate_btc")]
            public decimal RateBtc { get; set; }
            public DateTime? LastUpdate
            { get { return Utils.TimestampConverter(LastUpdateUnix); } }
            /// <summary>
            /// Transaction fee.
            /// </summary>
            [DataMember(Name = "tx_fee")]
            public decimal TxFee { get; set; }
            /// <summary>
            /// Cloud wallet/network status
            /// </summary>
            [DataMember(Name = "status")]
            public string? Status { get; set; }
            [DataMember(Name = "image")]
            public string? ImageUrl { get; set; }
            /// <summary>
            /// The coin's full/display name.
            /// </summary>
            [DataMember(Name = "name")]
            public string? Name { get; set; }
            /// <summary>
            /// The number of confirms a coin has to have in our system before we send it to you.
            /// </summary>
            [DataMember(Name = "confirms")]
            public int Confirms { get; set; }
            /// <summary>
            /// The 'capabilities' field for each coin will have 0 or more than one value. Check <see href="https://www.coinpayments.net/apidoc-rates">https://www.coinpayments.net/apidoc-rates</see>
            /// </summary>
            [DataMember(Name = "capabilities")]
            public string[]? Capabilities { get; set; }
            /// <summary>
            /// Chain name
            /// </summary>
            [DataMember(Name = "chain")]
            public string? ChainName { get; set; }
            /// <summary>
            /// Contract Address
            /// </summary>
            [DataMember(Name = "contract")]
            public string? ContractAddress { get; set; }
            /// <summary>
            /// Link to block explorer
            /// </summary>
            [DataMember(Name = "explorer")]
            public string? ExplorerUrl { get; set; }
            /// <summary>
            /// True if you have enabled for acceptance on your Coin Acceptance Settings page
            /// </summary>
            [DataMember(Name = "accepted")]
            public bool Accepted { get; set; }
            /// <summary>
            /// You can convert to/from this currency using the 'convert' API.
            /// </summary>
            [DataMember(Name = "can_convert")]
            public bool CanConvert { get; set; }
            [DataMember(Name = "last_update")]
            private string? LastUpdateUnix
            {
                get;
                set;
            }
        }
    }
}
