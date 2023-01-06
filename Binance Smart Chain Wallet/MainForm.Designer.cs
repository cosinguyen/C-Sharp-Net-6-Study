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
            this.btnRecovery = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUSDT = new System.Windows.Forms.TextBox();
            this.txtBNB = new System.Windows.Forms.TextBox();
            this.btnCreateMainWallet = new System.Windows.Forms.Button();
            this.txtMainSeedWords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCheckMainBalance = new System.Windows.Forms.Button();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNonce = new System.Windows.Forms.TextBox();
            this.txtGasPrice = new System.Windows.Forms.TextBox();
            this.txtGas = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtReceiveAddress = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTokenBalance = new System.Windows.Forms.TextBox();
            this.btnCheckTokenBalance = new System.Windows.Forms.Button();
            this.btnSendToken = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTokenNonce = new System.Windows.Forms.TextBox();
            this.txtTokenGasPrice = new System.Windows.Forms.TextBox();
            this.txtTokenGas = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTokenAmount = new System.Windows.Forms.TextBox();
            this.txtTokenReceiveAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtContractAddress = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbbToken = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbNetwork
            // 
            this.cbbNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNetwork.FormattingEnabled = true;
            this.cbbNetwork.Items.AddRange(new object[] {
            "BSC MainNet",
            "BSC TestNet"});
            this.cbbNetwork.Location = new System.Drawing.Point(103, 106);
            this.cbbNetwork.Name = "cbbNetwork";
            this.cbbNetwork.Size = new System.Drawing.Size(121, 23);
            this.cbbNetwork.TabIndex = 4;
            this.cbbNetwork.SelectedIndexChanged += new System.EventHandler(this.Network_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRecovery);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUSDT);
            this.groupBox1.Controls.Add(this.txtBNB);
            this.groupBox1.Controls.Add(this.btnCreateMainWallet);
            this.groupBox1.Controls.Add(this.txtMainSeedWords);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnCheckMainBalance);
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
            this.groupBox1.Size = new System.Drawing.Size(669, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ví chính";
            // 
            // btnRecovery
            // 
            this.btnRecovery.Location = new System.Drawing.Point(107, 135);
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Size = new System.Drawing.Size(95, 23);
            this.btnRecovery.TabIndex = 11;
            this.btnRecovery.Text = "Recovery";
            this.btnRecovery.UseVisualStyleBackColor = true;
            this.btnRecovery.Click += new System.EventHandler(this.Recovery_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(623, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "USDT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(623, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "BNB";
            // 
            // txtUSDT
            // 
            this.txtUSDT.Location = new System.Drawing.Point(519, 48);
            this.txtUSDT.Name = "txtUSDT";
            this.txtUSDT.ReadOnly = true;
            this.txtUSDT.Size = new System.Drawing.Size(100, 23);
            this.txtUSDT.TabIndex = 10;
            // 
            // txtBNB
            // 
            this.txtBNB.Location = new System.Drawing.Point(519, 19);
            this.txtBNB.Name = "txtBNB";
            this.txtBNB.ReadOnly = true;
            this.txtBNB.Size = new System.Drawing.Size(100, 23);
            this.txtBNB.TabIndex = 9;
            // 
            // btnCreateMainWallet
            // 
            this.btnCreateMainWallet.Location = new System.Drawing.Point(6, 135);
            this.btnCreateMainWallet.Name = "btnCreateMainWallet";
            this.btnCreateMainWallet.Size = new System.Drawing.Size(95, 23);
            this.btnCreateMainWallet.TabIndex = 5;
            this.btnCreateMainWallet.Text = "Create Wallet";
            this.btnCreateMainWallet.UseVisualStyleBackColor = true;
            this.btnCreateMainWallet.Click += new System.EventHandler(this.CreateMainWallet_Click);
            // 
            // txtMainSeedWords
            // 
            this.txtMainSeedWords.Location = new System.Drawing.Point(103, 77);
            this.txtMainSeedWords.Name = "txtMainSeedWords";
            this.txtMainSeedWords.Size = new System.Drawing.Size(375, 23);
            this.txtMainSeedWords.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Seed Words:";
            // 
            // btnCheckMainBalance
            // 
            this.btnCheckMainBalance.Location = new System.Drawing.Point(208, 135);
            this.btnCheckMainBalance.Name = "btnCheckMainBalance";
            this.btnCheckMainBalance.Size = new System.Drawing.Size(95, 23);
            this.btnCheckMainBalance.TabIndex = 8;
            this.btnCheckMainBalance.Text = "Check balance";
            this.btnCheckMainBalance.UseVisualStyleBackColor = true;
            this.btnCheckMainBalance.Click += new System.EventHandler(this.CheckMainBalance_Click);
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
            this.btnLoadMainWallet.Location = new System.Drawing.Point(568, 114);
            this.btnLoadMainWallet.Name = "btnLoadMainWallet";
            this.btnLoadMainWallet.Size = new System.Drawing.Size(95, 23);
            this.btnLoadMainWallet.TabIndex = 6;
            this.btnLoadMainWallet.Text = "Load";
            this.btnLoadMainWallet.UseVisualStyleBackColor = true;
            this.btnLoadMainWallet.Click += new System.EventHandler(this.LoadMainWallet_Click);
            // 
            // btnSaveMainWallet
            // 
            this.btnSaveMainWallet.Location = new System.Drawing.Point(568, 143);
            this.btnSaveMainWallet.Name = "btnSaveMainWallet";
            this.btnSaveMainWallet.Size = new System.Drawing.Size(95, 23);
            this.btnSaveMainWallet.TabIndex = 7;
            this.btnSaveMainWallet.Text = "Save";
            this.btnSaveMainWallet.UseVisualStyleBackColor = true;
            this.btnSaveMainWallet.Click += new System.EventHandler(this.SaveMainWallet_ClickAsync);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "RPC Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Private Key:";
            // 
            // txtMainPrivateKey
            // 
            this.txtMainPrivateKey.Location = new System.Drawing.Point(103, 48);
            this.txtMainPrivateKey.Name = "txtMainPrivateKey";
            this.txtMainPrivateKey.Size = new System.Drawing.Size(375, 23);
            this.txtMainPrivateKey.TabIndex = 2;
            // 
            // txtMainAddress
            // 
            this.txtMainAddress.Location = new System.Drawing.Point(103, 19);
            this.txtMainAddress.Name = "txtMainAddress";
            this.txtMainAddress.Size = new System.Drawing.Size(375, 23);
            this.txtMainAddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ Ví:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(669, 340);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tính năng";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(657, 307);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(649, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gửi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtNonce);
            this.groupBox3.Controls.Add(this.txtGasPrice);
            this.groupBox3.Controls.Add(this.txtGas);
            this.groupBox3.Controls.Add(this.txtAmount);
            this.groupBox3.Controls.Add(this.txtReceiveAddress);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(637, 203);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gửi";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(503, 167);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(128, 23);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.Send_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Nonce";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Gas Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Gas Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số lượng (*)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Địa chỉ ví (*)";
            // 
            // txtNonce
            // 
            this.txtNonce.Location = new System.Drawing.Point(102, 138);
            this.txtNonce.Name = "txtNonce";
            this.txtNonce.Size = new System.Drawing.Size(529, 23);
            this.txtNonce.TabIndex = 4;
            // 
            // txtGasPrice
            // 
            this.txtGasPrice.Location = new System.Drawing.Point(102, 109);
            this.txtGasPrice.Name = "txtGasPrice";
            this.txtGasPrice.Size = new System.Drawing.Size(529, 23);
            this.txtGasPrice.TabIndex = 3;
            // 
            // txtGas
            // 
            this.txtGas.Location = new System.Drawing.Point(102, 80);
            this.txtGas.Name = "txtGas";
            this.txtGas.Size = new System.Drawing.Size(529, 23);
            this.txtGas.TabIndex = 2;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(102, 51);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(529, 23);
            this.txtAmount.TabIndex = 1;
            // 
            // txtReceiveAddress
            // 
            this.txtReceiveAddress.Location = new System.Drawing.Point(102, 22);
            this.txtReceiveAddress.Name = "txtReceiveAddress";
            this.txtReceiveAddress.Size = new System.Drawing.Size(529, 23);
            this.txtReceiveAddress.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(649, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gửi Token";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtTokenBalance);
            this.groupBox4.Controls.Add(this.btnCheckTokenBalance);
            this.groupBox4.Controls.Add(this.btnSendToken);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtTokenNonce);
            this.groupBox4.Controls.Add(this.txtTokenGasPrice);
            this.groupBox4.Controls.Add(this.txtTokenGas);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtTokenAmount);
            this.groupBox4.Controls.Add(this.txtTokenReceiveAddress);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtContractAddress);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.cbbToken);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(637, 256);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gửi";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(477, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 15);
            this.label19.TabIndex = 20;
            this.label19.Text = "Balance";
            // 
            // txtTokenBalance
            // 
            this.txtTokenBalance.Location = new System.Drawing.Point(531, 16);
            this.txtTokenBalance.Name = "txtTokenBalance";
            this.txtTokenBalance.ReadOnly = true;
            this.txtTokenBalance.Size = new System.Drawing.Size(100, 23);
            this.txtTokenBalance.TabIndex = 11;
            // 
            // btnCheckTokenBalance
            // 
            this.btnCheckTokenBalance.Location = new System.Drawing.Point(503, 45);
            this.btnCheckTokenBalance.Name = "btnCheckTokenBalance";
            this.btnCheckTokenBalance.Size = new System.Drawing.Size(128, 23);
            this.btnCheckTokenBalance.TabIndex = 19;
            this.btnCheckTokenBalance.Text = "Check Token Balance";
            this.btnCheckTokenBalance.UseVisualStyleBackColor = true;
            this.btnCheckTokenBalance.Click += new System.EventHandler(this.CheckTokenBalance_Click);
            // 
            // btnSendToken
            // 
            this.btnSendToken.Location = new System.Drawing.Point(503, 223);
            this.btnSendToken.Name = "btnSendToken";
            this.btnSendToken.Size = new System.Drawing.Size(128, 23);
            this.btnSendToken.TabIndex = 18;
            this.btnSendToken.Text = "Gửi";
            this.btnSendToken.UseVisualStyleBackColor = true;
            this.btnSendToken.Click += new System.EventHandler(this.SendToken_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 198);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 15);
            this.label16.TabIndex = 17;
            this.label16.Text = "Nonce";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 169);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 15);
            this.label17.TabIndex = 16;
            this.label17.Text = "Gas Price";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 140);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 15);
            this.label18.TabIndex = 15;
            this.label18.Text = "Gas Amount";
            // 
            // txtTokenNonce
            // 
            this.txtTokenNonce.Location = new System.Drawing.Point(110, 194);
            this.txtTokenNonce.Name = "txtTokenNonce";
            this.txtTokenNonce.Size = new System.Drawing.Size(521, 23);
            this.txtTokenNonce.TabIndex = 14;
            // 
            // txtTokenGasPrice
            // 
            this.txtTokenGasPrice.Location = new System.Drawing.Point(110, 165);
            this.txtTokenGasPrice.Name = "txtTokenGasPrice";
            this.txtTokenGasPrice.Size = new System.Drawing.Size(521, 23);
            this.txtTokenGasPrice.TabIndex = 13;
            // 
            // txtTokenGas
            // 
            this.txtTokenGas.Location = new System.Drawing.Point(110, 136);
            this.txtTokenGas.Name = "txtTokenGas";
            this.txtTokenGas.Size = new System.Drawing.Size(521, 23);
            this.txtTokenGas.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 15);
            this.label14.TabIndex = 11;
            this.label14.Text = "Số lượng (*)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 15);
            this.label15.TabIndex = 10;
            this.label15.Text = "Địa chỉ ví (*)";
            // 
            // txtTokenAmount
            // 
            this.txtTokenAmount.Location = new System.Drawing.Point(110, 107);
            this.txtTokenAmount.Name = "txtTokenAmount";
            this.txtTokenAmount.Size = new System.Drawing.Size(521, 23);
            this.txtTokenAmount.TabIndex = 9;
            // 
            // txtTokenReceiveAddress
            // 
            this.txtTokenReceiveAddress.Location = new System.Drawing.Point(110, 74);
            this.txtTokenReceiveAddress.Name = "txtTokenReceiveAddress";
            this.txtTokenReceiveAddress.Size = new System.Drawing.Size(521, 23);
            this.txtTokenReceiveAddress.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "Contract Address";
            // 
            // txtContractAddress
            // 
            this.txtContractAddress.Location = new System.Drawing.Point(110, 45);
            this.txtContractAddress.Name = "txtContractAddress";
            this.txtContractAddress.Size = new System.Drawing.Size(383, 23);
            this.txtContractAddress.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Token";
            // 
            // cbbToken
            // 
            this.cbbToken.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbToken.FormattingEnabled = true;
            this.cbbToken.Items.AddRange(new object[] {
            "USDT",
            "Custom"});
            this.cbbToken.Location = new System.Drawing.Point(56, 16);
            this.cbbToken.Name = "cbbToken";
            this.cbbToken.Size = new System.Drawing.Size(121, 23);
            this.cbbToken.TabIndex = 2;
            this.cbbToken.SelectedIndexChanged += new System.EventHandler(this.Token_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 550);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Cosi Wallet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private Button btnCheckMainBalance;
        private GroupBox groupBox2;
        private Button btnCreateMainWallet;
        private TextBox txtMainSeedWords;
        private Label label4;
        private Label label6;
        private Label label5;
        private TextBox txtUSDT;
        private TextBox txtBNB;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox3;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox txtNonce;
        private TextBox txtGasPrice;
        private TextBox txtGas;
        private TextBox txtAmount;
        private TextBox txtReceiveAddress;
        private Button btnSend;
        private GroupBox groupBox4;
        private Label label13;
        private TextBox txtContractAddress;
        private Label label12;
        private ComboBox cbbToken;
        private Button btnSendToken;
        private Label label16;
        private Label label17;
        private Label label18;
        private TextBox txtTokenNonce;
        private TextBox txtTokenGasPrice;
        private TextBox txtTokenGas;
        private Label label14;
        private Label label15;
        private TextBox txtTokenAmount;
        private TextBox txtTokenReceiveAddress;
        private Button btnCheckTokenBalance;
        private TextBox txtTokenBalance;
        private Button btnRecovery;
        private Label label19;
    }
}