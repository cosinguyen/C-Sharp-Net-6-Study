namespace Multi_Tasking_Form
{
    public partial class TaskProcessBar : UserControl
    {
        readonly string TaskThreadIDLabel = "Task {0} -- Thread {1}";
        int TaskID;
        public TaskProcessBar()
        { InitializeComponent(); }
        public TaskProcessBar(int taskId)
        {
            InitializeComponent();
            TaskID = taskId;
            TaskIdLabel.Text = string.Format(TaskThreadIDLabel, TaskID, Environment.CurrentManagedThreadId);
        }
        public int Value
        {
            get
            { return TaskProgessBar.Value; }
            set
            {
                TaskProgessBar.Visible = true;
                TaskProgessBar.Value = value;
                TaskIdLabel.Text = string.Format(TaskThreadIDLabel, TaskID, Environment.CurrentManagedThreadId);
            }
        }
    }
}
