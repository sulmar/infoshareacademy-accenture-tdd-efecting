using System;

namespace StatePattern;

// Concrete State C
public class CompletedOrderState : OrderState
{
    private readonly Order order;

    public CompletedOrderState(Order order)
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
