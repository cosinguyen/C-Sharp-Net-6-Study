using Coinpayments.NET.Enums;
using System.Runtime.Serialization;

namespace Coinpayments.NET.Models
{
    internal class MultipleTransactionInformationRespone : ResponseModelFoundation<Dictionary<string, MultipleTransactionInformationRespone.Item>>
    {
        [DataContract]
        public class Item
        {
            /// <summary>
            /// Name of Coin
            /// </summary>
            [DataMember(Name = "error")]
            public string? Error { get; set; }
            /// <summary>
            /// Name of Coin
            /// </summary>
            [DataMember(Name = "coin")]
            public string? Coin { get; set; }
            /// <summary>
            /// Amount to send (as a floating point number).
            /// </summary>
            [DataMember(Name = "amountf")]
            public decimal Amount { get; set; }
            /// <summary>
            /// Received amount (as a floating point number).
            /// </summary>
            [DataMember(Name = "receivedf")]
            public decimal Received { get; set; }
            /// <summary>
            /// The time the transaction request was created.
            /// </summary>
            public DateTime? CreatedTime { get { return Utils.TimestampConverter(CreatedTimeUnix); } }
            /// <summary>
            /// The time the transaction request expires.
            /// </summary>
            public DateTime? ExpiresTime { get { return Utils.TimestampConverter(ExpiresTimeUnix); } }
            /// <summary>
            /// Status of the payment
            /// </summary>
            public TransactionStatus Status { get { return Utils.TransactionStatusConverter(StatusCode); } }
            public DateTime? CompletedTime { get { return Utils.TimestampConverter(CompletedTimeUnix); } }

            /// <summary>
            /// Status expressed in human readable text.
            /// </summary>
            [DataMember(Name = "status_text")]
            public string? Status_Text { get; set; }
            /// <summary>
            /// fiat or coins
            /// </summary>
            [DataMember(Name = "type")]
            public string? Type { get; set; }
            /// <summary>
            /// Received confirms.
            /// </summary>
            [DataMember(Name = "recv_confirms")]
            public int Confirms { get; set; }
            /// <summary>
            /// Address to send the fund to.
            /// </summary>
            [DataMember(Name = "payment_address")]
            public string? PaymentAddress { get; set; }
            [DataMember(Name = "time_created")]
            private string? CreatedTimeUnix
            {
                get;
                set;
            }
            [DataMember(Name = "time_expires")]
            private string? ExpiresTimeUnix
            {
                get;
                set;
            }
            [DataMember(Name = "time_completed")]
            private string? CompletedTimeUnix
            {
                get;
                set;
            }
            [DataMember(Name = "status")]
            private int StatusCode { get; set; }
        }
    }
}