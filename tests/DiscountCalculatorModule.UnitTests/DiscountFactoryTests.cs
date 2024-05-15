namespace DiscountCalculatorModule.UnitTests;

public class DiscountFactoryTests
{
    [Fact]
    public void Create_WhenFirstUseDiscountCode_ShouldReturnDiscount50Percentage()
    {
        // Arrange
        var sut = new SingleUseDiscountFactoryProxy(new PernamentDiscountFactory());

        // Act
        var result = sut.Create("ABC");

        // Assert
        Assert.Equal(0.5m, result);
    }

    [Fact]
    public void Create_WhenSecondUseDiscountCode_ShouldThrowArgumentException()
    {
        // Arrange
        var sut = new SingleUseDiscountFactoryProxy(new PernamentDiscountFactory());
        sut.Create("ABC");

        // Act
        Action act = () => sut.Create("ABC");

        // Assert
        Assert.Throws<ArgumentException>(act);


    }

    [Fact]
    public void Create__WhenDiscountCodeIsEmpty_ShouldReturnDiscountZeroPercentage()
    {
        // Arrange
        var sut = new PernamentDiscountFactory();

        // Act
        var result = sut.Create(string.Empty);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void CalculateDiscount_WhenHasDiscountCodeSAVE10NOW_ShouldReturnDiscount10Percentage()
    {
        // Arrange
        var sut = new PernamentDiscountFactory();


        // Act
        var result = sut.Create("SAVE10NOW");

        // Assert
        Assert.Equal(0.1m, result);
    }

    [Fact]
    public void CalculateDiscount_WhenHasDiscountCodeDISCOUNT20OFF_ShouldReturnDiscount20Percentage()
    {
        // Arrange
        var sut = new PernamentDiscountFactory();


        // Act
        var result = sut.Create("DISCOUNT20OFF");

        // Assert
        Assert.Equal(0.2m, result);
    }

}