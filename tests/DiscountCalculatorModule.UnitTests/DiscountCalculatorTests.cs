namespace DiscountCalculatorModule.UnitTests;

public class DiscountCalculatorTests
{
    // Method_Scenario_ExpectedBehavior

    // Method_WhenScenario_ShouldExpectedBehavior

    // Method_ShouldExpectedBehavior_WhenScenario

    // SUT = System Under Test

    [Fact]
    public void CalculateDiscount_WhenDiscountCodeIsEmpty_ShouldReturnsPrice()
    {
        // Arange
        DiscountCalculator sut = new DiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(1, string.Empty);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void CalculateDiscount_WhenDiscountCodeIsSAVE10NOW_ShouldReturnsDiscountedPriceBy10Percentage()
    {
        // Arrange
        DiscountCalculator sut = new DiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(100, "SAVE10NOW");

        // Assert
        Assert.Equal(90, result);
    }

    [Fact]
    public void CalculateDiscount_WhenDiscountCodeIsDISCOUNT20OFF_ShouldReturnsDiscountedPriceBy20Percentage()
    {
        // Arrange
        DiscountCalculator sut = new DiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(100, "DISCOUNT20OFF");

        // Assert
        Assert.Equal(80, result);
    }

    [Fact]
    public void CalculateDiscount_WhenPriceIsNegative_ShouldThrowsArgumentException()
    {
        // Arrange
        DiscountCalculator sut = new DiscountCalculator();

        // Act
        Action act = () => sut.CalculateDiscount(-1, string.Empty);

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Negatives not allowed", exception.Message);

    }

    [Fact]
    public void CalculateDiscount_WhenDiscountCodeIsInvalid_ShouldThrowsArgumentException()
    {
        // Arrange
        var sut = new DiscountCalculator();

        // Act
        Action act = () => sut.CalculateDiscount(1, "a");

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Invalid discount code", exception.Message);
    }
}