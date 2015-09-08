using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WoFlo.Core.Helpers
{
    public static class Retry
    {
        public static void Do(Action action, TimeSpan retryInterval, int retryCount = 3)
        {
            Do<object>(() => { action(); return null; }, retryInterval, retryCount);
        }

        public static T Do<T>(Func<T> action, TimeSpan retryInterval, int retryCount = 3)
        {
            var exceptions = new List<Exception>();
            for (int retry = 0; retry < retryCount; retry++)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    Thread.Sleep(retryInterval);
                }
            }
            throw new AggregateException(exceptions);
        }

        public static void DoWithFix(Func<Task> action, Func<Task> fix, TimeSpan retryInterval, int retryCount = 3)
        {
            var exceptions = new List<Exception>();
            var success = false;
            for (int retry = 0; retry < retryCount; retry++)
            {
                try
                {
                    action.Invoke().Wait();
                    success = true;
                    break;
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    fix.Invoke().Wait();
                    Thread.Sleep(retryInterval);
                }
            }
            if (!success)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}