namespace Multi_Tasking.Modules
{
    /// <summary>
    /// Xếp hàng chờ đợi thực hiện nhiều Task tại một thời điểm
    /// </summary>
    public class QueueTask
    {
        private readonly CancellationTokenSource cts = new();
        private readonly SemaphoreSlim semaphore;

        /// <summary>
        /// Đăng ký với hệ thống sẽ chạy bao nhiêu Task tại một thời điểm
        /// </summary>
        /// <param name="maxDegreeOfParallelism">Số Task chạy tại một thời điểm</param>
        public QueueTask(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism <= 0)
            { throw new ArgumentOutOfRangeException(nameof(maxDegreeOfParallelism)); }

            semaphore = new SemaphoreSlim(maxDegreeOfParallelism, maxDegreeOfParallelism);
        }

        /// <summary>
        /// Nạp vào một Task để xếp hàng
        /// </summary>
        /// <param name="lambda">Một biểu thức lambda</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public Task Run(Func<Task> lambda, CancellationToken cancellationToken = default)
        {
            var _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, cts.Token);
            TaskCompletionSource<object> tcs = new();
            Task.Run(async () =>
            {
                await semaphore.WaitAsync(_cts.Token).ConfigureAwait(false);
                try
                {
                    await lambda().ConfigureAwait(false);
                    tcs.TrySetResult(true);
                }
                catch (OperationCanceledException ex)
                { tcs.TrySetCanceled(ex.CancellationToken); }
                catch (Exception ex)
                { tcs.TrySetException(ex); }
                finally
                { semaphore.Release(1); }
            }, default);

            return tcs.Task;
        }

        /// <summary>
        /// Nạp vào một Task và đợi Task nạp vào được chạy rồi mới thực hiện tiếp việc khác
        /// </summary>
        /// <param name="lambda">Biểu thức lambda</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task RunAsync(Func<Task> lambda, CancellationToken cancellationToken = default)
        {
            using var _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, cts.Token);
            await semaphore.WaitAsync(_cts.Token).ConfigureAwait(false);
            try
            { await lambda().ConfigureAwait(false); }
            finally
            { semaphore.Release(1); }
        }
    }
}