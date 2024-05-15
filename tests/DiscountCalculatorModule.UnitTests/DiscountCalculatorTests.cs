namespace DiscountCalculatorModule.UnitTests;

public class DiscountCalculatorTests
{
    // Method_Scenario_ExpectedBehavior

    // Method_WhenScenario_ShouldExpectedBehavior

    // Method_ShouldExpectedBehavior_WhenScenario


    [Fact]
    public void CalculateDiscount_EmptyDiscountCode_ShouldReturnsPrice()
    {
        // Arange
        DiscountCalculator discountCalculator = new DiscountCalculator();

        // Act
        var result = discountCalculator.CalculateDiscount(1, string.Empty);

        // Assert
        Assert.Equal(1, result);
    }
}