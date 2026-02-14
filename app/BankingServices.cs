namespace ATMApp.Services
{
    public class BankingServices
{
    private double balance;
    private double lastTransAmt;

    public BankingServices(ref double balance, ref double lastTransAmt)
    {
        this.balance = balance;
        this.lastTransAmt = lastTransAmt;
    }

    // Check Balance
    public void CheckBalance()
    {
        Console.WriteLine($"Current Balance: ₱{balance}");
    }

    // Deposit Money 
    public bool Deposit()
{
    Console.Write("Enter amount to deposit: ");
    
    if (double.TryParse(Console.ReadLine(), out double depositAmount) && depositAmount > 0)
    {
        // Successful deposit
        balance += depositAmount;
        lastTransAmt = depositAmount;
        Console.WriteLine($"Deposit successful. Updated Balance: ₱{balance}");
        
        return true; // Deposit successful
    }
    else
    {
        // Invalid deposit amount
        Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
        
        return false; // Deposit failed
    }
}

public void Withdraw()
{
    Console.Write("Enter amount to withdraw: ");
    if (double.TryParse(Console.ReadLine(), out double withdrawAmount) && withdrawAmount > 0)
    {
        if (balance >= withdrawAmount)
        {
            balance -= withdrawAmount;
            lastTransAmt = -withdrawAmount;
            Console.WriteLine($"Withdrawal successful. Updated Balance: ₱{balance}");
        }
        else
        {
            Console.WriteLine("Withdrawal failed. Insufficient balance.");
        }
    }
    else
    {
        Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
    }
}

    // Show Mini Statement
    public void ShowMiniStatement()
    {
        Console.WriteLine("--- Mini Statement ---");
        Console.WriteLine($"Current Balance: ₱{balance}");
        Console.WriteLine($"Last Transaction Amount: ₱{lastTransAmt}");
    }

    // Exit the ATM System
    public void Exit()
    {
        Console.WriteLine("Thank you for using the ATM. Goodbye!");
    }
}

}
