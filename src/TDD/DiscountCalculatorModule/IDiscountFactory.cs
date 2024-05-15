namespace DiscountCalculatorModule;

public interface IDiscountFactory
{
    decimal Create(string discountCode);
}
