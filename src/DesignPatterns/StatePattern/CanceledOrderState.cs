using System;

namespace StatePattern;

// Concrete State D
public class CanceledOrderState : OrderState
{
    private readonly Order order;

    public CanceledOrderState(Order order)
    {
        this.order = order;
    }
    public override void Cancel()
    {
        throw new InvalidOperationException();
    }

    public override void Confirm()
    {
        throw new InvalidOperationException();
    }
}

//public enum OrderStatus
//{
//    // The customer places an order on the company's website
//    Pending,
//    Processing,      
//    Completed,
//    Canceled
//}
