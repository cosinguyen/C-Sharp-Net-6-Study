using Coinpayments.NET.HttpUrlCaller;
using ServiceStack;
using ServiceStack.Text;

namespace Coinpayments.NET.Models
{
    public abstract class ResponseModel
    {
        public HttpUrlResponse? HttpResponse { get; set; }

        public void ProcessJson()
        {
            if (HttpResponse != null && HttpResponse.IsSuccessStatusCode)
            {
                var obj = JsonSerializer.DeserializeFromString(HttpResponse?.ContentBody, GetType());
                this.PopulateWithNonDefaultValues(obj);
            }
        }
    }
}