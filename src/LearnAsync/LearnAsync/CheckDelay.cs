using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearnAsync
{
    public class SimpleCheckAsync
    {
        public void Check()
        {
            Console.WriteLine($"\n {DateTime.Now} Start check!");
            LongRunningMethod();
            Console.WriteLine($"\n {DateTime.Now} Wait!");
            Task.Delay(TimeSpan.FromSeconds(3)).Wait();
            Console.WriteLine($"\n {DateTime.Now} Stop check!");
        }

        public async Task CheckAsync()
        {
            Console.WriteLine($"\n {DateTime.Now} {Thread.CurrentThread.ManagedThreadId}  Start check async!");
            var taskLongRuning = LongRunningMethodAsync();
            Console.WriteLine($"\n {DateTime.Now} {Thread.CurrentThread.ManagedThreadId}  Wait!");
            await taskLongRuning;
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine($"\n {DateTime.Now} {Thread.CurrentThread.ManagedThreadId}  Stop check async!");
        }

        public async Task CheckTaskFactory()
        {
            Console.WriteLine($"\n {DateTime.Now} {Thread.CurrentThread.ManagedThreadId}  Start check async!");
            var taskLongRunning = Task.Factory.StartNew(LongRunningMethodAsync);
            Console.WriteLine($" {DateTime.Now} {Thread.CurrentThread.ManagedThreadId}  Wait!");
            await taskLongRunning;
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine($"\n {DateTime.Now} {Thread.CurrentThread.ManagedThreadId}  Stop check async!");
        }

        private void LongRunningMethod()
        {
            Console.Write($"\n {DateTime.Now} {Thread.CurrentThread.ManagedThreadId} Long running method start");
            Task.Delay(TimeSpan.FromSeconds(3)).Wait();
            Console.Write($"\n {DateTime.Now} {Thread.CurrentThread.ManagedThreadId} Long running method stop");
        }

        private async Task LongRunningMethodAsync()
        {
            Console.Write($"\n {DateTime.Now} {Thread.CurrentThread.ManagedThreadId} Long running method start");
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.Write($"\n {DateTime.Now} {Thread.CurrentThread.ManagedThreadId} Long running method stop");
        }

    }
}
