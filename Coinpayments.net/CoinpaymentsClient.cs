using Coinpayments.NET.HttpUrlCaller;
using Coinpayments.NET.Models;

namespace Coinpayments.NET
{
    public class CoinpaymentsClient : IDisposable
    {
        private readonly HttpUrlCaller.HttpUrlCaller _caller;
        private readonly string _defaultAddress;
        private bool disposedValue;

        /// <summary>
        /// CoinpaymentsClient <a href="https://www.coinpayments.net/apidoc-intro">https://www.coinpayments.net/apidoc-intro</a>
        /// </summary>
        /// <param name="publicKey">Your API public key</param>
        /// <param name="privateKey">Your API private key</param>
        /// <param name="defaultAddress">The default email is for the buyer. You can change when creating a new transaction</param>
        public CoinpaymentsClient(string publicKey, string privateKey, string defaultEmailAddress)
        {
            _caller = new(publicKey, privateKey);
            _defaultAddress = defaultEmailAddress;
        }

        /// <summary>
        /// Create Transaction <a href="https://www.coinpayments.net/apidoc-create-transaction">https://www.coinpayments.net/apidoc-create-transaction</a>
        /// </summary>
        /// <param name="amount">The amount of the transaction in the original currency (currency1 below).</param>
        /// <param name="currency1">The original currency of the transaction.</param>
        /// <param name="currency2">The currency the buyer will be sending. For example if your products are priced in USD but you are receiving BTC, you would use currency1=USD and currency2=BTC. currency1 and currency2 can be set to the same thing if you don't need currency conversion.</param>
        /// <param name="buyerEmail">Set the buyer's email address. This will let us send them a notice if they underpay or need a refund. We will not add them to our mailing list or spam them or anything like that</param>
        /// <param name="address">Optionally set the address to send the funds to (if not set will use the settings you have set on the 'Coins Acceptance Settings' page). Remember: this must be an address in currency2's network.</param>
        /// <param name="buyerName">Optionally set the buyer's name for your reference.</param>
        /// <param name="itemName">Item name for your reference, will be on the payment information page and in the IPNs for the transaction.</param>
        /// <param name="itemNumber">Item number for your reference, will be on the payment information page and in the IPNs for the transaction.</param>
        /// <param name="invoice">Another field for your use, will be on the payment information page and in the IPNs for the transaction.</param>
        /// <param name="custom">Another field for your use, will be on the payment information page and in the IPNs for the transaction.</param>
        /// <param name="ipnUrl">URL for your IPN callbacks. If not set it will use the IPN URL in your Edit Settings page if you have one set.</param>
        /// <param name="successUrl">Sets a URL to go to if the buyer does complete payment. (Only if you use the returned 'checkout_url', no effect/need if designing your own checkout page.)</param>
        /// <param name="cancelUrl">Sets a URL to go to if the buyer does not complete payment. (Only if you use the returned 'checkout_url', no effect/need if designing your own checkout page.)</param>
        /// <returns></returns>
        public async Task<CreateTransactionResponse> CreateTransactionAsync(
            decimal amount,
            string currency1,
            string currency2,
            string? buyerEmail = null,
            string? address = null,
            string? buyerName = null,
            string? itemName = null,
            string? itemNumber = null,
            string? invoice = null,
            string? custom = null,
            string? ipnUrl = null,
            string? successUrl = null,
            string? cancelUrl = null
            )
        {
            var request = new CreateTransactionRequest
            {
                Amount = amount,
                Currency1 = currency1,
                Currency2 = currency2,
                BuyerEmail = buyerEmail ?? _defaultAddress,
                Address = address,
                BuyerName = buyerName,
                ItemName = itemName,
                ItemNumber = itemNumber,
                Invoice = invoice,
                Custom = custom,
                IpnUrl = ipnUrl,
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl
            };

            var req = new HttpUrlRequest(request);
            return await ProcessAsync<CreateTransactionResponse>(req);
        }

        /// <summary>
        /// Exchange Rates / Coin List <a href="https://www.coinpayments.net/apidoc-rates">https://www.coinpayments.net/apidoc-rates</a>
        /// </summary>
        /// <param name="isshort">If set to true, the response won't include the full coin names and number of confirms needed to save bandwidth.</param>
        /// <param name="accepted">If set to false, the response will include if you have the coin enabled for acceptance on your Coin Acceptance Settings page. If set to true, the response will include all fiat coins but only cryptocurrencies enabled for acceptance on your Coin Acceptance Settings page.</param>
        /// <returns></returns>
        public async Task<ExchangeRatesResponse> ExchangeRatesAsync(bool isshort = false, bool accepted = true)
        {
            var request = new ExchangeRatesRequest
            {
                Short = isshort ? 1 : 0,
                Accepted = accepted ? 2 : 1
            };

            var req = new HttpUrlRequest(request);
            return await ProcessAsync<ExchangeRatesResponse>(req);
        }

        /// <summary>
        /// Transaction Information <a href="https://www.coinpayments.net/apidoc-get-tx-info">https://www.coinpayments.net/apidoc-get-tx-info</a>
        /// </summary>
        /// <param name="tx_id">The transaction ID to query</param>
        /// <param name="isFull">Set to true to also include the raw checkout and shipping data for the payment if available. (default: false)</param>
        /// <returns></returns>
        public async Task<object> GetTransactionInformationAsync(string txn_id, bool isFull = false)
        {
            var request = new TransactionInformationRequest
            {
                TxnId = txn_id,
                IsFull = isFull ? 1 : 0
            };

            var req = new HttpUrlRequest(request);
            return await ProcessAsync<TransactionInformationRespone>(req);
        }

        /// <summary>
        /// Transaction Information <a href="https://www.coinpayments.net/apidoc-get-tx-info">https://www.coinpayments.net/apidoc-get-tx-info</a>
        /// </summary>
        /// <param name="tx_id">Array of transaction IDs. Lets you query up to 25 transaction ID(s)</param>
        /// <param name="isFull">Set to true to also include the raw checkout and shipping data for the payment if available. (default: false)</param>
        /// <returns></returns>
        public async Task<object> GetTransactionInformationAsync(string[] txn_id)
        {
            var request = new MultipleTransactionInformationRequest
            {
                TxnId = string.Join("|", txn_id)
            };

            var req = new HttpUrlRequest(request);
            return await ProcessAsync<MultipleTransactionInformationRespone>(req);
        }

        /// <summary>
        /// Get Callback Address <a href="https://www.coinpayments.net/apidoc-get-callback-address">https://www.coinpayments.net/apidoc-get-callback-address</a>
        /// </summary>
        /// <param name="currency">The currency the buyer will be sending.</param>
        /// <param name="ipn_url">URL for your IPN callbacks. If not set it will use the IPN URL in your Edit Settings page if you have one set.</param>
        /// <param name="label">Optionally sets the address label.</param>
        /// <param name="eip55">If set to true encodes the address in EIP-55 mixed case format for ETH/ERC20 + clones. This is safely false for other coin types.</param>
        /// <returns></returns>
        public async Task<object> GetCallBackAddressAsync(string currency,
            string? ipn_url = null,
            string? label = null,
            bool eip55 = false)
        {
            var request = new GetCallbackAddressRequest
            {
                Currency = currency,
                IpnUrl = ipn_url,
                Label = label,
                EIP55 = eip55 ? 1 : null
            };

            var req = new HttpUrlRequest(request);
            return await ProcessAsync<GetCallbackAddressRespone>(req);
        }

        private async Task<T1> ProcessAsync<T1>(HttpUrlRequest request)
            where T1 : ResponseModel, new()
        {
            var response = await _caller.GetResponseAsync(request);

            var result = new T1
            {
                HttpResponse = response
            };
            result.ProcessJson();

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                { _caller?.Dispose(); }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}