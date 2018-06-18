using System;

namespace Introduction
{
    public class Bank
    {
        public Bank(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public void Deposit(int m)
        {
            Money += m;
        }

        public bool Withdraw(int m)
        {
            if (Money < m) return false;
            
            Money -= m;
            Check();
            return true;

        }

        private void Check()
        {
            if (Money < 0)
            {
                Console.WriteLine($"Balance is negative! Money={Money}");
            }
        }

        public int Money { get; private set; }

        public string Name { get; private set; }
    }
}