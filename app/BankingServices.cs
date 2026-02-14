namespace ATMApp.Services
{
    public static class BankingServices
    {
        public static double GetBalance(double balance)
        {
            return balance;
        }

        public static bool Deposit(ref double balance, double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposit successful. Updated Balance: ₱{balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
                return false;
            }
        }

        public static void Withdraw(ref double balance, double amount, out bool isSuccessful)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
                isSuccessful = true;
                Console.WriteLine($"Withdrawal successful. Updated Balance: ₱{balance}");
            }
            else
            {
                isSuccessful = false;
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
                }
                else
                {
                    Console.WriteLine("Withdrawal failed. Insufficient balance.");
                }
            }
        }
    }
}
