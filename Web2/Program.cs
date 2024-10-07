using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp2
{

    internal class Program
    {
        private static Timer timer;
        static void Main(string[] args)
        {
            ReadFile();
            ProcessData();
            PerformAsyncTask();
            StartTimer();
            StartProcess();

            Console.ReadLine();
        }

        public static void ReadFile()
        {
            string path = @"D:\example.txt";

            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Console.WriteLine(content);
            }
        }

        public static void ProcessData()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

            evenNumbers.ForEach(n => Console.WriteLine(n));
        }

        public static async Task PerformAsyncTask()
        {
            Console.WriteLine("Start long-running task...");
            await Task.Delay(2000);
            Console.WriteLine("Task completed!");
        }

        public static void StartTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
        }

        public static void StartProcess()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "notepad.exe",
                Arguments = "",
                UseShellExecute = true
            };

            Process process = Process.Start(startInfo);
            Console.WriteLine("Process started: Notepad");

            process.WaitForExit();
            Console.WriteLine("Process exited.");
        }
    }
}
