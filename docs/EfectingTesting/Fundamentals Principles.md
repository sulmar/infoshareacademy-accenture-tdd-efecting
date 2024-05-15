# KISS _(Keep It Simple, Stupid)_ 
- **Zasada**: Zachowaj prostotę, nie komplikuj niepotrzebnie
- **Wyjaśnienie**: Twórz prosty, łatwy do zrozumienia i utrzymania kod. Unikaj zbędnych komplikacji, które mogą prowadzić do błędów i trudności w debugowaniu.

Źle:
``` csharp
public class GradeCalculator

{

    public double CalculateAverageGrade(List<double> grades)

    {

        if (grades == null || grades.Count == 0)

        {

            throw new ArgumentException("Grade list cannot be null or empty.");

        }
  

        double sum = SumOfGrades(grades);

        double average = CalculateAverage(sum, grades.Count);

        return average;

    }

  

    private double SumOfGrades(List<double> grades)

    {

        double sum = 0;

        foreach (var grade in grades)

        {

            sum += grade;

        }

        return sum;

    }

  

    private double CalculateAverage(double sum, int count)

    {

        return sum / count;

    }

}
```

Dobrze:
```csharp
public class GradeCalculator
{
    public double CalculateAverageGrade(List<double> grades)
    {
        if (grades == null || grades.Count == 0)
        {
            throw new ArgumentException("Grade list cannot be null or empty.");
        }

        double sum = 0;
        foreach (var grade in grades)
        {
            sum += grade;
        }

        return sum / grades.Count;
    }
}
```

Lepiej:
```csharp
public class GradeCalculator
{
    public double CalculateAverageGrade(List<double> grades)
    {
        if (grades == null || grades.Count == 0)
        {
            throw new ArgumentException("Grade list cannot be null or empty.");
        }

        return grades.Average();
    }
}

```
# DRY _(Don't Repeat Yourself)_
- **Zasada:** Unikaj duplikacji kodu.
- **Wyjaśnienie:** Zamiast powielać kod, używaj funkcji i modułów, aby zwiększyć jego przejrzystość i łatwość utrzymania. Powtarzający się kod utrudnia wprowadzanie zmian i zwiększa ryzyko błędów.

Źle:
```csharp
public class AccountController : Controller

{

    [HttpPost]

    public IActionResult AddUsername(string newUsername)

    {

        if (string.IsNullOrEmpty(newUsername) || newUsername.Length < 4)

        {

            ModelState.AddModelError("newUsername", "Username must be at least 4 characters.");

            return View("AddUsername");

        }

  

        // Add the username to the database

        // Redirect to success page

  

        return Redirect("/");

    }

  

    [HttpPost]

    public IActionResult UpdateUsername(string newUsername)

    {

        if (string.IsNullOrEmpty(newUsername) || newUsername.Length < 4)

        {

            ModelState.AddModelError("newUsername", "Username must be at least 4 characters.");

            return View("ChangeUsername");

        }

  

        // Update the username in the database

        // Redirect to success page

  

        return Redirect("/");

    }

  

}
```

Dobrze:

```csharp
public class AccountController : Controller
{
    [HttpPost]
    public IActionResult AddUsername(string newUsername)
    {
        if (!IsValidUsername(newUsername))
        {
            ModelState.AddModelError("newUsername", "Username must be at least 4 characters.");
            return View("AddUsername");
        }

        // Add the username to the database
        // Redirect to success page

        return Redirect("/");
    }

    [HttpPost]
    public IActionResult UpdateUsername(string newUsername)
    {
        if (!IsValidUsername(newUsername))
        {
            ModelState.AddModelError("newUsername", "Username must be at least 4 characters.");
            return View("ChangeUsername");
        }

        // Update the username in the database
        // Redirect to success page

        return Redirect("/");
    }

    private bool IsValidUsername(string username)
    {
        return !string.IsNullOrEmpty(username) && username.Length >= 4;
    }
}

```
# YAGNI _(You Aren't Gonna Need It)_
- **Zasada:** Implementuj tylko to, co jest potrzebne.
- **Wyjaśnienie:** Nie dodawaj funkcji, dopóki nie są one rzeczywiście wymagane. Tworzenie funkcji "na zapas" często prowadzi do nadmiernej komplikacji systemu, co utrudnia jego rozwój i utrzymanie.

Źle:
```csharp
public class OrderProcessor

{

    public void ProcessOrder(Order order)

    {

        // Przetwarzanie zamówienia

    }

  

    public void CancelOrder(Order order)

    {

        // Anulowanie zamówienia

    }

  

    public void UpdateOrder(Order order)

    {

        // Aktualizacja zamówienia

    }

  

    public void GenerateInvoice(Order order)

    {

        // Generowanie faktury

    }

  

}
```

Dobrze:
```csharp
public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Przetwarzanie zamówienia
    }

    public void GenerateInvoice(Order order)
    {
        // Generowanie faktury
    }
}

```