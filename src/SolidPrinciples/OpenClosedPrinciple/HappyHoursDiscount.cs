

// Concrete Strategy A
public class HappyHoursDiscount : IDiscount
{
    private readonly TimeSpan from;
    private readonly TimeSpan to;

    private readonly decimal percentage = 0.1m;

    public HappyHoursDiscount(TimeSpan from, TimeSpan to, decimal percentage)
    {
        this.from = from;
        this.to = to;
        this.percentage = percentage;
    }

    public decimal Discount(Order order)
    {
        // Happy Hours
        if (order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay <= to)
        {
            return order.TotalAmount * percentage; // 10% 
        }

        return decimal.Zero;
    }
}

