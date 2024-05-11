
Console.WriteLine("Hello, Open/Closed Principle (OCP)");


public class OrderCalculator
{
    public decimal CalculateDiscount(Order order)
    {
        if (order.OrderDate.Hour >= 9 && order.OrderDate.Hour <= 12)
        {
            return order.TotalAmount * 0.1m; // 10% 
        }
        if (order.Customer.Gender == Gender.Female)
        {
            return order.TotalAmount * 0.2m; // 20% 
        }
        else
            return order.TotalAmount;

        // TODO: dodaj obsługę kuponów rabatowych SAVE10NOW, DISCOUNT20OFF
    }
}

public class Order
{
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public Customer Customer { get; set; }
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

