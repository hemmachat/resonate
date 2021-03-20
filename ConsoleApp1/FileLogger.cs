using System;
using System.IO;

namespace ConsoleApp1
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText($"logfile{DateTime.Now:yyyy-mm-dd}.log", message);
        }
    }
}