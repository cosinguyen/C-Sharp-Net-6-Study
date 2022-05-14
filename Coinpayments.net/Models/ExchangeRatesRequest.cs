using System.Runtime.Serialization;

namespace Coinpayments.NET.Models
{
    [DataContract]
    public class ExchangeRatesRequest
    {
        public ExchangeRatesRequest()
        { Cmd = "rates"; }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        [DataMember(Name = "short")]
        public int Short { get; set; }
        [DataMember(Name = "accepted")]
        public int Accepted { get; set; }

    }
}
