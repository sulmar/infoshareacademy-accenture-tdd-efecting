using System;

namespace StatePattern;


// Abstract State
public abstract class OrderState
{
    public abstract void Confirm();
    public abstract void Cancel();
}

public class Order
{
    public Order()
    {
        State = new PendingOrderState(this);
    }

    public Order(OrderState initialState)
    {            
        State = initialState;
    }

    public OrderState State { get; private set; }

    public void SetSate(OrderState newState)
    {
        this.State = newState;
    }

    public bool IsPaid { get; private set; }       

    public void Paid()
    {
        IsPaid = true;
    }

    public void Confirm()
    {
        State.Confirm();
    }

    public void Cancel()
    {
        State.Cancel();
    }

    public override string ToString() => $"Order {Environment.NewLine}";
    
}

//public enum OrderStatus
//{
//    // The customer places an order on the company's website
//    Pending,
//    Processing,      
//    Completed,
//    Canceled
//}
