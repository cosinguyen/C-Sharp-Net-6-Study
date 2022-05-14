using ServiceStack.Text;

namespace Coinpayments.NET.HttpUrlCaller
{
    internal class HttpUrlRequest
    {
        internal HttpUrlRequest(object param, string method = "POST", string url = "https://www.coinpayments.net/api.php")
        {
            Method = method;
            RequestUrl = url;

            if (param != null)
            { RequestBody = JsonSerializer.SerializeToString(param); }
        }

        internal string Method { get; set; }
        internal string RequestUrl { get; set; }
        internal string? RequestBody { get; set; }
    }
}
