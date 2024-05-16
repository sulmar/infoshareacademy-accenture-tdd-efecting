namespace StatePattern.UnitTests;

public class OrderTests
{
    [Fact]
    public void Confirm_WhenCreate_ShouldStatusSetPending()
    {
        // Arrange

        // Act
        Order sut = new Order();

        // Assert
        Assert.Equal(OrderStatus.Pending, sut.Status);
    }

    [Fact]
    public void Confirm_WhenPassProcessing_ShouldStatusSetProccesing()
    {
        // Arrange
        OrderStatus orderStatus = OrderStatus.Processing;

        // Act
        Order sut = new Order(orderStatus);

        // Assert
        Assert.Equal(OrderStatus.Processing, sut.Status);
    }

    [Fact]
    public void Confirm_WhenIsPaidConfirm_ShouldStatusSetProcessing()
    {
        // Arrange
        Order sut = new Order();
        sut.Paid();

        // Act
        sut.Confirm();

        // Asssert
        Assert.Equal(OrderStatus.Processing, sut.Status);
    }

    [Fact]
    public void Confirm_WhenIsProcessingConfirm_ShouldStatusSetCompleted()
    {
        // Arrange
        Order sut = new Order();
        sut.Paid();
        sut.Confirm();

        // Act
        sut.Confirm();

        // Asssert
        Assert.Equal(OrderStatus.Completed, sut.Status);
    }

    [Fact]
    public void Confirm_WhenNotPaidConfirm_ShouldThrowInvalidOperationException()
    {
        // Arrange
        Order sut = new Order();

        // Act
        Action act = () => sut.Confirm();

        // Asssert
        Assert.Throws<InvalidOperationException>(act);
    }


    [Theory]
    [InlineData(OrderStatus.Pending)]
    [InlineData(OrderStatus.Processing)]
    public void Cancel_WhenOrderStatus_ShouldSetCanceledOrderStatus(OrderStatus orderStatus)
    {
        // Arrange        
        Order sut = new Order(orderStatus);

        // Act
        sut.Cancel();

        // Assert
        Assert.Equal(OrderStatus.Canceled, sut.Status);
    }


    [Theory]
    [InlineData(OrderStatus.Completed)]
    [InlineData(OrderStatus.Canceled)]
    public void Cancel_WhenOrderStatus_ShouldThrowInvalidOperationException(OrderStatus orderStatus)
    {
        // Arrange        
        Order sut = new Order(orderStatus);

        // Act
        Action act = () => sut.Cancel();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

}

