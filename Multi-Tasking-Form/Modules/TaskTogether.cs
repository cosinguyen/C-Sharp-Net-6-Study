namespace Multi_Tasking_Form.Modules
{
    public class TaskTogether : TaskScheduler
    {
        [ThreadStatic]
        private static bool IsThreadBusy;

        private readonly LinkedList<Task> LinkedTasks = new();

        private int MaxTaskInATime;

        private int TaskQueuedOrRunning = 0;

        private int TaskWaitting = 0;

        /// <summary>
        /// Khởi tạo lớp TaskTogether và gán mặc định số Task chạy đồng thời
        /// </summary>
        /// <param name="MaxTaskInATime">Số Task sẽ chạy đồng thời</param>
        public TaskTogether(int MaxTaskInATime)
        {
            //Khai báo kèm số lượng Task khi khởi tạo
            //Kiểm tra số lượng Task đăng ký, có thể giới hạn tại đây nếu muốn
            if (MaxTaskInATime < 1) throw new ArgumentOutOfRangeException(nameof(MaxTaskInATime));
            this.MaxTaskInATime = MaxTaskInATime;
        }

        /// <summary>
        /// Khởi tạo lớp TaskTogether và không gán số Task chạy đồng thời, mặc định là 1
        /// </summary>
        public TaskTogether()
        {
            //Khai báo khi khởi tạo không kèm số lượng Task, sẽ cập nhật sau
            //Mặc định là 1 
            MaxTaskInATime = 1;
        }

        /// <summary>
        /// Phương thức để lấy hoặc gán số Task chạy đồng thời, thay đôi theo thời gian. Nếu giảm có thể sẽ gây lỗi
        /// </summary>
        public int MaximumTaskCount
        {
            //Phương thức dùng để lấy số Task tối đa chạy
            get
            { return MaxTaskInATime; }
            set
            {
                //Kiểm tra khi khi khởi tạo có số lượng Task đi kèm
                if (value < 1)
                    throw new ArgumentOutOfRangeException();

                //Vì có nhiều luồng có thể gán số này cùng lúc nên phải khóa lại cẩn thận
                Interlocked.Exchange(ref MaxTaskInATime, value);
            }
        }

        /// <summary>
        /// Trả về số Task đang chạy
        /// </summary>
        public int RunningTaskCount
        { get { return TaskQueuedOrRunning; } }

        /// <summary>
        /// Trả về số Task đang đợi lượt chạy
        /// </summary>
        public int WaitingTaskCount
        { get { return TaskWaitting; } }

        protected sealed override void QueueTask(Task task)
        {
            lock (LinkedTasks)
            {
                //Khi có một Task mới được thêm vào thì vào dòng cuối của hàng đợi
                LinkedTasks.AddLast(task);

                //Tăng số Task đang đợi, sẽ được giảm kèm khi có 1 Task chạy
                ++TaskWaitting;

                //Nếu số Task đang chạy vẫn còn ít hơn tổng số Task đăng ký thì chạy thêm 1 Task
                if (TaskQueuedOrRunning < MaxTaskInATime)
                {
                    //Tăng số Task đang chạy
                    ++TaskQueuedOrRunning;

                    //Thông báo đến hệ thống là còn trống chỗ chạy thêm Task
                    NotifyThreadPoolOfPendingWork();
                }
            }
        }

        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                IsThreadBusy = true;
                try
                {
                    while (true)
                    {
                        Task? item;
                        lock (LinkedTasks)
                        {
                            //Một số điều kiện ràng buộc chắc chắn an toàn dữ liệu rằng không có thông báo Task chưa chạy giả
                            if (LinkedTasks.Count == 0)
                            {
                                --TaskQueuedOrRunning;
                                break;
                            }

                            //Nhận được thông báo thì lấy Task trên cùng hàng đợi ra chạy
                            item = LinkedTasks.First?.Value;

                            //Xóa nó khỏi hàng đợi
                            LinkedTasks.RemoveFirst();

                            //Trừ đi một Task đợi vì đã có 1 Task đang chạy đã xong sẽ nâng 1 Task đang đợi lên
                            --TaskWaitting;
                        }

                        //Chạy Task được lấy ra đó
                        if (item != null)
                            base.TryExecuteTask(item);
                    }
                }
                finally { IsThreadBusy = false; }
            }, null);
        }

        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            //Các phương thức kế thừa từ lớp TaskScheduler
            if (!IsThreadBusy) return false;

            if (taskWasPreviouslyQueued)
                if (TryDequeue(task)) return base.TryExecuteTask(task);
                else return false;
            else return base.TryExecuteTask(task);
        }

        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            //Các phương thức kế thừa từ lớp TaskScheduler
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(LinkedTasks, ref lockTaken);
                if (lockTaken) return LinkedTasks;
                else throw new NotSupportedException();
            }
            finally
            { if (lockTaken) Monitor.Exit(LinkedTasks); }
        }

        protected sealed override bool TryDequeue(Task task)
        {
            //Các phương thức kế thừa từ lớp TaskScheduler
            lock (LinkedTasks)
            {
                if (LinkedTasks.Remove(task))
                {
                    --TaskWaitting;
                    return true;
                }
                return false;
            }
        }
    }
}