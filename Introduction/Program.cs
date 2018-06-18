using System;
using System.Threading;

namespace Introduction
{
    internal static class Program
    {
        private static void Main()
        {
            var print = new Print("Good!");
            var thread = new Thread(print.Run);
            thread.Start();
        }
    }

    internal class Print
    {
        private readonly string _message;

        public Print(string message)
        {
            _message = message;
        }

        public void Run()
        {
            for (var i = 0; i < 10000; i++)
            {
                Console.WriteLine(_message);
            }
        }
    }
}