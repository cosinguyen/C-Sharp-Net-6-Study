namespace Multi_Tasking_Form
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
            this.components = new System.ComponentModel.Container();
            this.numMaxTask = new System.Windows.Forms.NumericUpDown();
            this.lblMaxTask = new System.Windows.Forms.Label();
            this.lblCurrentRunning = new System.Windows.Forms.Label();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.ProgressPanel = new System.Windows.Forms.Panel();
            this.lblRunningTask = new System.Windows.Forms.Label();
            this.lblFreeTask = new System.Windows.Forms.Label();
            this.lblPendingTask = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTask)).BeginInit();
            this.SuspendLayout();
            // 
            // numMaxTask
            // 
            this.numMaxTask.Location = new System.Drawing.Point(184, 84);
            this.numMaxTask.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.numMaxTask.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMaxTask.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxTask.Name = "numMaxTask";
            this.numMaxTask.Size = new System.Drawing.Size(85, 27);
            this.numMaxTask.TabIndex = 11;
            this.numMaxTask.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxTask.ValueChanged += new System.EventHandler(this.numMaxTask_ValueChanged);
            // 
            // lblMaxTask
            // 
            this.lblMaxTask.AutoSize = true;
            this.lblMaxTask.Location = new System.Drawing.Point(16, 88);
            this.lblMaxTask.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaxTask.Name = "lblMaxTask";
            this.lblMaxTask.Size = new System.Drawing.Size(156, 20);
            this.lblMaxTask.TabIndex = 10;
            this.lblMaxTask.Text = "Số luồng mong muốn:";
            // 
            // lblCurrentRunning
            // 
            this.lblCurrentRunning.AutoSize = true;
            this.lblCurrentRunning.Location = new System.Drawing.Point(16, 9);
            this.lblCurrentRunning.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCurrentRunning.Name = "lblCurrentRunning";
            this.lblCurrentRunning.Size = new System.Drawing.Size(0, 20);
            this.lblCurrentRunning.TabIndex = 9;
            // 
            // StatusTimer
            // 
            this.StatusTimer.Interval = 50;
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressPanel.AutoScroll = true;
            this.ProgressPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressPanel.Location = new System.Drawing.Point(16, 209);
            this.ProgressPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Size = new System.Drawing.Size(412, 265);
            this.ProgressPanel.TabIndex = 16;
            // 
            // lblRunningTask
            // 
            this.lblRunningTask.AutoSize = true;
            this.lblRunningTask.Location = new System.Drawing.Point(16, 172);
            this.lblRunningTask.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRunningTask.Name = "lblRunningTask";
            this.lblRunningTask.Size = new System.Drawing.Size(0, 20);
            this.lblRunningTask.TabIndex = 15;
            // 
            // lblFreeTask
            // 
            this.lblFreeTask.AutoSize = true;
            this.lblFreeTask.Location = new System.Drawing.Point(16, 49);
            this.lblFreeTask.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFreeTask.Name = "lblFreeTask";
            this.lblFreeTask.Size = new System.Drawing.Size(0, 20);
            this.lblFreeTask.TabIndex = 14;
            // 
            // lblPendingTask
            // 
            this.lblPendingTask.AutoSize = true;
            this.lblPendingTask.Location = new System.Drawing.Point(16, 137);
            this.lblPendingTask.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPendingTask.Name = "lblPendingTask";
            this.lblPendingTask.Size = new System.Drawing.Size(0, 20);
            this.lblPendingTask.TabIndex = 13;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(275, 164);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(154, 36);
            this.btnAddTask.TabIndex = 12;
            this.btnAddTask.Text = "GIAO VIỆC (+1)";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 493);
            this.Controls.Add(this.numMaxTask);
            this.Controls.Add(this.lblMaxTask);
            this.Controls.Add(this.lblCurrentRunning);
            this.Controls.Add(this.ProgressPanel);
            this.Controls.Add(this.lblRunningTask);
            this.Controls.Add(this.lblFreeTask);
            this.Controls.Add(this.lblPendingTask);
            this.Controls.Add(this.btnAddTask);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "MainForm";
            this.Text = "Multi-Tasking trên Win Form";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numMaxTask;
        private System.Windows.Forms.Label lblMaxTask;
        private System.Windows.Forms.Label lblCurrentRunning;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.Panel ProgressPanel;
        private System.Windows.Forms.Label lblRunningTask;
        private System.Windows.Forms.Label lblFreeTask;
        private System.Windows.Forms.Label lblPendingTask;
        private System.Windows.Forms.Button btnAddTask;
    }
}