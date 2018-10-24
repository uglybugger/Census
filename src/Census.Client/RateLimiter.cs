using System;
using System.Threading.Tasks;

namespace Census.Client
{
    internal class RateLimiter
    {
        public Task Wait()
        {
            return Task.Delay(TimeSpan.Zero);
        }
    }
}