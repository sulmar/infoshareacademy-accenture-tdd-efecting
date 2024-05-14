## Kilka zasad pisania czystego kodu w C#

### 1. Nazwy klas
Nazwy klas powinny być rzeczownikami i również zaczynać się wielką literą, np. `Customer`, `Invoice`.

Źle
```csharp
public class Calculate
{    
    public decimal Salary()
    {
        // Implementacja metody obliczającej wynagrodzenie
    }

}

public class Validate
{
    public bool Email(string email)
    {
        // Implementacja metody walidującej email
        throw new NotImplementedException();
    }
}

public class Send
{
    public void Send()
    {
        // Implementacja metody wysyłania
        throw new NotImplementedException();
    }
}
```

Dobrze
```csharp
public class SalaryCalculator
{    
    public decimal Calculate()
    {
        // Implementacja metody obliczającej wynagrodzenie
    }
}

public class EmailValidator
{
    public bool Validate(string email)
    {
        // Implementacja metody walidującej email
    }
}

public class SendCommand
{
    public void Execute()
    {
        // Implementacja metody wysyłania
        throw new NotImplementedException();
    }
}

```


## 2. Nazwy metod

 Nazwy metod powinny być czasownikami lub frazami czasownikowymi i zaczynać się wielką literą, np. `CalculateTotal`, `SendEmail`.

Źle
```csharp
public class Order
{    
    public void Payment()
    {
        // Implementacja metody przetwarzającej płatność
    }

    public void Confirmation()
    {
        // Implementacja metody potwierdzającej zamówienie
    }    
}
```

Dobrze

```csharp
public class Order
{    
    public void ProcessPayment()
    {
        // Implementacja metody przetwarzającej płatność
    }

    public void Confirm()
    {
        // Implementacja metody potwierdzającej zamówienie
    }
}
```




### 2. Nazwy parametrów
- Powinny być opisowe i zaczynać się małą literą, np. `customerId`, `totalAmount`.

Źle
```csharp
public class Order
{    
    public DateTime Date { get; set; }    
    public string Status { get; set; }
    public decimal Amount { get; set; }    
    public decimal GetTotalAmount { get; set; }
    public decimal Calculate { get; set; }
}
```

Dobrze
```csharp
public class Order
{    
    public DateTime DeliveryDate { get; set; }  
    public string OrderStatus { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TaxAmount { get; set; }

     public decimal TotalAmount { get; set; }
     public decimal Calculate();
}
```

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

1. Metody, zmienne, pola i właściwości logiczne powinny być prefiksowane z `is`, `has`, `can`

Źle
```csharp
public bool Validate(int number);
public bool Available();
public bool Active();
public bool Enabled();
public bool Open();
public bool Completed();
public bool LoggedIn();
public bool Edit();
```

Dobrze
```csharp
public bool IsValidNumber(int number);
public bool IsAvailable();
public bool IsActive();
public bool IsEnabled();
public bool IsOpen();
public bool IsCompleted();
public bool IsLoggedIn();
public bool CanEdit();
public bool CanChangePassword();
public bool HasPermission(string permission);
```

2. Metody, zmienne, pola i właściwości logiczne powinny używać pozytywnych nazw, aby uniknąć podwójnych zaprzeczeń.

Źle
```csharp
public bool IsInvalidNumber(int number);
```

Dobrze
```csharp
public bool IsValidNumber(int number);
```

3. Metody testowe powinny być nazywane zgodnie z konwencją:
`Method_WhenScenario_ShouldExpectedBehavior` lub `Method_ShouldExpectedBehavior_WhenScenario`

Obie konwencje są poprawne, a wybór pomiędzy nimi może zależeć od preferencji zespołu oraz konkretnego kontekstu testów. Kluczowe jest, aby nazwy metod testowych były:

1. **Opisowe**: Wyraźnie określały, co jest testowane.
2. **Czytelne**: Były łatwe do zrozumienia przez każdego czytającego kod testowy.
3. **Spójne**: Przestrzegały spójnego wzorca nazewnictwa w całym kodzie.

Źle
```csharp
public bool Test_GoodFlow();
public bool Test_BadFlow();
public bool Id_1_Returns_Movie();
public bool Id_666_Returns_Exception();
public bool WhenCallingGetMovieWithId666ShouldThrowsException();
public bool WhenCallingGetMovieWithId1ShouldReturnsMovie();
```

Dobrze
```csharp
public bool GetMovie_WhenIdIsValid_ShouldReturnsMovie();
public bool GetMovie_WhenIdIsInvalid_ShouldThrowsException();
```



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