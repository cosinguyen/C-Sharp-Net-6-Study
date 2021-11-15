namespace Selenium_w_Tinsoft
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
            this.btnRun = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.numThreadPerProxy = new System.Windows.Forms.NumericUpDown();
            this.numThreadTotal = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLiveCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.rtbTinsoftKey = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadPerProxy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 401);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(391, 23);
            this.btnRun.TabIndex = 23;
            this.btnRun.Text = "2. GÁN VÀO SELENIUM";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Proxy get được:";
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(231, 298);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.ReadOnly = true;
            this.rtbResult.Size = new System.Drawing.Size(172, 84);
            this.rtbResult.TabIndex = 21;
            this.rtbResult.Text = "";
            // 
            // numThreadPerProxy
            // 
            this.numThreadPerProxy.Location = new System.Drawing.Point(105, 359);
            this.numThreadPerProxy.Name = "numThreadPerProxy";
            this.numThreadPerProxy.Size = new System.Drawing.Size(120, 23);
            this.numThreadPerProxy.TabIndex = 20;
            this.numThreadPerProxy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numThreadTotal
            // 
            this.numThreadTotal.Location = new System.Drawing.Point(105, 323);
            this.numThreadTotal.Name = "numThreadTotal";
            this.numThreadTotal.Size = new System.Drawing.Size(120, 23);
            this.numThreadTotal.TabIndex = 19;
            this.numThreadTotal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Luồng / Proxy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Luồng Chrome";
            // 
            // lblLiveCount
            // 
            this.lblLiveCount.AutoSize = true;
            this.lblLiveCount.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLiveCount.ForeColor = System.Drawing.Color.Green;
            this.lblLiveCount.Location = new System.Drawing.Point(183, 272);
            this.lblLiveCount.Name = "lblLiveCount";
            this.lblLiveCount.Size = new System.Drawing.Size(24, 30);
            this.lblLiveCount.TabIndex = 16;
            this.lblLiveCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Số Key sống (Proxy get được):";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(12, 242);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(391, 23);
            this.btnCheck.TabIndex = 14;
            this.btnCheck.Text = "1. CHECK API TINSOFT";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // rtbTinsoftKey
            // 
            this.rtbTinsoftKey.Location = new System.Drawing.Point(12, 27);
            this.rtbTinsoftKey.Name = "rtbTinsoftKey";
            this.rtbTinsoftKey.Size = new System.Drawing.Size(391, 209);
            this.rtbTinsoftKey.TabIndex = 13;
            this.rtbTinsoftKey.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Danh sách key Tinsoft";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 450);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.numThreadPerProxy);
            this.Controls.Add(this.numThreadTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLiveCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.rtbTinsoftKey);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Check và cài đặt Proxy vào Selenium";
            ((System.ComponentModel.ISupportInitialize)(this.numThreadPerProxy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnRun;
        private Label label5;
        private RichTextBox rtbResult;
        private NumericUpDown numThreadPerProxy;
        private NumericUpDown numThreadTotal;
        private Label label4;
        private Label label3;
        private Label lblLiveCount;
        private Label label2;
        private Button btnCheck;
        private RichTextBox rtbTinsoftKey;
        private Label label1;
    }
}