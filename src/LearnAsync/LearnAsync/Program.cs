using System;

namespace LearnAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var checkDelay = new SimpleCheckAsync();

            checkDelay.Check();
            checkDelay.CheckAsync().Wait();
            checkDelay.CheckTaskFactory().Wait();

            Console.ReadLine();
        }
    }
}
