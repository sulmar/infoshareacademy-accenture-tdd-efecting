namespace DiscountCalculatorModule;

public class DiscountCalculator
{

    private Dictionary<string, decimal> discountCodes = [];

    public DiscountCalculator()
    {
        discountCodes = new()
        {
            ["SAVE10NOW"] = 0.1m,
            ["DISCOUNT20OFF"] = 0.2m,
        };
    }


    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0) throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrEmpty(discountCode))
            return price;

        if (discountCodes.TryGetValue(discountCode, out var discount))
        {
            return price - price * discount;
        }
        else
            throw new ArgumentException("Invalid discount code");
    }
}
