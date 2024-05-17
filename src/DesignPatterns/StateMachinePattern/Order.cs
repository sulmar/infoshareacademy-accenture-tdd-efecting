using Stateless;

namespace StateMachinePattern;

// dotnet add package Stateless

// Wzorzec Proxy
// wariant klasowy
public class OrderProxy : Order
{
    private readonly StateMachine<OrderStatus, OrderTrigger> _machine; 

    public OrderProxy(OrderStatus orderStatus = OrderStatus.Pending)
        : base(orderStatus)
    {
        _machine = new StateMachine<OrderStatus, OrderTrigger>(orderStatus);

        _machine.Configure(OrderStatus.Pending)
            .PermitIf(OrderTrigger.Confirm, OrderStatus.Processing, ()=>IsPaid)
            .Permit(OrderTrigger.Cancel, OrderStatus.Canceled);

        _machine.Configure(OrderStatus.Processing)
            .Permit(OrderTrigger.Confirm, OrderStatus.Completed)
            .Permit(OrderTrigger.Cancel, OrderStatus.Canceled);
    }

    public override OrderStatus Status => _machine.State;

    public override void Confirm()
    {
        _machine.Fire(OrderTrigger.Confirm);
    }

    public override void Cancel()
    {
        _machine.Fire(OrderTrigger.Cancel);
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


public enum OrderTrigger
{
    Confirm,
    Cancel
}