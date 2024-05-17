namespace StateMachinePattern.UnitTests;

public class OrderTests
{
    Order sut; 

    public OrderTests()
    {
        sut = new OrderProxy(OrderStatus.Pending);
    }

    [Fact]
    public void Confirm_WhenCreate_ShouldStatusSetPending()
    {
        // Arrange

        // Act
        Order sut = new OrderProxy();

        // Assert
        Assert.Equal(OrderStatus.Pending, sut.Status);
    }

    [Fact]
    public void Confirm_WhenPassProcessing_ShouldStatusSetProccesing()
    {
        // Arrange
        OrderStatus orderStatus = OrderStatus.Processing;

        // Act
        Order sut = new OrderProxy(orderStatus);

        // Assert
        Assert.Equal(OrderStatus.Processing, sut.Status);
    }

    [Fact]
    public void Confirm_WhenIsPaidConfirm_ShouldStatusSetProcessing()
    {
        // Arrange
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
        Order sut = new OrderProxy(orderStatus);

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
        Order sut = new OrderProxy(orderStatus);

        // Act
        Action act = () => sut.Cancel();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }
}