using Multi_Tasking_Form.Modules;

namespace Multi_Tasking_Form
{
    public partial class MainForm : Form
    {
        readonly string CurrentRunning = "Số luồng đang chạy: {0}";
        readonly string PendingTask = "Số Task đang chờ đợi: {0}";
        readonly string RunningTask = "Số Task đang chạy: {0}";
        readonly string FreeTask = "Số luồng còn trống: {0}";
        static readonly TaskTogether TaskQueue = new();
        readonly TaskFactory Factory = new(TaskQueue);
        int TaskProcess = 1;
        public MainForm()
        {
            InitializeComponent();

            //Gán các Text trên Form xuống các biến để xử lý
            lblFreeTask.Text = string.Format(FreeTask, 0);
            lblCurrentRunning.Text = string.Format(CurrentRunning, 0);
            lblPendingTask.Text = string.Format(PendingTask, 0);
            lblRunningTask.Text = string.Format(RunningTask, 0);

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
            lblFreeTask.Text = string.Format(FreeTask, TaskQueue.MaximumTaskCount - TaskQueue.RunningTaskCount);
            lblCurrentRunning.Text = string.Format(CurrentRunning, TaskQueue.RunningTaskCount);
            lblPendingTask.Text = string.Format(PendingTask, TaskQueue.WaitingTaskCount);
            lblRunningTask.Text = string.Format(RunningTask, TaskQueue.RunningTaskCount);
        }

        //Mỗi khi click tăng số thì cập nhật vào đối tượng TaskQueue
        private void numMaxTask_ValueChanged(object sender, EventArgs e)
        { TaskQueue.MaximumTaskCount = (int)numMaxTask.Value; }

        //Sự kiện mỗi khi click vào nút thêm việc
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var processbar = new TaskProcessBar(TaskProcess++, Environment.CurrentManagedThreadId);
            ProgressPanel.SuspendLayout();
            ProgressPanel.Controls.Add(processbar);
            processbar.Dock = DockStyle.Top;
            ProgressPanel.ResumeLayout(true);

            Factory.StartNew(() =>
            {
                for (var i = 0; i < 50; i++)
                {
                    var threadID = Environment.CurrentManagedThreadId;
                    try
                    { BeginInvoke(new Action(() => { processbar.Update(i * 2, threadID); })); }
                    finally
                    { Thread.Sleep(100); }
                }
                var threadIDs = Environment.CurrentManagedThreadId;
                try
                { BeginInvoke(new Action(() => { processbar.Update(100, threadIDs); })); }
                finally
                { Thread.Sleep(100); }
            });
        }
    }
}