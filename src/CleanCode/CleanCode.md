## Kilka zasad pisania czystego kodu w C#

### 1. Nazwy metod i klas
- Nazwy metod powinny być czasownikami lub frazami czasownikowymi i zaczynać się wielką literą, np. `CalculateTotal`, `SendEmail`.
- Nazwy klas powinny być rzeczownikami i również zaczynać się wielką literą, np. `Customer`, `Invoice`.

### 2. Nazwy parametrów
- Powinny być opisowe i zaczynać się małą literą, np. `customerId`, `totalAmount`.


### 3. Ilość parametrów
Zaleca się, aby metody miały maksymalnie trzy-cztery parametry. Jeśli potrzeba więcej, rozważ utworzenie obiektu zawierającego te parametry.

Ten sposób nazywa się **Parameter Object**. 
Polega on na grupowaniu wielu parametrów w jeden obiekt, co zwiększa czytelność i zarządzalność kodu. Dzięki temu metoda przyjmuje jeden parametr zamiast wielu, co jest bardziej przejrzyste i łatwiejsze do utrzymania.

Przykład:

Przed użyciem Parameter Object:
```csharp
public void ProcessOrder(int orderId, string customerName, DateTime orderDate, decimal totalAmount)
{
    // Implementacja metody
}
```

Po użyciu Parameter Object:
```csharp
public class OrderInfo
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}

public void ProcessOrder(OrderInfo orderInfo)
{
    // Implementacja metody
}
```


### 4. Konwencje nazewnicze
- Używaj notacji PascalCase dla nazw typów (klas, interfejsów, metod).
- Używaj notacji camelCase dla zmiennych lokalnych i parametrów.

### 5. Formatowanie
- Zadbaj o odpowiednie wcięcia kodu (zazwyczaj cztery spacje).
- Rozdzielaj logiczne bloki kodu pustymi liniami, aby poprawić czytelność.

### 6. Jedna odpowiedzialność
- Klasy i metody powinny mieć jedną odpowiedzialność, co ułatwia zrozumienie i testowanie kodu.

### 7. Komentarze
- Komentarze powinny być używane do wyjaśnienia „dlaczego” coś jest robione, a nie „jak”. Kod powinien być na tyle czytelny, aby nie wymagał komentarzy do zrozumienia, jak działa.

Źle:
```csharp

// Pobranie wartości z bazy danych
var value = database.GetValue();

// Dodanie wartości do listy
list.Add(value);

// Iteracja po liście i wyświetlenie wartości
foreach (var item in list)
{
    Console.WriteLine(item);
}
```

Dobrze:
```csharp
var value = database.GetValue();

list.Add(value);

// Wyświetlamy wartości, aby użytkownik mógł je zweryfikować przed zapisaniem zmian
foreach (var item in list)
{
    Console.WriteLine(item);
}

// Wyjątkowy przypadek: jeśli lista jest pusta, informujemy użytkownika
if (list.Count == 0)
{
    Console.WriteLine("Lista jest pusta. Sprawdź źródło danych.");
}
```

Lepiej:
```csharp
public static class ListExtensions
{
    public static bool IsEmpty<T>(this List<T> list)
    {
        return list.Count == 0;
    }
}
```

```csharp
var value = database.GetValue();

list.Add(value);

foreach (var item in list)
{
    Console.WriteLine(item);
}

if (list.IsEmpty())
{
    Console.WriteLine("Lista jest pusta. Sprawdź źródło danych.");
}
```


### 8. Unikaj magicznych liczb
Zamiast używać liczb bezpośrednio w kodzie, używaj stałych lub enumeracji, aby kod był bardziej zrozumiały.

```csharp
public class Order
{
    public double TotalAmount { get; set; }

    public double ApplyDiscount()
    {
        // Magiczna liczba 0.1
        return TotalAmount * 0.9;
    }

    public string GetOrderStatus(int statusCode)
    {
        // Magiczne liczby 0, 1, 2
        switch (statusCode)
        {
            case 0:
                return "Pending";
            case 1:
                return "Processing";
            case 2:
                return "Completed";
            default:
                return "Unknown";
        }
    }
}
```

```csharp
public class Order
{
    public double TotalAmount { get; set; }

    // Stała dla zniżki
    private const double DiscountRate = 0.1;

    public double ApplyDiscount()
    {
        return TotalAmount * (1 - DiscountRate);
    }

    // Enumeracja dla statusów zamówień
    public enum OrderStatus
    {
        Pending = 0,
        Processing = 1,
        Completed = 2
    }

    public string GetOrderStatus(OrderStatus status)
    {
        switch (status)
        {
            case OrderStatus.Pending:
                return "Pending";
            case OrderStatus.Processing:
                return "Processing";
            case OrderStatus.Completed:
                return "Completed";
            default:
                return "Unknown";
        }
    }
}
```