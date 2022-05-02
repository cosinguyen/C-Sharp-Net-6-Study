namespace Binance_Smart_Chain_Wallet
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbbNetwork = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheckMainBalance = new System.Windows.Forms.Button();
            this.lblMainUSDT = new System.Windows.Forms.Label();
            this.lblMainBNB = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadMainWallet = new System.Windows.Forms.Button();
            this.btnSaveMainWallet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMainPrivateKey = new System.Windows.Forms.TextBox();
            this.txtMainAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbNetwork
            // 
            this.cbbNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNetwork.FormattingEnabled = true;
            this.cbbNetwork.Items.AddRange(new object[] {
            "MainNet",
            "TestNet"});
            this.cbbNetwork.Location = new System.Drawing.Point(103, 77);
            this.cbbNetwork.Name = "cbbNetwork";
            this.cbbNetwork.Size = new System.Drawing.Size(121, 23);
            this.cbbNetwork.TabIndex = 3;
            this.cbbNetwork.SelectedIndexChanged += new System.EventHandler(this.Network_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheckMainBalance);
            this.groupBox1.Controls.Add(this.lblMainUSDT);
            this.groupBox1.Controls.Add(this.lblMainBNB);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnLoadMainWallet);
            this.groupBox1.Controls.Add(this.btnSaveMainWallet);
            this.groupBox1.Controls.Add(this.cbbNetwork);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMainPrivateKey);
            this.groupBox1.Controls.Add(this.txtMainAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ví chính";
            // 
            // btnCheckMainBalance
            // 
            this.btnCheckMainBalance.Location = new System.Drawing.Point(484, 77);
            this.btnCheckMainBalance.Name = "btnCheckMainBalance";
            this.btnCheckMainBalance.Size = new System.Drawing.Size(121, 23);
            this.btnCheckMainBalance.TabIndex = 9;
            this.btnCheckMainBalance.Text = "Check";
            this.btnCheckMainBalance.UseVisualStyleBackColor = true;
            this.btnCheckMainBalance.Click += new System.EventHandler(this.CheckMainBalance_Click);
            // 
            // lblMainUSDT
            // 
            this.lblMainUSDT.AutoSize = true;
            this.lblMainUSDT.Location = new System.Drawing.Point(515, 53);
            this.lblMainUSDT.Name = "lblMainUSDT";
            this.lblMainUSDT.Size = new System.Drawing.Size(13, 15);
            this.lblMainUSDT.TabIndex = 9;
            this.lblMainUSDT.Text = "0";
            // 
            // lblMainBNB
            // 
            this.lblMainBNB.AutoSize = true;
            this.lblMainBNB.Location = new System.Drawing.Point(515, 24);
            this.lblMainBNB.Name = "lblMainBNB";
            this.lblMainBNB.Size = new System.Drawing.Size(13, 15);
            this.lblMainBNB.TabIndex = 8;
            this.lblMainBNB.Text = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(484, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(484, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadMainWallet
            // 
            this.btnLoadMainWallet.Location = new System.Drawing.Point(230, 77);
            this.btnLoadMainWallet.Name = "btnLoadMainWallet";
            this.btnLoadMainWallet.Size = new System.Drawing.Size(121, 23);
            this.btnLoadMainWallet.TabIndex = 7;
            this.btnLoadMainWallet.Text = "Load";
            this.btnLoadMainWallet.UseVisualStyleBackColor = true;
            this.btnLoadMainWallet.Click += new System.EventHandler(this.LoadMainWallet_Click);
            // 
            // btnSaveMainWallet
            // 
            this.btnSaveMainWallet.Location = new System.Drawing.Point(357, 77);
            this.btnSaveMainWallet.Name = "btnSaveMainWallet";
            this.btnSaveMainWallet.Size = new System.Drawing.Size(121, 23);
            this.btnSaveMainWallet.TabIndex = 8;
            this.btnSaveMainWallet.Text = "Save";
            this.btnSaveMainWallet.UseVisualStyleBackColor = true;
            this.btnSaveMainWallet.Click += new System.EventHandler(this.SaveMainWallet_ClickAsync);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "RPC (Web3) Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Private Key:";
            // 
            // txtMainPrivateKey
            // 
            this.txtMainPrivateKey.Location = new System.Drawing.Point(91, 48);
            this.txtMainPrivateKey.Name = "txtMainPrivateKey";
            this.txtMainPrivateKey.PasswordChar = '*';
            this.txtMainPrivateKey.Size = new System.Drawing.Size(387, 23);
            this.txtMainPrivateKey.TabIndex = 2;
            // 
            // txtMainAddress
            // 
            this.txtMainAddress.Location = new System.Drawing.Point(91, 19);
            this.txtMainAddress.Name = "txtMainAddress";
            this.txtMainAddress.Size = new System.Drawing.Size(387, 23);
            this.txtMainAddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Địa chỉ Ví:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(795, 514);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tính năng";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(6, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 486);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(775, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Giao dịch";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 662);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Cosi Wallet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbbNetwork;
        private Label label3;
        private Label label2;
        private TextBox txtMainPrivateKey;
        private TextBox txtMainAddress;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btnLoadMainWallet;
        private Button btnSaveMainWallet;
        private Label lblMainUSDT;
        private Label lblMainBNB;
        private Button btnCheckMainBalance;
        private GroupBox groupBox2;
        private TabControl tabControl1;
        private TabPage tabPage1;
    }
}