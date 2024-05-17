using System;

namespace StatePattern;

// Concrete State A
public class PendingOrderState : OrderState
{
    private readonly Order order;

    public PendingOrderState(Order order)
    {
        this.order = order;
    }

    public override void Cancel()
    {
        order.SetSate(new CanceledOrderState(order));
    }

    public override void Confirm()
    {
        if (order.IsPaid)
        {
            order.SetSate(new ProcessingOrderState(order));
        }
        else
        {
            throw new InvalidOperationException();
        }
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
