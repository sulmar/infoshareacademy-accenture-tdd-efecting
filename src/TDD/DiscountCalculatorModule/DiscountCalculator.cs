namespace DiscountCalculatorModule;

public class DiscountCalculator
{
    private readonly DiscountFactory _discountFactory;

    public DiscountCalculator(DiscountFactory discountFactory)
    {
        _discountFactory = discountFactory;
    }


    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0) throw new ArgumentException("Negatives not allowed");

        if (string.IsNullOrEmpty(discountCode))
            return price;

       var discount = _discountFactory.Create(discountCode);

        return price - price * discount;
    }
}
