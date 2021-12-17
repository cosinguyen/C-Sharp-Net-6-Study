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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(376, 417);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mã hóa";
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
            this.rtbEncrypt.Size = new System.Drawing.Size(358, 331);
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
            this.groupBox2.Size = new System.Drawing.Size(376, 417);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giải mã";
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
            this.rtbDecrypt.Size = new System.Drawing.Size(358, 331);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 554);
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
    }
}