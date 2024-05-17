namespace StatePattern;

// Concrete State B
public class ProcessingOrderState : OrderState
{
    private readonly Order order;

    public ProcessingOrderState(Order order)
    {
        this.order = order;
    }

    public override void Cancel()
    {
        order.SetSate(new CanceledOrderState(order));
    }

    public override void Confirm()
    {
        order.SetSate(new CompletedOrderState(order));
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
