namespace ATMApp.Services
{
    public static class BankingServices
    {
        
        private static double _lastTransactionAmount = 0.00;

       
        public static double GetBalance(double balance)
        {
            return balance;
        }

        public static bool Deposit(ref double balance, double amount)
        {
            if (amount <= 0)
                return false;

            balance += amount;
            _lastTransactionAmount = amount;
            return true;
        }

        public static void Withdraw(
            ref double balance,
            double amount,
            out bool isSuccessful)
        {
            isSuccessful = false;

            if (amount <= 0)
                return;

            if (amount > balance)
                return;

            balance -= amount;
            _lastTransactionAmount = amount;
            isSuccessful = true;
        }

        public static double GetLastTransaction()
        {
            return _lastTransactionAmount;
        }
    }
}
