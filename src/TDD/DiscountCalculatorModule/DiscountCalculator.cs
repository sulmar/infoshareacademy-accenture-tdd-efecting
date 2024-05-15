namespace DiscountCalculatorModule;

public class DiscountCalculator
{
    private readonly PernamentDiscountFactory _discountFactory;

    public DiscountCalculator(PernamentDiscountFactory discountFactory)
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
