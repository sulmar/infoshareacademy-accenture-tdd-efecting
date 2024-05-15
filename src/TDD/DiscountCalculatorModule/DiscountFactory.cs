namespace DiscountCalculatorModule;

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
        if (string.IsNullOrEmpty(discountCode))
            return 0;

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
