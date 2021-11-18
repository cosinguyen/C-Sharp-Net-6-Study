namespace FacebookCookies_w_Selenium
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
            this.btnOpenChrome = new System.Windows.Forms.Button();
            this.btnGetCookies = new System.Windows.Forms.Button();
            this.btnLoadCookies = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOpenChrome
            // 
            this.btnOpenChrome.Location = new System.Drawing.Point(12, 12);
            this.btnOpenChrome.Name = "btnOpenChrome";
            this.btnOpenChrome.Size = new System.Drawing.Size(93, 23);
            this.btnOpenChrome.TabIndex = 0;
            this.btnOpenChrome.Text = "Mở Chrome";
            this.btnOpenChrome.UseVisualStyleBackColor = true;
            this.btnOpenChrome.Click += new System.EventHandler(this.btnOpenChrome_Click);
            // 
            // btnGetCookies
            // 
            this.btnGetCookies.Location = new System.Drawing.Point(12, 41);
            this.btnGetCookies.Name = "btnGetCookies";
            this.btnGetCookies.Size = new System.Drawing.Size(93, 23);
            this.btnGetCookies.TabIndex = 1;
            this.btnGetCookies.Text = "Get Cookies";
            this.btnGetCookies.UseVisualStyleBackColor = true;
            this.btnGetCookies.Click += new System.EventHandler(this.btnGetCookies_Click);
            // 
            // btnLoadCookies
            // 
            this.btnLoadCookies.Location = new System.Drawing.Point(12, 70);
            this.btnLoadCookies.Name = "btnLoadCookies";
            this.btnLoadCookies.Size = new System.Drawing.Size(93, 23);
            this.btnLoadCookies.TabIndex = 2;
            this.btnLoadCookies.Text = "Load Cookies";
            this.btnLoadCookies.UseVisualStyleBackColor = true;
            this.btnLoadCookies.Click += new System.EventHandler(this.btnLoadCookies_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(111, 41);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(501, 23);
            this.txtOutput.TabIndex = 3;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(111, 70);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(501, 23);
            this.txtInput.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 111);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnLoadCookies);
            this.Controls.Add(this.btnGetCookies);
            this.Controls.Add(this.btnOpenChrome);
            this.Name = "MainForm";
            this.Text = "Play with Facebook Cookie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnOpenChrome;
        private Button btnGetCookies;
        private Button btnLoadCookies;
        private TextBox txtOutput;
        private TextBox txtInput;
    }
}