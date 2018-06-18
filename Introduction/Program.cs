using System;
using System.Threading;
using System.Threading.Tasks;

namespace Introduction
{
    internal static class Program
    {
        private static void Main()
        {
//            PrintSample();
            BankSample();
        }

        /// <summary>
        /// Sample: Thread vs Async
        /// </summary>
        private static void PrintSample()
        {
            // Thread
            new Thread(PrintThread).Start();

            // Async
            Task.Run(PrintAsync);
        }

        /// <summary>
        /// Sample: Without lock, multi thread programs can be broken.
        /// </summary>
        private static void BankSample()
        {
            var bank = new Bank("Mizuho", 1000);

            // Thread
//            new Thread(() => WithdrawAndDeposit(bank)).Start();
//            new Thread(() => WithdrawAndDeposit(bank)).Start();

            // Async
            var tasks = new[]
            {
                Task.Run(() => WithdrawAndDeposit(bank)),
                Task.Run(() => WithdrawAndDeposit(bank))
            };
            Task.WaitAll(tasks);
        }

        private static void WithdrawAndDeposit(Bank bank)
        {
            while (true)
            {
                Console.WriteLine(bank.Money);
                var ok = bank.Withdraw(1000);
                if (ok)
                {
                    bank.Deposit(1000);
                }
            }
        }

        private static void PrintThread()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread!");
                Thread.Sleep(500);
            }
        }

        private static async Task PrintAsync()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Async!");
                await Task.Delay(500);
            }
        }
    }
}