using ATMApp.Services;

namespace ATMApp.View
{
    public static class BankingView
    {
        public static void Run()
        {
            double balance = 1000.00;

            Console.WriteLine("=== Simple ATM System ===");
            Console.WriteLine("Name: Your Name Here");
            Console.WriteLine($"Initial Balance: ₱{balance:F2}");

            while (true)
            {
                Console.WriteLine("\n===== ATM Menu =====");
                Console.WriteLine("1: Check Balance");
                Console.WriteLine("2: Deposit Money");
                Console.WriteLine("3: Withdraw Money");
                Console.WriteLine("4: Print Mini Statement");
                Console.WriteLine("5: Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        double currentBalance = BankingServices.GetBalance(balance);
                        Console.WriteLine($"Current Balance: ₱{currentBalance:F2}");
                        break;

                    case "2":
                        Console.Write("Enter amount to deposit: ");
                        if (!double.TryParse(Console.ReadLine(), out double depositAmount))
                        {
                            Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
                            continue;
                        }

                        if (depositAmount <= 0)
                        {
                            Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
                            continue;
                        }

                        bool depositSuccess = BankingServices.Deposit(ref balance, depositAmount);

                        if (depositSuccess)
                        {
                            Console.WriteLine("Deposit successful.");
                            Console.WriteLine($"Updated Balance: ₱{balance:F2}");
                        }
                        break;

                    case "3":
                        Console.Write("Enter amount to withdraw: ");
                        if (!double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
                            continue;
                        }

                        if (withdrawAmount <= 0)
                        {
                            Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
                            continue;
                        }

                        BankingServices.Withdraw(ref balance, withdrawAmount, out bool isSuccessful);

                        if (isSuccessful)
                        {
                            Console.WriteLine("Withdrawal successful.");
                            Console.WriteLine($"Updated Balance: ₱{balance:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Withdrawal failed. Insufficient balance.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("--- Mini Statement ---");
                        Console.WriteLine($"Current Balance: ₱{balance:F2}");
                        Console.WriteLine($"Last Transaction Amount: ₱{BankingServices.GetLastTransaction():F2}");
                        break;

                    case "5":
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        break;
                }
            }
        }
    }
}
