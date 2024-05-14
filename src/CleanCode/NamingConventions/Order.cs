namespace NamingConventions;

public class Order
{
    public DateTime Date { get; set; }
    public Status Status { get; set; }
    public decimal Amount { get; set; }

    public void Payment()
    {
        // Implementacja metody przetwarzającej płatność
    }

    public void Confirmation()
    {
        // Implementacja metody potwierdzającej zamówienie
    }
}

public enum Status { Pending, Processing, Completed }
