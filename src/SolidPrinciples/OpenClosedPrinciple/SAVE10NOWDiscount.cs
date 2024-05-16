

// Concrete Strategy C
public class SAVE10NOWDiscount : IDiscount
{
    private readonly decimal percentage = 0.1m;

    public decimal Discount(Order order)
    {
        if (order.Coupon == "SAVE10NOW")
        {
            return order.TotalAmount * percentage;
        }
        
        return decimal.Zero;
    }
}

