﻿using Encrypt_Decrypt.Modules;

namespace Encrypt_Decrypt
{
    public partial class MainForm : Form
    {
        public MainForm()
        { InitializeComponent(); }
        private async void Encrypt_Click(object sender, EventArgs e)
        {
            var RawStrings = rtbRawStrings.Text;
            var EncryptPassword = txtEncryptPassword.Text;

            if (!string.IsNullOrEmpty(RawStrings))
            {
                var EncryptStrings = Encryption.EncryptAsync(EncryptPassword, RawStrings);
                rtbEncrypt.Text = await EncryptStrings;
            }
            else
            { MessageBox.Show("Có dữ liệu đâu mà mã hóa"); }
        }
        private async void Decrypt_Click(object sender, EventArgs e)
        {
            var EncryptStrings = rtbEncrypt.Text;
            var DecryptPassword = txtDecryptPassword.Text;

            if (!string.IsNullOrEmpty(EncryptStrings))
            {
                var DecryptStrings = Encryption.DecryptAsync(DecryptPassword, EncryptStrings);
                rtbDecrypt.Text = await DecryptStrings;
            }
            else
            { MessageBox.Show("Có dữ liệu đâu mà giải mã"); }
        }

        private async void FileEncrypt_Click(object sender, EventArgs e)
        {
            var RawStrings = rtbRawStrings.Text;
            var EncryptPassword = txtEncryptPassword.Text;

            if (!string.IsNullOrEmpty(RawStrings))
            {
                string? FileName = null;

                SaveFileDialog saveFileDialog = new();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                { FileName = saveFileDialog.FileName; }

                if (FileName != null)
                {
                    await Encryption.FileEncryptAsync(FileName, EncryptPassword, RawStrings);
                    MessageBox.Show("Hoàn tất mã hóa xuống file");
                }
            }
            else
            { MessageBox.Show("Có dữ liệu đâu mà mã hóa"); }
        }
        private async void FileDecrypt_Click(object sender, EventArgs e)
        {
            var DecryptPassword = txtDecryptPassword.Text;

            string? FileName = null;

            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            { FileName = openFileDialog.FileName; }

            if (FileName != null)
            {
                string DecryptStrings = await Encryption.FileDecryptAsync(FileName, DecryptPassword);
                rtbDecrypt.Text = DecryptStrings;
                MessageBox.Show("Hoàn tất đọc file mã hóa");
            }
        }

        private void CreateRSAKey_Click(object sender, EventArgs e)
        {
            Encryption.GenerateRSAKey(out string pubKey, out string priKey);
            txtPublicKey.Text = pubKey;
            txtPrivateKey.Text = priKey;
        }

        private async void RSAFileEncrypt_Click(object sender, EventArgs e)
        {
            var RawStrings = rtbRawStrings.Text;
            var PublicKey = txtPublicKey.Text;

            if (!string.IsNullOrEmpty(RawStrings) && !string.IsNullOrEmpty(PublicKey))
            {
                string? FileName = null;

                SaveFileDialog saveFileDialog = new();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                { FileName = saveFileDialog.FileName; }

                if (FileName != null)
                {
                    await Encryption.RSAFileEncryptAsync(FileName, PublicKey, RawStrings);
                    MessageBox.Show("Hoàn tất mã hóa xuống file");
                }
            }
            else
            { MessageBox.Show("Có dữ liệu hoặc PublicKey đâu mà mã hóa"); }
        }
        private async void RSAFileDecrypt_Click(object sender, EventArgs e)
        {
            var PrivateKey = txtPrivateKey.Text;

            if (!string.IsNullOrEmpty(PrivateKey))
            {
                string? FileName = null;

                OpenFileDialog openFileDialog = new();
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                { FileName = openFileDialog.FileName; }

                if (FileName != null)
                {
                    string DecryptStrings = await Encryption.RSAFileDecryptAsync(FileName, PrivateKey);
                    rtbRSADecrypt.Text = DecryptStrings;
                    MessageBox.Show("Hoàn tất đọc file mã hóa");
                }
            }
            else
            { MessageBox.Show("Không có Private Key không thể giải mã"); }
        }

        private async void RSAEncrypt_Click(object sender, EventArgs e)
        {
            var RawStrings = rtbRawStrings.Text;
            var PublicKey = txtPublicKey.Text;

            if (!string.IsNullOrEmpty(RawStrings) && !string.IsNullOrEmpty(PublicKey))
            {
                var EncryptStrings = Encryption.RSAEncryptAsync(PublicKey, RawStrings);
                rtbRSAEncrypt.Text = await EncryptStrings;
            }
            else
            { MessageBox.Show("Có dữ liệu hoặc PublicKey đâu mà mã hóa"); }
        }
        private async void RSADecrypt_Click(object sender, EventArgs e)
        {
            var EncryptStrings = rtbRSAEncrypt.Text;
            var PrivateKey = txtPrivateKey.Text;

            if (!string.IsNullOrEmpty(PrivateKey))
            {
                var DecryptStrings = Encryption.RSADecryptAsync(PrivateKey, EncryptStrings);
                rtbRSADecrypt.Text = await DecryptStrings;
            }
            else
            { MessageBox.Show("Không có Private Key không thể giải mã"); }
        }
    }
}