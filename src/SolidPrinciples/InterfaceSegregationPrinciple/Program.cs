
Console.WriteLine("Hello, Interface Segregation Principle (ISP)!");

IWithdrawCommand atm = new WithdrawOnlyATM(1000);

atm.Withdraw(100);

// atm.CheckBalance();

public interface IWithdrawAndCheckBalanceCommand : IWithdrawCommand, ICheckBalanceCommand { }


public interface IATM : IWithdrawCommand, IDepositCommand, ICheckBalanceCommand
{     
}

public interface IWithdrawCommand
{
    bool Withdraw(decimal amount); // Wypłata    
}

public interface IDepositCommand
{
    void Deposit(decimal amount);  // Wpłata
}

public interface ICheckBalanceCommand
{
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


public class WithdrawOnlyATM : IWithdrawAndCheckBalanceCommand
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
