﻿using System.Collections.Concurrent;

namespace Multi_Tasking.Modules
{
    /// <summary>
    /// Xếp hàng chờ đợi cho các Task, thực hiện 1 Task tại một thời điểm
    /// </summary>
    internal class ExecutionQueue
    {
        private readonly BlockingCollection<Func<Task>> queue = new();
        internal ExecutionQueue() => Task.Run(() => ProcessQueueAsync());
        /// <summary>
        /// Báo cho hệ thống thêm thành công và khóa không cho thêm nữa. Chỉ chạy hết các Task đã thêm trước khi gọi phương thức này.
        /// </summary>
        internal void CompleteAdding() => queue.CompleteAdding();
        private async Task ProcessQueueAsync()
        {
            foreach (var item in queue.GetConsumingEnumerable())
                await item();
        }
        /// <summary>
        /// Thêm Task vào hàng đợi
        /// </summary>
        /// <param name="lambda">Một phương thức kiểu lambda</param>
        /// <returns></returns>
        internal Task Run(Func<Task> lambda)
        {
            TaskCompletionSource<object> tcs = new();
            queue.Add(async () =>
            {
                try
                {
                    await lambda();
                    tcs.TrySetResult(true);
                }
                catch (OperationCanceledException ex)
                { tcs.TrySetCanceled(ex.CancellationToken); }
                catch (Exception ex)
                { tcs.TrySetException(ex); }
            });
            return tcs.Task;
        }
    }
}