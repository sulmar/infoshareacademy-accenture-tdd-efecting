namespace MagicNumbers;

public class Order
{
    public decimal TotalAmount { get; set; }
    public OrderStatus OrderStatus { get; set; }

    private const decimal DiscountRatePercentage = 0.1m; // 10%

    public decimal ApplyDiscount()
    {
        // Magiczna liczba 0.1
        return TotalAmount - TotalAmount * DiscountRatePercentage;
    }
}


public class OrderService
{
    public void Process(Order order)
    {
        switch (order.OrderStatus)
        {
            case OrderStatus.Pending:
                break;
            case OrderStatus.Processing:
                break;
            case OrderStatus.Completed:
                break;

            default:
                throw new NotSupportedException();
        }
    }
}

public enum OrderStatus { Pending, Processing, Completed }