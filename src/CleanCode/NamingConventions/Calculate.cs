namespace NamingConventions;

// Nazwa klasy powinna być rzeczownikiem
// Powinna jasno określać przeznaczenie klasy - do czego służy
public class SalaryCalculator
{
    // Nazwa metody powinna być czasownikiem
    public decimal GetBaseSalary()
    {
        throw new NotImplementedException();
    }

    // Nazwa metody powinna opisywać co robi
    public decimal CalculateSalary()
    {
        // Implementacja metody obliczającej wynagrodzenie
        var result = GetBaseSalary() + 100;

        return result;
    }

    public void IncrementSalary(decimal amount)
    {
        throw new NotImplementedException();
    }

}

// Abstract
public interface ISender
{
    void Send(decimal salary);
}

// Concrete A
public class EmailSender : ISender
{
    public void Send(decimal salary)
    {
        SendByEmail(salary);
    }

    private static void SendByEmail(decimal salary)
    {
        Console.WriteLine($"Send email with salary {salary}");
    }
}

// Concrete B
public class XSender : ISender
{
    public void Send(decimal salary)
    {
        SendByX(salary);
    }

    private static void SendByX(decimal salary)
    {
        Console.WriteLine($"Send X (twiter) with salary {salary}");
    }


}

// Concrete C
public class SmsSender : ISender
{
    public void Send(decimal salary)
    {
        SendBySms(salary);
    }

    private static void SendBySms(decimal salary)
    {
        Console.WriteLine($"Send sms with salary {salary}");
    }
}

// Nazwa klas i interfejsów powinny być rzeczownikiem

// Abstract
public interface IValidator
{
    bool Validate(string content);
}


// Concrete A
public class EmailValidator : IValidator
{
    // Metoda powinna być czasownikiem
    public bool Validate(string email)
    {
        // Implementacja metody walidującej email
        throw new NotImplementedException();
    }
}

// Concrete B
public class PeselValidator : IValidator
{
    public bool Validate(string pesel) { throw new NotImplementedException(); }
}
