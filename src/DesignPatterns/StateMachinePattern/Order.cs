namespace StateMachinePattern;

// Wzorzec Proxy
// wariant klasowy
public class OrderProxy : Order
{
    public OrderProxy(OrderStatus orderStatus = OrderStatus.Pending)
        : base(orderStatus)
    {        
    }


    public override OrderStatus Status => base.Status;

    public override void Confirm()
    {
        base.Confirm();
    }

    public override void Cancel()
    {
        base.Cancel();
    }
}

public class Order
{
    public Order(OrderStatus initialState = OrderStatus.Pending)
    {
        Status = initialState;
    }

    public virtual OrderStatus Status { get; private set; }
    public bool IsPaid { get; private set; }

    public void Paid()
    {
        IsPaid = true;
    }

    public virtual void Confirm()
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

    public virtual void Cancel()
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
