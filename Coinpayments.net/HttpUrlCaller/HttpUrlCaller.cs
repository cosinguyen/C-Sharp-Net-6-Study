using ServiceStack.Text;
using System.Text;

namespace Coinpayments.NET.HttpUrlCaller
{
    internal class HttpUrlCaller : IDisposable
    {
        private readonly string PublicKey;
        private readonly string PrivateKey;

        internal HttpUrlCaller(string publicKey, string privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
        public async Task<HttpUrlResponse> GetResponseAsync(HttpUrlRequest request)
        {
            var absoluteUri = request.RequestUrl;

            var body = GetQueryString(request.RequestBody);
            var method = request.Method;

            var signature = Utils.CalcSignature(body, PrivateKey);

            using var httpClient = new HttpClient();

            HttpResponseMessage response;

            httpClient.DefaultRequestHeaders.Add("HMAC", signature);

            switch (method)
            {
                case "GET":
                    response = await httpClient.GetAsync(absoluteUri);
                    break;
                case "POST":
                    var requestBody = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");
                    response = await httpClient.PostAsync(absoluteUri, requestBody);
                    break;
                default:
                    throw new NotImplementedException("The supplied HTTP method is not supported: " + method ?? "(null)");
            }


            var contentBody = await response.Content.ReadAsStringAsync();
            var headers = response.Headers.AsEnumerable();
            var statusCode = response.StatusCode;
            var isSuccess = response.IsSuccessStatusCode;

            var genericExchangeResponse = new HttpUrlResponse(statusCode, isSuccess, headers, contentBody, absoluteUri, body);
            return genericExchangeResponse;
        }

        private string GetQueryString(string? _requestBody = null)
        {
            var dict = JsonSerializer.DeserializeFromString<Dictionary<string, string>>(_requestBody);

            dict.Add("version", "1");
            dict.Add("key", PublicKey);

            return Utils.DictionaryToFormData(dict);
        }

        public void Dispose()
        { GC.SuppressFinalize(this); }
    }
}