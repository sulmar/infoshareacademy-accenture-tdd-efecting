namespace DiscountCalculatorModule;

public class DiscountCalculator
{
    DiscountFactory discountFactory;

    public DiscountCalculator()
    {
        discountFactory = new DiscountFactory();
    }


    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0) throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrEmpty(discountCode))
            return price;

       var discount = discountFactory.Create(discountCode);

        return price - price * discount;
    }
}

// Fabryka 
public class DiscountFactory
{
    private Dictionary<string, (decimal discount, bool isPernament)> discountCodes = [];

    public DiscountFactory()
    {
        discountCodes = new()
        {
            ["SAVE10NOW"] = (0.1m, true),
            ["DISCOUNT20OFF"] = (0.2m, true),
            ["ABC"] = (0.5m, false),
        };
    }

    public decimal Create(string discountCode) 
    {
        if (discountCodes.TryGetValue(discountCode, out var discount))
        {
            if (!discount.isPernament)
                discountCodes.Remove(discountCode);

            return discount.discount;
        }
        else
            throw new ArgumentException("Invalid discount code");
    }
}
