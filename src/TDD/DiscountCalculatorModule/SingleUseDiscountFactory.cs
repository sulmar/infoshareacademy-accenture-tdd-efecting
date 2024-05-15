namespace DiscountCalculatorModule;

// Proxy Pattern
public class SingleUseDiscountFactoryProxy : IDiscountFactory
{
    private Dictionary<string, decimal> discountCodes = [];

    private readonly IDiscountFactory _discountFactory;

    public SingleUseDiscountFactoryProxy(IDiscountFactory discountFactory)
    {
        _discountFactory = discountFactory;

        discountCodes = new Dictionary<string, decimal>()
        {
            ["ABC"] = 0.5m,
        };        
    }

    public decimal Create(string discountCode)
    {
        if (string.IsNullOrEmpty(discountCode))
            return 0;

        if (discountCodes.TryGetValue(discountCode, out var discount))
        {
            discountCodes.Remove(discountCode);
            return discount;
        }
        else
            // Real Subject
            return _discountFactory.Create(discountCode);


    }
}
