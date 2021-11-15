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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.TaskProgessBar = new System.Windows.Forms.ProgressBar();
			this.TaskIdLabel = new System.Windows.Forms.Label();
			this.WaitingInQueueLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// TaskProgessBar
			// 
			this.TaskProgessBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.TaskProgessBar.Location = new System.Drawing.Point(71, 5);
			this.TaskProgessBar.Name = "TaskProgessBar";
			this.TaskProgessBar.Size = new System.Drawing.Size(250, 23);
			this.TaskProgessBar.TabIndex = 3;
			this.TaskProgessBar.Visible = false;
			// 
			// TaskIdLabel
			// 
			this.TaskIdLabel.AutoSize = true;
			this.TaskIdLabel.Location = new System.Drawing.Point(3, 9);
			this.TaskIdLabel.Name = "TaskIdLabel";
			this.TaskIdLabel.Size = new System.Drawing.Size(48, 13);
			this.TaskIdLabel.TabIndex = 2;
			this.TaskIdLabel.Text = "Task {0}";
			// 
			// WaitingInQueueLabel
			// 
			this.WaitingInQueueLabel.AutoSize = true;
			this.WaitingInQueueLabel.Location = new System.Drawing.Point(80, 9);
			this.WaitingInQueueLabel.Name = "WaitingInQueueLabel";
			this.WaitingInQueueLabel.Size = new System.Drawing.Size(87, 13);
			this.WaitingInQueueLabel.TabIndex = 4;
			this.WaitingInQueueLabel.Text = "Waiting in queue";
			// 
			// WorkerProgressControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TaskProgessBar);
			this.Controls.Add(this.TaskIdLabel);
			this.Controls.Add(this.WaitingInQueueLabel);
			this.Name = "WorkerProgressControl";
			this.Size = new System.Drawing.Size(327, 36);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

        #endregion

        private System.Windows.Forms.ProgressBar TaskProgessBar;
        private System.Windows.Forms.Label TaskIdLabel;
        private System.Windows.Forms.Label WaitingInQueueLabel;
    }
}
