
Console.WriteLine("Hello, Open/Closed Principle (OCP)");


// Abstract Strategy
public interface IDiscount
{
    decimal Discount(Order order);
}

public class OrderCalculator
{
    private readonly IDiscount _discount;

    public OrderCalculator(IDiscount discount)
    {
        _discount = discount;
    }

    public decimal CalculateDiscount(Order order)
    {
        return order.TotalAmount - _discount.Discount(order);

        // TODO: dodaj obsługę kuponów rabatowych SAVE10NOW, DISCOUNT20OFF

        // TODO: 10zł mniej w każdy piątek
    }
}

public class Order
{
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public Customer Customer { get; set; }
    public string Coupon { get; set; }
}

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
}


public enum Gender
{
    Male,
    Female
}

