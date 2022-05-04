﻿namespace Binance_Smart_Chain_Wallet.Models
{
    internal class TransactionDetail
    {
        public string? SenderPrivateKey { get; set; }
        public string? ReceiveAddress { get; set; }
        public decimal Amount { get; set; }
        public ulong? GasAmount { get; set; }
        public int? GasPrice { set; get; }
        public ulong? Nonce { set; get; }
    }
}