using System.Net;

namespace Coinpayments.NET.HttpUrlCaller
{
    public class HttpUrlResponse
    {
        internal HttpUrlResponse(
            HttpStatusCode statusCode,
            bool isSuccess,
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers,
            string contentBody,
            string requestUri,
            string requestbody)
        {
            Headers = headers.ToList();
            StatusCode = statusCode;
            ContentBody = contentBody;
            IsSuccessStatusCode = isSuccess;

            RequestUri = requestUri;
            RequestBody = requestbody;
        }

        internal IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; private set; }
        internal string ContentBody { get; private set; }
        internal HttpStatusCode StatusCode { get; private set; }
        internal bool IsSuccessStatusCode { get; private set; }
        internal string RequestUri { get; private set; }
        internal string RequestBody { get; private set; }
    }
}
