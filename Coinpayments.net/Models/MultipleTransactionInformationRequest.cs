using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.NET.Models
{
    [DataContract]
    public class MultipleTransactionInformationRequest
    {
        public MultipleTransactionInformationRequest()
        { Cmd = "get_tx_info_multi"; }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        /// <summary>
        /// The Coinpayments transaction ID to query
        /// </summary>
        [DataMember(Name = "txid")]
        public string? TxnId { get; set; }
    }
}
