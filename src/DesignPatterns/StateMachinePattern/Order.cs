namespace StateMachinePattern;

public class Order
{
    public Order(OrderStatus initialState = OrderStatus.Pending)
    {
        Status = initialState;
    }

    public OrderStatus Status { get; private set; }
    public bool IsPaid { get; private set; }

    public void Paid()
    {
        IsPaid = true;
    }

    public void Confirm()
    {
        if (Status == OrderStatus.Pending)
        {
            if (IsPaid)
            {
                Status = OrderStatus.Processing;
            }
            else
                throw new InvalidOperationException();
        }
        else if (Status == OrderStatus.Processing)
        {
            Status = OrderStatus.Completed;
        }
        else
        {
            throw new InvalidOperationException();
        }

    }

    public void Cancel()
    {
        if (Status == OrderStatus.Pending)
        {
            Status = OrderStatus.Canceled;
        }
        else if (Status == OrderStatus.Processing)
        {
            Status = OrderStatus.Canceled;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public override string ToString() => $"Order {Environment.NewLine}";

}

public enum OrderStatus
{
    // The customer places an order on the company's website
    Pending,
    Processing,
    Completed,
    Canceled
}
