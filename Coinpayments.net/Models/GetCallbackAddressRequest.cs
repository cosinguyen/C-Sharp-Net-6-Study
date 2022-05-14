using System.Runtime.Serialization;

namespace Coinpayments.NET.Models
{
    [DataContract]
    public class GetCallbackAddressRequest
    {
        public GetCallbackAddressRequest()
        { Cmd = "get_callback_address"; }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        [DataMember(Name = "currency")]
        public string? Currency { get; set; }
        [DataMember(Name = "ipn_url")]
        public string? IpnUrl { get; set; }
        [DataMember(Name = "label")]
        public string? Label { get; set; }
        [DataMember(Name = "eip55")]
        public int? EIP55 { get; set; }
    }
}