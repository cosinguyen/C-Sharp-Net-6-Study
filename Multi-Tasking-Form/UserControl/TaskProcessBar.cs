namespace Multi_Tasking_Form
{
    public partial class TaskProcessBar : UserControl
    {
        readonly string TaskThreadIDLabel = "Task {0} - Thread {1}";
        readonly int TaskID;
        public TaskProcessBar()
        { InitializeComponent(); }
        public TaskProcessBar(int taskId, int ThreadID)
        {
            InitializeComponent();
            TaskID = taskId;
            TaskIdLabel.Text = string.Format(TaskThreadIDLabel, TaskID, ThreadID);
        }
        public void Update(int ProcessPerCent, int ThreadID)
        {
            TaskProgessBar.Visible = true;
            TaskProgessBar.Value = ProcessPerCent;
            TaskIdLabel.Text = string.Format(TaskThreadIDLabel, TaskID, ThreadID);
        }
    }
}
