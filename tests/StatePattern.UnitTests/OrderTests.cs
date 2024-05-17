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
        Assert.IsType<PendingOrderState>(sut.State);
    }

    [Fact]
    public void SetSate_WhenPassProcessing_ShouldStatusSetProccesing()
    {
        // Arrange
        Order sut = new Order();
        ProcessingOrderState orderStatus = new ProcessingOrderState(sut);

        // Act
        sut.SetSate(orderStatus);

        // Assert
        Assert.IsType<ProcessingOrderState>( sut.State);
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
        Assert.IsType<ProcessingOrderState>(sut.State);
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
        Assert.IsType<CompletedOrderState>(sut.State);
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

    [Fact]
    public void Cancel_WhenOrderStatusPending_ShouldSetCanceledOrderStatus()
    {
        // Arrange        
        Order sut = new Order();
        PendingOrderState orderState = new PendingOrderState(sut);
        sut.SetSate(orderState);
        
        // Act
        sut.Cancel();

        // Assert
        Assert.IsType<CanceledOrderState>(sut.State);
    }

    public void Cancel_WhenOrderStatusProcessing_ShouldSetCanceledOrderStatus()
    {
        // Arrange        
        Order sut = new Order();
        ProcessingOrderState orderState = new ProcessingOrderState(sut);
        sut.SetSate(orderState);

        // Act
        sut.Cancel();

        // Assert
        Assert.IsType<CanceledOrderState>(sut.State);
    }

  


    [Fact]
    public void Cancel_WhenOrderCompletedStatus_ShouldThrowInvalidOperationException()
    {
        // Arrange        
        Order sut = new Order();
        CompletedOrderState orderState = new CompletedOrderState(sut);
        sut.SetSate(orderState);

        // Act
        Action act = () => sut.Cancel();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Cancel_WhenOrderCanceledStatus_ShouldThrowInvalidOperationException()
    {
        // Arrange        
        Order sut = new Order();
        CanceledOrderState orderState = new CanceledOrderState(sut);
        sut.SetSate(orderState);

        // Act
        Action act = () => sut.Cancel();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

}

