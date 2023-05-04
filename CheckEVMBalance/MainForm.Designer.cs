namespace CheckEVMBalance
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
            label1 = new Label();
            txtRPC = new TextBox();
            label2 = new Label();
            txtContract = new TextBox();
            rtbAddress = new RichTextBox();
            btnCheck = new Button();
            rtbOutput = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 0;
            label1.Text = "RPC Server Address";
            // 
            // txtRPC
            // 
            txtRPC.Location = new Point(127, 12);
            txtRPC.Name = "txtRPC";
            txtRPC.Size = new Size(966, 23);
            txtRPC.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 2;
            label2.Text = "Contract Address";
            // 
            // txtContract
            // 
            txtContract.Location = new Point(127, 41);
            txtContract.Name = "txtContract";
            txtContract.Size = new Size(966, 23);
            txtContract.TabIndex = 3;
            // 
            // rtbAddress
            // 
            rtbAddress.Location = new Point(12, 78);
            rtbAddress.Name = "rtbAddress";
            rtbAddress.Size = new Size(385, 491);
            rtbAddress.TabIndex = 4;
            rtbAddress.Text = "";
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(426, 266);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(178, 73);
            btnCheck.TabIndex = 5;
            btnCheck.Text = "CHECK";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += ButtonCheck_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(633, 78);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.ReadOnly = true;
            rtbOutput.Size = new Size(460, 491);
            rtbOutput.TabIndex = 6;
            rtbOutput.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 581);
            Controls.Add(rtbOutput);
            Controls.Add(btnCheck);
            Controls.Add(rtbAddress);
            Controls.Add(txtContract);
            Controls.Add(label2);
            Controls.Add(txtRPC);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Check EVM Balance";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRPC;
        private Label label2;
        private TextBox txtContract;
        private RichTextBox rtbAddress;
        private Button btnCheck;
        private RichTextBox rtbOutput;
    }
}