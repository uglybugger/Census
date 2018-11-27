using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Census.Client
{
    internal class RateLimiter : IDisposable
    {
        private readonly int _bucketSize;
        private readonly Timer _timer;
        private readonly SemaphoreSlim _bucket;

        public RateLimiter(int bucketSize, TimeSpan replenishInterval)
        {
            _bucketSize = bucketSize;
            _bucket = new SemaphoreSlim(_bucketSize);

            _timer = new Timer(replenishInterval.TotalMilliseconds);
            _timer.Elapsed += OnTimerElapsed;
            _timer.Enabled = true;
        }

        public async Task Wait()
        {
            await _bucket.WaitAsync();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (_bucket.CurrentCount < _bucketSize) _bucket.Release();
            }
            catch (SemaphoreFullException)
            {
                // A race condition must have occurred between when we checked the capacity and when we released. Ignore.
            }
            finally
            {
                _timer.Enabled = true;
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _bucket?.Dispose();
        }
    }
}