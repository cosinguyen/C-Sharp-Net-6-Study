using Multi_Tasking_Form.Modules;

namespace Multi_Tasking_Form
{
    public partial class MainForm : Form
    {
        readonly string? CurrentRunning;
        readonly string? PendingTask;
        readonly string? RunningTask;
        readonly string? FreeTask;
        int TaskProcess = 1;
        readonly TaskTogether TaskQueue = new();
        public MainForm()
        {
            InitializeComponent();

            //Gán các Text trên Form xuống các biến để xử lý
            CurrentRunning = lblCurrentRunning.Text;
            PendingTask = lblPendingTask.Text;
            RunningTask = lblRunningTask.Text;
            FreeTask = lblFreeTask.Text;

            //Báo số Task tối đa có thể chạy đồng thời
            TaskQueue.MaximumTaskCount = (int)numMaxTask.Value;

            //Bật Timer
            StatusTimer.Enabled = true;
        }

        //Dùng Timer để cập nhật lại các thông số theo từng Tick
        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            //Đảm bảo dữ liệu đúng bằng cách load lại vô Numberic
            numMaxTask.Value = TaskQueue.MaximumTaskCount;

            //Sẽ cập nhật các label mỗi Tick
            lblFreeTask.Text = string.Format(FreeTask ?? "", TaskQueue.MaximumTaskCount - TaskQueue.RunningTaskCount);
            lblCurrentRunning.Text = string.Format(CurrentRunning ?? "", TaskQueue.RunningTaskCount);
            lblPendingTask.Text = string.Format(PendingTask ?? "", TaskQueue.WaitingTaskCount);
            lblRunningTask.Text = string.Format(RunningTask ?? "", TaskQueue.RunningTaskCount);
        }

        //Mỗi khi click tăng số thì cập nhật vào đối tượng TaskQueue
        private void numMaxTask_ValueChanged(object sender, EventArgs e)
        { TaskQueue.MaximumTaskCount = (int)numMaxTask.Value; }

        //Sự kiện mỗi khi click vào nút thêm việc
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var processbar = new TaskProcessBar(TaskProcess++);
            ProgressPanel.SuspendLayout();
            ProgressPanel.Controls.Add(processbar);
            processbar.Dock = DockStyle.Top;
            ProgressPanel.ResumeLayout(true);
            new TaskFactory(TaskQueue).StartNew(() =>
            {
                for (var i = 0; i < 50; ++i)
                {
                    Thread.Sleep(100);
                    BeginInvoke(new Action(() =>
                    { processbar.Value = i * 2; }));
                }
                BeginInvoke(new Action(() => { processbar.Value = 100; }));
            });
        }
    }
}