using Binance_Smart_Chain_Wallet.Enums;
using Binance_Smart_Chain_Wallet.Models;
using Binance_Smart_Chain_Wallet.Modules;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Numerics;

namespace Binance_Smart_Chain_Wallet
{
    public partial class MainForm : Form
    {
        private readonly string _password = "CQzo5uzEeTK6";
        private string _usdtContractAddress = string.Empty;
        private string _network = string.Empty;
        private BigInteger _chainID = BigInteger.Zero;
        private int _defaultGasPrice = 0;
        private string _scanUrl = string.Empty;
        private readonly ulong _defaultGas = 21000;
        public MainForm()
        {
            InitializeComponent();
            cbbNetwork.SelectedItem = "BSC TestNet";
            cbbToken.SelectedItem = "USDT";
        }

        internal static string? OpenDialog(string title, string filter = "Lacosi files|*.lacosi")
        {
            OpenFileDialog theDialog = new()
            {
                Title = title.ToString(),
                Filter = filter
            };
            DialogResult result = theDialog.ShowDialog();
            if (result == DialogResult.OK) return theDialog.FileName.ToString();
            else return null;
        }
        internal static string? SaveDialog(string title, string filter = "Lacosi files|*.lacosi")
        {
            SaveFileDialog theDialog = new()
            {
                Title = title.ToString(),
                Filter = filter
            };
            DialogResult result = theDialog.ShowDialog();
            if (result == DialogResult.OK) return theDialog.FileName.ToString();
            else return null;
        }

        private void CreateMainWallet_Click(object sender, EventArgs e)
        {
            var result = ShowMessage(MessageState.Question, "Bạn có chắc chắn muốn tạo Địa chỉ ví mới, vui lòng sao lưu địa chỉ hiện tại trước khi tạo địa chỉ mới", "Cảnh báo");
            if (result == DialogResult.Yes)
            {
                var newWallet = Wallet.CreateNewWallet();
                WalletDetail walletDetail = Wallet.GetDetail(newWallet);
                txtMainSeedWords.Text = walletDetail.SeedWords;
                txtMainAddress.Text = walletDetail.Address;
                txtMainPrivateKey.Text = walletDetail.PrivateKey;
            }
        }
        private async void SaveMainWallet_ClickAsync(object sender, EventArgs e)
        {
            string mainAddress = txtMainAddress.Text;
            string mainPrivateKey = txtMainPrivateKey.Text;
            string mainSeedWords = txtMainSeedWords.Text;

            if (!string.IsNullOrWhiteSpace(mainAddress) && !string.IsNullOrWhiteSpace(mainPrivateKey))
            {
                string? path = SaveDialog("Save Main Wallet");
                var mainWallet = new { publickey = mainAddress, privatekey = mainPrivateKey, seedwords = mainSeedWords };
                string json = JsonConvert.SerializeObject(mainWallet);
                if (path != null)
                {
                    await Encryption.FileEncryptAsync(path, _password, json);
                    ShowMessage(MessageState.Information, "Lưu thành công");
                }
            }
            else
            { ShowMessage(MessageState.Error, "Không được để trống Địa chỉ ví hoặc Private Key"); }
        }
        private async void LoadMainWallet_Click(object sender, EventArgs e)
        {
            string? path = OpenDialog("Import Main Wallet");
            if (path != null)
            {
                string line = await Encryption.FileDecryptAsync(path, _password);
                dynamic? results = JsonConvert.DeserializeObject<dynamic>(line);
                if (results != null)
                {
                    txtMainAddress.Text = results.publickey;
                    txtMainPrivateKey.Text = results.privatekey;
                    txtMainSeedWords.Text = results.seedwords;
                }
            }
        }
        private void Recovery_Click(object sender, EventArgs e)
        {
            var result = ShowMessage(MessageState.Question, "Bạn có chắc chắn muốn khôi phục ví từ Seed Words. Vui lòng sao lưu địa chỉ hiện tại trước khi khôi phục từ Seed Words", "Cảnh báo");
            if (result == DialogResult.Yes)
            {
                try
                {
                    var recoverWallet = Wallet.RecoverWallet(txtMainSeedWords.Text.Trim());
                    WalletDetail walletDetail = Wallet.GetDetail(recoverWallet);
                    txtMainSeedWords.Text = walletDetail.SeedWords;
                    txtMainAddress.Text = walletDetail.Address;
                    txtMainPrivateKey.Text = walletDetail.PrivateKey;
                }
                catch (Exception ex)
                { ShowMessage(MessageState.Error, ExceptionMean(ex.Message)); }
            }
        }

        private async void CheckMainBalance_Click(object sender, EventArgs e)
        {
            txtBNB.Text = string.Empty;
            txtUSDT.Text = string.Empty;

            var mainWalletAddress = txtMainAddress.Text;

            if (Util.IsValidAddress(mainWalletAddress))
            {
                if (_network != string.Empty)
                {
                    //Get BNB Balance
                    var bnbAmount = await Balance.GetBalanceAsync(_network, mainWalletAddress);
                    txtBNB.Text = string.Format("{0:#,0.######}", bnbAmount);

                    //Get USDT Balance
                    var contractAmount = await Balance.GetContractBalanceAsync(_network, _usdtContractAddress, mainWalletAddress);
                    txtUSDT.Text = string.Format("{0:#,0.######}", contractAmount);
                }
                else
                { ShowMessage(MessageState.Error, "Không được để trống Địa chỉ ví, Private Key và RPC (Web3) Url"); }
            }
            else
            { ShowMessage(MessageState.Error, "Địa chỉ ví không đúng định dạng"); }
        }
        private async void CheckTokenBalance_Click(object sender, EventArgs e)
        {
            string contractAddress;

            if ((string)cbbToken.SelectedItem == "USDT")
            { contractAddress = _usdtContractAddress; }
            else if (Util.IsValidAddressHexFormat(txtContractAddress.Text))
            { contractAddress = txtContractAddress.Text; }
            else
            { ShowMessage(MessageState.Error, "Địa chỉ Contract không hợp lệ"); return; }

            var mainWalletAddress = txtMainAddress.Text;
            txtTokenBalance.Text = string.Empty;

            if (Util.IsValidAddress(mainWalletAddress))
            {
                //Get Token Balance
                var contractAmount = await Balance.GetContractBalanceAsync(_network, contractAddress, mainWalletAddress);
                txtTokenBalance.Text = string.Format("{0:#,0.######}", contractAmount);
            }
            else
            { ShowMessage(MessageState.Error, "Địa chỉ ví chính không đúng định dạng"); }
        }

        private async void Send_Click(object sender, EventArgs e)
        {
            var mainWalletAddress = txtMainAddress.Text;
            string receiveAddress = txtReceiveAddress.Text;
            string mainWalletPrivateKey = txtMainPrivateKey.Text;

            if (!string.IsNullOrWhiteSpace(mainWalletPrivateKey))
            {
                if (Util.IsValidAddress(receiveAddress) && decimal.TryParse(txtAmount.Text, out var amountBNB))
                {
                    try
                    {
                        bool bgasAmount = ulong.TryParse(txtGas.Text, out var gasAmount);
                        bool bgasPrice = int.TryParse(txtGasPrice.Text, out var gasPrice);
                        bool bnonce = ulong.TryParse(txtNonce.Text, out var nonce);

                        var detail = new TransactionDetail
                        {
                            SenderPrivateKey = mainWalletPrivateKey,
                            Amount = amountBNB,
                            ReceiveAddress = receiveAddress,
                            Nonce = bnonce ? nonce : null,
                            GasPrice = bgasPrice ? gasPrice : _defaultGasPrice,
                            GasAmount = bgasAmount ? gasAmount : _defaultGas
                        };

                        var maximumAmount = await Balance.GetMaximumAmountCanSendAsync(_network,
                            mainWalletAddress,
                            (int)detail.GasPrice,
                            (ulong)detail.GasAmount);

                        if (maximumAmount - amountBNB >= 0)
                        {
                            var confirm = ShowMessage(MessageState.Question, "Xác nhận thông tin" +
                            $"\nTo: {detail.ReceiveAddress}" +
                            $"\nAmount: {detail.Amount} (BNB)" +
                            $"\nGas: {detail.GasAmount}" +
                            $"\nGas Price: {detail.GasPrice} (Gwei)" +
                            $"\nNonce: {(detail.Nonce == null ? "Auto" : detail.Nonce)}",
                            "Xác nhận");

                            if (confirm == DialogResult.Yes)
                            {
                                var transactionHash = await Transaction.SendAsync(detail, _chainID, _network);

                                var openConfirm = ShowMessage(MessageState.Question, $"Hoàn tất giao dịch\n" +
                                    $"Txn Hash: {transactionHash}\n" +
                                    $"Bạn có muốn mở trình duyệt để kiểm tra ?", "Mở trình duyệt");
                                if (openConfirm == DialogResult.Yes)
                                { Process.Start(new ProcessStartInfo(_scanUrl + transactionHash) { UseShellExecute = true }); }
                            }
                        }
                        else
                        {
                            var confirm = ShowMessage(MessageState.Question, $"Không đủ tiền !!!\nSố BNB tối đa có thể chuyển là {maximumAmount} BNB" +
                             $"\nBạn có muốn Copy số này vào Clipboard ???", messageBoxIcon: MessageBoxIcon.Error);
                            if (confirm == DialogResult.Yes)
                            { Clipboard.SetText(maximumAmount.ToString()); }
                        }
                    }
                    catch (Exception ex)
                    { ShowMessage(MessageState.Error, ExceptionMean(ex.Message)); }
                }
                else
                { ShowMessage(MessageState.Error, "Không được bỏ trống địa chỉ nhận, số lượng hoặc địa chỉ nhận không đúng định dạng"); }
            }
            else
            { ShowMessage(MessageState.Error, "Không được bỏ trống Private key"); }
        }
        private async void SendToken_Click(object sender, EventArgs e)
        {
            string contractAddress;

            if ((string)cbbToken.SelectedItem == "USDT")
            { contractAddress = _usdtContractAddress; }
            else if (Util.IsValidAddressHexFormat(txtContractAddress.Text))
            { contractAddress = txtContractAddress.Text; }
            else
            { ShowMessage(MessageState.Error, "Địa chỉ Contract không hợp lệ"); return; }

            string mainWalletAddress = txtMainAddress.Text;
            string mainWalletPrivateKey = txtMainPrivateKey.Text;
            string receiveAddress = txtTokenReceiveAddress.Text;

            if (!string.IsNullOrWhiteSpace(mainWalletPrivateKey))
            {
                if (Util.IsValidAddress(receiveAddress) && decimal.TryParse(txtTokenAmount.Text, out var tokenAmount))
                {
                    try
                    {
                        bool bgasAmount = ulong.TryParse(txtTokenGas.Text, out var gasAmount);
                        bool bgasPrice = int.TryParse(txtTokenGasPrice.Text, out var gasPrice);
                        bool bnonce = ulong.TryParse(txtTokenNonce.Text, out var nonce);

                        var detail = new TokenTransactionDetail
                        {
                            SenderPrivateKey = mainWalletPrivateKey,
                            Amount = tokenAmount,
                            ReceiveAddress = receiveAddress,
                            Nonce = bnonce ? nonce : null,
                            GasPrice = bgasPrice ? gasPrice : _defaultGasPrice,
                            GasAmount = bgasAmount ? gasAmount : null,
                            ContractAddress = contractAddress
                        };

                        var maximumAmount = await Balance.GetMaximumTokenAmountCanSendAsync(_network, contractAddress, mainWalletAddress);

                        if (maximumAmount - tokenAmount >= 0)
                        {
                            var confirm = ShowMessage(MessageState.Question, "Xác nhận thông tin" +
                            $"\nTo: {detail.ReceiveAddress}" +
                            $"\nToken Amount: {detail.Amount}" +
                            $"\nGas: {(detail.GasAmount == null ? "Auto" : detail.GasAmount)}" +
                            $"\nGas Price: {detail.GasPrice} (Gwei)" +
                            $"\nNonce: {(detail.Nonce == null ? "Auto" : detail.Nonce)}",
                            "Xác nhận");

                            if (confirm == DialogResult.Yes)
                            {
                                var transactionHash = await Transaction.SendAsync(detail, _chainID, _network);

                                var openConfirm = ShowMessage(MessageState.Question, $"Hoàn tất giao dịch\n" +
                                    $"Txn Hash: {transactionHash}\n" +
                                    $"Bạn có muốn mở trình duyệt để kiểm tra ?", "Mở trình duyệt");
                                if (openConfirm == DialogResult.Yes)
                                { Process.Start(new ProcessStartInfo(_scanUrl + transactionHash) { UseShellExecute = true }); }
                            }
                        }
                        else
                        {
                            var confirm = ShowMessage(MessageState.Question, $"Không đủ tiền !!!\nSố Token tối đa có thể chuyển là {maximumAmount}" +
                             $"\nBạn có muốn Copy số này vào Clipboard ???", messageBoxIcon: MessageBoxIcon.Error);
                            if (confirm == DialogResult.Yes)
                            { Clipboard.SetText(maximumAmount.ToString()); }
                        }
                    }
                    catch (Exception ex)
                    { ShowMessage(MessageState.Error, ExceptionMean(ex.Message)); }
                }
                else
                { ShowMessage(MessageState.Error, "Không được bỏ trống địa chỉ nhận, số lượng hoặc địa chỉ nhận không đúng định dạng"); }
            }
            else
            { ShowMessage(MessageState.Error, "Không được bỏ trống Private key"); }
        }

        private void Network_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox cbb)
            {
                if ((string)cbb.SelectedItem == "BSC MainNet")
                {
                    //BSC MainNet (BEP-20)
                    _usdtContractAddress = "0x55d398326f99059ff775485246999027b3197955";
                    _network = "https://bsc-dataseed1.binance.org:443";
                    _chainID = 56;
                    _defaultGasPrice = 5;
                    _scanUrl = "https://bscscan.com/tx/";
                }
                else if ((string)cbb.SelectedItem == "BSC TestNet")
                {
                    //BSC TestNet
                    _usdtContractAddress = "0x337610d27c682E347C9cD60BD4b3b107C9d34dDd";
                    _network = "https://data-seed-prebsc-1-s1.binance.org:8545";
                    _chainID = 97;
                    _defaultGasPrice = 10;
                    _scanUrl = "https://testnet.bscscan.com/tx/";
                }
            }
        }
        private void Token_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox cbb)
            {
                if ((string)cbb.SelectedItem == "USDT")
                {
                    txtContractAddress.Text = string.Empty;
                    txtContractAddress.Enabled = false;
                }
                else if ((string)cbb.SelectedItem == "Custom")
                {
                    txtContractAddress.Enabled = true;
                }
            }
        }

        private static DialogResult ShowMessage(MessageState state, string content, string? title = null, MessageBoxIcon? messageBoxIcon = null)
        {
            switch (state)
            {
                case MessageState.Information: return MessageBox.Show(content, title ?? "Thông báo", MessageBoxButtons.OK, messageBoxIcon ?? MessageBoxIcon.Information);
                case MessageState.Error: return MessageBox.Show(content, title ?? "Lỗi", MessageBoxButtons.OK, messageBoxIcon ?? MessageBoxIcon.Error);
                case MessageState.Question: return MessageBox.Show(content, title ?? "Thông báo", MessageBoxButtons.YesNo, messageBoxIcon ?? MessageBoxIcon.Question);
                default: MessageBox.Show(content, title); return DialogResult.OK;
            }
        }
        private static string ExceptionMean(string exceptionMessage)
        {
            if (exceptionMessage.Contains("transaction underpriced"))
                return "Phí Gas (Gas Price) quá nhỏ không đủ để thực hiện giao dịch";
            else if (exceptionMessage.Contains("nonce too low"))
                return "Số Nonce quá nhỏ, hãy bỏ trống để hệ thống tự động điền";
            else if (exceptionMessage.Contains("intrinsic gas too low"))
                return "Số lượng Gas (Gas Amount) quá nhỏ";
            else if (exceptionMessage.Contains("insufficient funds for gas * price + value"))
                return "Không đủ BNB trả phí giao dịch";
            else if (exceptionMessage.Contains("transfer amount exceeds balance"))
                return "Giao dịch với số coin/token lớn hơn đang có";
            else if (exceptionMessage.Contains("Word count should be 12,15,18,21 or 24"))
                return "Seed words phải có 12, 15, 18, 21, 24 chữ";
            else if (exceptionMessage.Contains("is not in the wordlist for this language"))
                return "Có một chữ không nằm trong danh sách chữ cái tiếng Anh để khôi phục";
            else if (exceptionMessage.Contains("Rpc timeout after"))
                return "Truy cập đến mạng lưới quá chậm";
            else
                return $"Lỗi không xác định: \n{exceptionMessage}";
        }
    }
}