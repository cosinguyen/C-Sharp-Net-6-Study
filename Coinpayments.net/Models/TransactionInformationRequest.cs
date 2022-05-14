using System.Runtime.Serialization;

namespace Coinpayments.NET.Models
{
    [DataContract]
    public class TransactionInformationRequest
    {
        public TransactionInformationRequest()
        { Cmd = "get_tx_info"; }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        /// <summary>
        /// The Coinpayments transaction ID to query
        /// </summary>
        [DataMember(Name = "txid")]
        public string? TxnId { get; set; }
        /// <summary>
        /// Set to 1 to also include the raw checkout and shipping data for the payment if available. 
        /// </summary>
        [DataMember(Name = "full")]
        public int IsFull { get; set; }
    }
}