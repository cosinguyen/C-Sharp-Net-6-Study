using Coinpayments.NET;

Console.WriteLine("Hello, Coinpayment");

CoinpaymentsClient coinpayments = new("", "", "");

//var result = await coinpayments.ExchangeRatesAsync();


//var result = await coinpayments.CreateTransactionAsync(10, "USDT.TRC20", "USDT.TRC20");
//Console.WriteLine(result.Result.Address);

//var result = await coinpayments.GetTransactionInformationAsync("", true);

//var result = await coinpayments.GetTransactionInformationAsync(new string[] { "", "" });

var result = await coinpayments.GetCallBackAddressAsync("USDT.TRC20");

Console.ReadKey();