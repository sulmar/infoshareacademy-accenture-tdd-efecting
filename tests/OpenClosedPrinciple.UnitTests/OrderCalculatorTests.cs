namespace OpenClosedPrinciple.UnitTests;

public class OrderCalculatorTests
{
    //  9..12

    [Fact]
    public void CalculateDiscount_WhenHappyHoursDiscount_ShouldReturnDiscountBy10Percentage()
    {
        // Arrange
        var from = TimeSpan.Parse("09:00");
        var to = TimeSpan.Parse("12:00");

        IDiscount discount = new HappyHoursDiscount(from, to, 0.1m);
        OrderCalculator sut = new OrderCalculator(discount);

        Order order = new Order { TotalAmount = 100, OrderDate = DateTime.Parse("2024-05-16 10:00") };

        // Act
        var result = sut.CalculateDiscount(order);

        // Assert
        Assert.Equal(90, result);
    }


    [Fact]
    public void CalculateDiscount_WhenNotHappyHoursDiscount_ShouldReturnWihoutDiscount()
    {
        // Arrange
        var from = TimeSpan.Parse("09:00");
        var to = TimeSpan.Parse("12:00");

        IDiscount discount = new HappyHoursDiscount(from, to, 0.1m);
        OrderCalculator sut = new OrderCalculator(discount);

        Order order = new Order { TotalAmount = 100, OrderDate = DateTime.Parse("2024-05-16 12:01") };

        // Act
        var result = sut.CalculateDiscount(order);

        // Assert
        Assert.Equal(100, result);
    }

    [Fact]
    public void CalculateDiscount_WhenGenderIsFamaleDiscount_ShouldReturnDiscountBy20Percentage()
    {
        // Arrange
        IDiscount discount = new GenderDiscount(Gender.Female, 0.2m);
        OrderCalculator sut = new OrderCalculator(discount);

        Order order = new Order { TotalAmount = 100, Customer = new Customer { Gender = Gender.Female } };

        // Act
        var result = sut.CalculateDiscount(order);

        // Assert
        Assert.Equal(80, result);

    }

    [Fact]
    public void CalculateDiscount_WhenGenderIsMaleDiscount_ShouldReturnTotalAmount()
    {
        // Arrange
        IDiscount discount = new GenderDiscount(Gender.Female, 0.2m);
        OrderCalculator sut = new OrderCalculator(discount);

        Order order = new Order { TotalAmount = 100, Customer = new Customer { Gender = Gender.Male } };

        // Act
        var result = sut.CalculateDiscount(order);

        // Assert
        Assert.Equal(100, result);

    }
}