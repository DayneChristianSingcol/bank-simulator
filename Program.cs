using ATMApp.View;

using System;

public class Program
{
    public static void Main(string[] args)
    {
        double balance = 1000.00; // Initialize balance to ₱1000.00
        double lastTransAmt = 0.00; // Last transaction amount
        bool isRunning = true; // Loop control flag

        BankingServices bankingServices = new BankingServices(ref balance, ref lastTransAmt); // Create BankingServices object

        while (isRunning)
        {
            BankingView(); // Display the ATM menu
            string option = Console.ReadLine(); // Get user input
            
            // Switch-case to handle different menu options
            switch (option)
            {
                case "1":
                    bankingServices.CheckBalance();
                    break;

                case "2":
                    bankingServices.Deposit();
                    break;

                case "3":
                    bankingServices.Withdraw();
                    break;

                case "4":
                    bankingServices.ShowMiniStatement();
                    break;

                case "5":
                    bankingServices.Exit();
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid option selected. Please try again.");
                    break;
            }
        }
    }
