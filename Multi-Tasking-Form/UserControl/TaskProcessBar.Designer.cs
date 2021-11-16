namespace Multi_Tasking_Form
{
    partial class TaskProcessBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TaskProgessBar = new System.Windows.Forms.ProgressBar();
            this.TaskIdLabel = new System.Windows.Forms.Label();
            this.WaitingInQueueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TaskProgessBar
            // 
            this.TaskProgessBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskProgessBar.Location = new System.Drawing.Point(175, 8);
            this.TaskProgessBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TaskProgessBar.Name = "TaskProgessBar";
            this.TaskProgessBar.Size = new System.Drawing.Size(253, 35);
            this.TaskProgessBar.TabIndex = 3;
            this.TaskProgessBar.Visible = false;
            // 
            // TaskIdLabel
            // 
            this.TaskIdLabel.AutoSize = true;
            this.TaskIdLabel.Location = new System.Drawing.Point(4, 14);
            this.TaskIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TaskIdLabel.Name = "TaskIdLabel";
            this.TaskIdLabel.Size = new System.Drawing.Size(146, 20);
            this.TaskIdLabel.TabIndex = 2;
            this.TaskIdLabel.Text = "";
            // 
            // WaitingInQueueLabel
            // 
            this.WaitingInQueueLabel.AutoSize = true;
            this.WaitingInQueueLabel.Location = new System.Drawing.Point(202, 14);
            this.WaitingInQueueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WaitingInQueueLabel.Name = "WaitingInQueueLabel";
            this.WaitingInQueueLabel.Size = new System.Drawing.Size(148, 20);
            this.WaitingInQueueLabel.TabIndex = 4;
            this.WaitingInQueueLabel.Text = "Chờ đợi tới lượt chạy";
            // 
            // TaskProcessBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TaskProgessBar);
            this.Controls.Add(this.TaskIdLabel);
            this.Controls.Add(this.WaitingInQueueLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TaskProcessBar";
            this.Size = new System.Drawing.Size(436, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.ProgressBar TaskProgessBar;
        private System.Windows.Forms.Label TaskIdLabel;
        private System.Windows.Forms.Label WaitingInQueueLabel;
    }
}
