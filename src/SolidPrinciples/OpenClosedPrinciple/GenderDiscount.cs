

// Concrete Strategy B
public class GenderDiscount : IDiscount
{
    private readonly decimal percentage = 0.2m;

    private readonly Gender gender;

    public GenderDiscount(Gender gender, decimal percentage)
    {
        this.percentage = percentage;
        this.gender = gender;
    }

    public decimal Discount(Order order)
    {
        // Gender
        if (order.Customer.Gender == gender)
        {
            return order.TotalAmount * percentage; // 20% 
        }

        return decimal.Zero;
    }
}

