namespace Encrypt_Decrypt
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbRawStrings = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEncryptPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFileEncrypt = new System.Windows.Forms.Button();
            this.rtbEncrypt = new System.Windows.Forms.RichTextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFileDecrypt = new System.Windows.Forms.Button();
            this.rtbDecrypt = new System.Windows.Forms.RichTextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtDecryptPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRSAEncrypt = new System.Windows.Forms.Button();
            this.btnRSAFileEncrypt = new System.Windows.Forms.Button();
            this.rtbRSAEncrypt = new System.Windows.Forms.RichTextBox();
            this.btnCreateRSAKey = new System.Windows.Forms.Button();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRSAFileDecrypt = new System.Windows.Forms.Button();
            this.rtbRSADecrypt = new System.Windows.Forms.RichTextBox();
            this.btnRSADecrypt = new System.Windows.Forms.Button();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbRawStrings
            // 
            this.rtbRawStrings.Location = new System.Drawing.Point(12, 27);
            this.rtbRawStrings.Name = "rtbRawStrings";
            this.rtbRawStrings.Size = new System.Drawing.Size(758, 92);
            this.rtbRawStrings.TabIndex = 0;
            this.rtbRawStrings.Text = resources.GetString("rtbRawStrings.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nội dung mã hóa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // txtEncryptPassword
            // 
            this.txtEncryptPassword.Location = new System.Drawing.Point(75, 22);
            this.txtEncryptPassword.Name = "txtEncryptPassword";
            this.txtEncryptPassword.Size = new System.Drawing.Size(295, 23);
            this.txtEncryptPassword.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFileEncrypt);
            this.groupBox1.Controls.Add(this.rtbEncrypt);
            this.groupBox1.Controls.Add(this.btnEncrypt);
            this.groupBox1.Controls.Add(this.txtEncryptPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 324);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mã hóa cùng Mật Khẩu";
            // 
            // btnFileEncrypt
            // 
            this.btnFileEncrypt.Location = new System.Drawing.Point(295, 51);
            this.btnFileEncrypt.Name = "btnFileEncrypt";
            this.btnFileEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnFileEncrypt.TabIndex = 6;
            this.btnFileEncrypt.Text = "Xuất file";
            this.btnFileEncrypt.UseVisualStyleBackColor = true;
            this.btnFileEncrypt.Click += new System.EventHandler(this.FileEncrypt_Click);
            // 
            // rtbEncrypt
            // 
            this.rtbEncrypt.Location = new System.Drawing.Point(12, 80);
            this.rtbEncrypt.Name = "rtbEncrypt";
            this.rtbEncrypt.ReadOnly = true;
            this.rtbEncrypt.Size = new System.Drawing.Size(358, 225);
            this.rtbEncrypt.TabIndex = 5;
            this.rtbEncrypt.Text = "";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(12, 51);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Mã hóa";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFileDecrypt);
            this.groupBox2.Controls.Add(this.rtbDecrypt);
            this.groupBox2.Controls.Add(this.btnDecrypt);
            this.groupBox2.Controls.Add(this.txtDecryptPassword);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(394, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 324);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giải mã cùng Mật khẩu";
            // 
            // btnFileDecrypt
            // 
            this.btnFileDecrypt.Location = new System.Drawing.Point(295, 51);
            this.btnFileDecrypt.Name = "btnFileDecrypt";
            this.btnFileDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnFileDecrypt.TabIndex = 6;
            this.btnFileDecrypt.Text = "Nhập file";
            this.btnFileDecrypt.UseVisualStyleBackColor = true;
            this.btnFileDecrypt.Click += new System.EventHandler(this.FileDecrypt_Click);
            // 
            // rtbDecrypt
            // 
            this.rtbDecrypt.Location = new System.Drawing.Point(12, 80);
            this.rtbDecrypt.Name = "rtbDecrypt";
            this.rtbDecrypt.ReadOnly = true;
            this.rtbDecrypt.Size = new System.Drawing.Size(358, 225);
            this.rtbDecrypt.TabIndex = 5;
            this.rtbDecrypt.Text = "";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(12, 51);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Giải mã";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // txtDecryptPassword
            // 
            this.txtDecryptPassword.Location = new System.Drawing.Point(75, 22);
            this.txtDecryptPassword.Name = "txtDecryptPassword";
            this.txtDecryptPassword.Size = new System.Drawing.Size(295, 23);
            this.txtDecryptPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRSAEncrypt);
            this.groupBox3.Controls.Add(this.btnRSAFileEncrypt);
            this.groupBox3.Controls.Add(this.rtbRSAEncrypt);
            this.groupBox3.Controls.Add(this.btnCreateRSAKey);
            this.groupBox3.Controls.Add(this.txtPublicKey);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 455);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 324);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mã hóa RSA";
            // 
            // btnRSAEncrypt
            // 
            this.btnRSAEncrypt.Location = new System.Drawing.Point(93, 51);
            this.btnRSAEncrypt.Name = "btnRSAEncrypt";
            this.btnRSAEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnRSAEncrypt.TabIndex = 7;
            this.btnRSAEncrypt.Text = "Mã hóa";
            this.btnRSAEncrypt.UseVisualStyleBackColor = true;
            this.btnRSAEncrypt.Click += new System.EventHandler(this.RSAEncrypt_Click);
            // 
            // btnRSAFileEncrypt
            // 
            this.btnRSAFileEncrypt.Location = new System.Drawing.Point(295, 51);
            this.btnRSAFileEncrypt.Name = "btnRSAFileEncrypt";
            this.btnRSAFileEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnRSAFileEncrypt.TabIndex = 6;
            this.btnRSAFileEncrypt.Text = "Xuất file";
            this.btnRSAFileEncrypt.UseVisualStyleBackColor = true;
            this.btnRSAFileEncrypt.Click += new System.EventHandler(this.RSAFileEncrypt_Click);
            // 
            // rtbRSAEncrypt
            // 
            this.rtbRSAEncrypt.Location = new System.Drawing.Point(12, 80);
            this.rtbRSAEncrypt.Name = "rtbRSAEncrypt";
            this.rtbRSAEncrypt.ReadOnly = true;
            this.rtbRSAEncrypt.Size = new System.Drawing.Size(358, 225);
            this.rtbRSAEncrypt.TabIndex = 5;
            this.rtbRSAEncrypt.Text = "";
            // 
            // btnCreateRSAKey
            // 
            this.btnCreateRSAKey.Location = new System.Drawing.Point(12, 51);
            this.btnCreateRSAKey.Name = "btnCreateRSAKey";
            this.btnCreateRSAKey.Size = new System.Drawing.Size(75, 23);
            this.btnCreateRSAKey.TabIndex = 4;
            this.btnCreateRSAKey.Text = "Tạo Key";
            this.btnCreateRSAKey.UseVisualStyleBackColor = true;
            this.btnCreateRSAKey.Click += new System.EventHandler(this.CreateRSAKey_Click);
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(75, 22);
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(295, 23);
            this.txtPublicKey.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Public Key";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRSAFileDecrypt);
            this.groupBox4.Controls.Add(this.rtbRSADecrypt);
            this.groupBox4.Controls.Add(this.btnRSADecrypt);
            this.groupBox4.Controls.Add(this.txtPrivateKey);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(394, 455);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(376, 324);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Giải mã RSA";
            // 
            // btnRSAFileDecrypt
            // 
            this.btnRSAFileDecrypt.Location = new System.Drawing.Point(295, 51);
            this.btnRSAFileDecrypt.Name = "btnRSAFileDecrypt";
            this.btnRSAFileDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnRSAFileDecrypt.TabIndex = 6;
            this.btnRSAFileDecrypt.Text = "Nhập file";
            this.btnRSAFileDecrypt.UseVisualStyleBackColor = true;
            this.btnRSAFileDecrypt.Click += new System.EventHandler(this.RSAFileDecrypt_Click);
            // 
            // rtbRSADecrypt
            // 
            this.rtbRSADecrypt.Location = new System.Drawing.Point(12, 80);
            this.rtbRSADecrypt.Name = "rtbRSADecrypt";
            this.rtbRSADecrypt.ReadOnly = true;
            this.rtbRSADecrypt.Size = new System.Drawing.Size(358, 225);
            this.rtbRSADecrypt.TabIndex = 5;
            this.rtbRSADecrypt.Text = "";
            // 
            // btnRSADecrypt
            // 
            this.btnRSADecrypt.Location = new System.Drawing.Point(12, 51);
            this.btnRSADecrypt.Name = "btnRSADecrypt";
            this.btnRSADecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnRSADecrypt.TabIndex = 4;
            this.btnRSADecrypt.Text = "Giải mã";
            this.btnRSADecrypt.UseVisualStyleBackColor = true;
            this.btnRSADecrypt.Click += new System.EventHandler(this.RSADecrypt_Click);
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Location = new System.Drawing.Point(75, 22);
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(295, 23);
            this.txtPrivateKey.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Private Key";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 794);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbRawStrings);
            this.Name = "MainForm";
            this.Text = "Encrypt-Decrypt";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox rtbRawStrings;
        private Label label1;
        private Label label2;
        private TextBox txtEncryptPassword;
        private GroupBox groupBox1;
        private Button btnFileEncrypt;
        private RichTextBox rtbEncrypt;
        private Button btnEncrypt;
        private GroupBox groupBox2;
        private Button btnFileDecrypt;
        private RichTextBox rtbDecrypt;
        private Button btnDecrypt;
        private TextBox txtDecryptPassword;
        private Label label3;
        private GroupBox groupBox3;
        private Button btnRSAFileEncrypt;
        private RichTextBox rtbRSAEncrypt;
        private Button btnCreateRSAKey;
        private TextBox txtPublicKey;
        private Label label4;
        private GroupBox groupBox4;
        private Button btnRSAFileDecrypt;
        private RichTextBox rtbRSADecrypt;
        private Button btnRSADecrypt;
        private TextBox txtPrivateKey;
        private Label label5;
        private Button btnRSAEncrypt;
    }
}