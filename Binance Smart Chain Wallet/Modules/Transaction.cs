using Binance_Smart_Chain_Wallet.Models;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Numerics;

namespace Binance_Smart_Chain_Wallet.Modules
{
    internal class Transaction
    {
        internal static async Task<TransactionReceipt> SendAndWaitForReceiptAsync(TransactionDetail detail, BigInteger chainID, string network, CancellationTokenSource? cancellationTokenSource = default)
        {
            Account account = new(detail.SenderPrivateKey, chainID);
            Web3 web3 = new(account, network);

            var transactionInput = new TransactionInput
            {
                Value = new HexBigInteger(Web3.Convert.ToWei(detail.Amount)),
                To = detail.ReceiveAddress,
                From = account.Address
            };

            if (detail.Nonce != null) transactionInput.Nonce = new HexBigInteger((ulong)detail.Nonce);
            if (detail.GasPrice != null) transactionInput.GasPrice = new HexBigInteger(Web3.Convert.ToWei((int)detail.GasPrice, UnitConversion.EthUnit.Gwei));
            if (detail.GasAmount != null) transactionInput.Gas = new HexBigInteger((ulong)detail.GasAmount);

            return await web3.TransactionManager.SendTransactionAndWaitForReceiptAsync(transactionInput, cancellationTokenSource);
        }

        internal static async Task<TransactionReceipt> SendAndWaitForReceiptAsync(TokenTransactionDetail detail, BigInteger chainID, string network, CancellationTokenSource? cancellationTokenSource = default)
        {
            Account account = new(detail.SenderPrivateKey, chainID);
            Web3 web3 = new(account, network);
            var handler = web3.Eth.GetContractHandler(detail.ContractAddress);

            var transferfuction = new TransferFunction
            {
                TokenAmount = Web3.Convert.ToWei(detail.Amount),
                To = detail.ReceiveAddress,
                FromAddress = account.Address
            };

            if (detail.Nonce != null) transferfuction.Nonce = new HexBigInteger((ulong)detail.Nonce);
            if (detail.GasPrice != null) transferfuction.GasPrice = new HexBigInteger(Web3.Convert.ToWei((int)detail.GasPrice, UnitConversion.EthUnit.Gwei));
            if (detail.GasAmount != null) transferfuction.Gas = new HexBigInteger((ulong)detail.GasAmount);

            return await handler.SendRequestAndWaitForReceiptAsync(transferfuction, cancellationTokenSource);
        }

        internal static async Task<string> SendAsync(TransactionDetail detail, BigInteger chainID, string network)
        {
            Account account = new(detail.SenderPrivateKey, chainID);
            Web3 web3 = new(account, network);

            var transactionInput = new TransactionInput
            {
                Value = new HexBigInteger(Web3.Convert.ToWei(detail.Amount)),
                To = detail.ReceiveAddress,
                From = account.Address
            };

            if (detail.Nonce != null) transactionInput.Nonce = new HexBigInteger((ulong)detail.Nonce);
            if (detail.GasPrice != null) transactionInput.GasPrice = new HexBigInteger(Web3.Convert.ToWei((int)detail.GasPrice, UnitConversion.EthUnit.Gwei));
            if (detail.GasAmount != null) transactionInput.Gas = new HexBigInteger((ulong)detail.GasAmount);

            return await web3.TransactionManager.SendTransactionAsync(transactionInput);
        }

        internal static async Task<string> SendAsync(TokenTransactionDetail detail, BigInteger chainID, string network)
        {
            Account account = new(detail.SenderPrivateKey, chainID);
            Web3 web3 = new(account, network);
            var handler = web3.Eth.GetContractHandler(detail.ContractAddress);

            var transferfuction = new TransferFunction
            {
                TokenAmount = Web3.Convert.ToWei(detail.Amount),
                To = detail.ReceiveAddress,
                FromAddress = account.Address
            };

            if (detail.Nonce != null) transferfuction.Nonce = new HexBigInteger((ulong)detail.Nonce);
            if (detail.GasPrice != null) transferfuction.GasPrice = new HexBigInteger(Web3.Convert.ToWei((int)detail.GasPrice, UnitConversion.EthUnit.Gwei));
            if (detail.GasAmount != null) transferfuction.Gas = new HexBigInteger((ulong)detail.GasAmount);

            return await handler.SendRequestAsync(transferfuction);
        }
    }
}