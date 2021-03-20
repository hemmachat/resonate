using System;

namespace ConsoleApp1
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(string.Format(message));
        }
    }
}