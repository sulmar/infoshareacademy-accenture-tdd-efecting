
Console.WriteLine("Hello, Interface Segregation Principle (ISP)!");

IATM atm = new WithdrawOnlyATM(1000);

atm.Withdraw(100);

atm.Deposit(50);

atm.CheckBalance();


public interface IATM
{
    bool Withdraw(decimal amount); // Wypłata
    void Deposit(decimal amount);  // Wpłata
    decimal CheckBalance();
}

public class WithdrawAndDepositATM : IATM
{
    private decimal balance;

    public WithdrawAndDepositATM(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public decimal CheckBalance()
    {
        return balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine("Deposit successful. New Balance: " + balance);
        }
        else
        {
            Console.WriteLine("Invalid amount for deposit.");
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        else
        {
            Console.WriteLine("Insufficient funds or invalid amount.");
            return false;
        }
    }
}


public class WithdrawOnlyATM : IATM
{
    private decimal balance;

    public WithdrawOnlyATM(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public decimal CheckBalance()
    {
        return balance;
    }

    public void Deposit(decimal amount)
    {
        throw new NotSupportedException();
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        else
        {
            Console.WriteLine("Insufficient funds or invalid amount.");
            return false;
        }
    }
}
