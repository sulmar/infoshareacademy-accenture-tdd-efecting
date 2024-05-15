namespace DiscountCalculatorModule;

// Fabryka 
public class PernamentDiscountFactory : IDiscountFactory
{ 
    private Dictionary<string, decimal> discountCodes = [];

    public PernamentDiscountFactory()
    {
        discountCodes = new()
        {
            ["SAVE10NOW"] = 0.1m,
            ["DISCOUNT20OFF"] = 0.2m,
            
        };
    }

    public decimal Create(string discountCode) 
    {
        if (string.IsNullOrEmpty(discountCode))
            return 0;

        if (discountCodes.TryGetValue(discountCode, out var discount))
        {
            return discount;
        }
        else
            throw new ArgumentException("Invalid discount code");
    }
}
