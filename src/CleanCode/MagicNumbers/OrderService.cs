namespace MagicNumbers;

public class Order
{
    public double TotalAmount { get; set; }
    public int OrderStatus { get; set; }

    public double ApplyDiscount()
    {
        // Magiczna liczba 0.1
        return TotalAmount * 0.9;
    }
}


public class OrderService
{
    public void Process(Order order)
    {
        if (order.OrderStatus == 0)
        {
            // Pending
        }
        else if (order.OrderStatus == 1)
        {
            // Processing 
        }
        else if (order.OrderStatus == 2)
        {
            // Completed
        }


    }


}