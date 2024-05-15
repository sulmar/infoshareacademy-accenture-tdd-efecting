namespace NamingConventions;

public class Order
{
    public string CustomerName { get; set; }
    public DateTime DeliveryDate { get; set; }
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public decimal TotalAmount { get; set; }

    public void MakePayment()
    {
        // Implementacja metody przetwarzającej płatność
    }

    public void Confirm()
    {
        // Implementacja metody potwierdzającej zamówienie
    }

    public decimal Calculate()
    {
        var result = TotalAmount * 0.1m;

        throw new NotImplementedException();

        return result;

    }

    public decimal GetTotal { get; set; }
}

public enum OrderStatus { Pending, Processing, Completed }

public enum PaymentStatus {  Awaiting, Confirmed, Canceled }
