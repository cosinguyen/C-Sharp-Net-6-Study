using Multi_Tasking.Modules;

Console.WriteLine("Multi-Tasking Test. Press anykey !!!");
Console.ReadKey();

//Chạy thử Đa luồng nhiệm vụ đơn
//OneTask();
//Console.WriteLine("Single task on Multi-Tasking test completed");
//Console.ReadKey();


//Chạy thử Đa luồng nhiều nhiệm vụ cùng lúc
MultiTaskAsync();
Console.WriteLine("Multi-Tasking test completed");
Console.ReadKey();


//Đa luồng nhiệm vụ đơn
void OneTask()
{
    ExecutionQueue queue = new();

    //Giao 3 công việc, mỗi công việc là đếm từ 1 đến 10
    for (int i = 1; i <= 3; i++)
    {
        int task = i;
        Console.WriteLine($"Complete handover of Task {task}");
        queue.Run(async () =>
        {
            Console.WriteLine($"#Start Task {task}");
            for (int e = 1; e <= 10; e++)
            {
                //Mỗi lần đếm cách nhau 1 giây
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine($"Count: {e} --- Task: {task} ---- ThreadID: {Environment.CurrentManagedThreadId}");
            }
            Console.WriteLine($"#End Task {task}");
        });

        //Mỗi lần bàn giao công việc nghỉ 5 giây
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }
}

//Chạy thử Đa luồng nhiều nhiệm vụ cùng lúc
void MultiTaskAsync()
{
    //Đăng ký 2 luồng sẽ chạy cùng lúc
    TaskTogether lcts = new(2);

    //Khởi tạo TaskFactory và gán lớp TaskTogether kế thừa từ lớp TaskScheduler
    TaskFactory factory = new(lcts);

    //Giao 4 công việc, mỗi công việc là đếm số từ 1 đến 5 tăng dần số bằng số Task, mục đích kéo dài thời gian để xem TaskTogether hoạt động
    for (int i = 1; i <= 4; i++)
    {
        int task = i;
        Console.WriteLine($"Complete handover of Task {task}");
        factory.StartNew(async () =>
        {
            Console.WriteLine($"#Start Task {task}");
            for (int e = 1; e <= (5 * task); e++)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine($"Count: {e} --- Task: {task} ---- ThreadID: {Environment.CurrentManagedThreadId}");
            }
            Console.WriteLine($"#End Task {task}");
        });

        //Mỗi lần bàn giao công việc nghỉ 5 giây
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }
}