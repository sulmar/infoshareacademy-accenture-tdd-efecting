namespace DiscountCalculatorModule;

public class DiscountCalculator
{
    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (discountCode == "")
            return price;

        throw new NotImplementedException();
    }
}
