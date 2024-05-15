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
}