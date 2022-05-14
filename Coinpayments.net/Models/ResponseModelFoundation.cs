using System.Runtime.Serialization;

namespace Coinpayments.NET.Models
{
    [DataContract]
    public class ResponseModelFoundation<T> : ResponseModel
    {
        public string? Error { get; set; }
        public T? Result { get; set; }

        public bool IsSuccess { get { return Error == "ok"; } }
    }
}