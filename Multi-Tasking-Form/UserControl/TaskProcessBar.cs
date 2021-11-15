namespace Multi_Tasking_Form
{
    public partial class TaskProcessBar : UserControl
    {
        public TaskProcessBar()
        { InitializeComponent(); }
        public TaskProcessBar(int taskId)
        {
            InitializeComponent();
            TaskIdLabel.Text = string.Format(TaskIdLabel.Text, taskId);
        }
        public int Value
        {
            get
            { return TaskProgessBar.Value; }
            set
            {
                TaskProgessBar.Visible = true;
                TaskProgessBar.Value = value;
            }
        }
    }
}
