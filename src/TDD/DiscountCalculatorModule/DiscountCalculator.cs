namespace DiscountCalculatorModule;

public class DiscountCalculator
{

    private Dictionary<string, (decimal discount, bool isPernament)> discountCodes = [];

    public DiscountCalculator()
    {
        discountCodes = new()
        {
            ["SAVE10NOW"] = (0.1m, true),
            ["DISCOUNT20OFF"] = (0.2m, true),
            ["ABC"] = (0.5m, false),
        };
    }


    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0) throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrEmpty(discountCode))
            return price;

        if (discountCodes.TryGetValue(discountCode, out var discount))
        {
            if (!discount.isPernament)
                discountCodes.Remove(discountCode);

            return price - price * discount.discount;
        }
        else
            throw new ArgumentException("Invalid discount code");
    }
}
