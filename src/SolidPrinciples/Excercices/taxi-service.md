## Ćwiczenie - Taxi Service

## Wprowadzenie
Załóżmy, że mamy aplikację do zamawiania taksówek, która korzysta z różnych usług taksówkarskich dostępnych w różnych regionach. Chcemy, aby nasza aplikacja obsługiwała różne firmy taksówkarskie, takie jak "QuickTaxi" i "CityCab".

 Nasza implementacja jest mało elastyczna i ciężka do wprowadzania zmian, na przykład dodanie nowej firmy taksówkarsiej.
 

## Zadanie
Spróbuj poprawić ten kod. Jakie zasady zostały naruszone?


```csharp
public class TaxiService {
    private readonly QuickTaxi _quickTaxi;
    private readonly CityCab _cityCab;

    public TaxiService() {
        _quickTaxi = new QuickTaxi();
        _cityCab = new CityCab();
    }

    public void BookQuickTaxi(string destination) {
        _quickTaxi.Book(destination);
    }

    public void BookCityCab(string destination) {
        _cityCab.Book(destination);
    }

	public void CancelBookingQuickTaxi(string bookingId) {
        _quickTaxi.CancelBooking(bookingId);
    }

    public void BookCityCab(string destination) {
        _cityCab.Book(destination);
    }
	
}

public class QuickTaxi {
    public void Book(string destination) {
        // Logika rezerwacji taksówki w QuickTaxi
		SendSMS("Your QuickTaxi has been booked to " + destination);
    }

	public void CancelBooking(string bookingId) {
        // Logika anulowania rezerwacji taksówki w QuickTaxi
    }

	 public void RateDriver(string driverId, int rating) {
        // Logika oceny kierowcy taksówki w QuickTaxi
    }

    private void SendSMS(string message) {
        // Logika wysyłania SMS
    }
}

public class CityCab {
    public void Book(string destination) {
        // Logika rezerwacji taksówki w CityCab
    }

	 public void CancelBooking(string bookingId) {
        // Logika anulowania rezerwacji taksówki w CityCab
    }
}
```