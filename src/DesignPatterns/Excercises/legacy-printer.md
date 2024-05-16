## Ćwiczenie - stara drukarka

## Wprowadzenie
Firma posiada aplikację, która korzysta z drukarek termicznych zarówno z nowych i starych urządzeń.
Zależy im na dodanu liczinika do starej drukarki oraz dodanie możliwości obliczania kosztu wydruków na wszystkich drukarkach.

```csharp

public sealed class LegacyPrinter
{
    public void PrintDocument(string document)
    {
        Console.WriteLine($"Legacy Printer is printing: {document}");
    }
}
```
- **uwaga:** Nie zmieniaj kodu tej klasy!


API do obsługi nowej drukarki wygląda następująco:

```csharp
public class Printer
{
	 public int Counter { get; private set; }

	public void Print(string document, int copies = 1)
	{
		for (int copy = 1; copy <= copies; copy++)
		{
			Console.WriteLine($"Printer is printing: {document}");
			Counter += 1;
		}
	}
}
```

Tą klasę możesz modyfikować.

## Zadanie


Twoim zadaniem jest dodanie licznika do nowej i starej drukarki oraz obliczanie kosztu wydruku i bez modyfikacji starej klasy.


## Wymagania
1. Stwórz klasę _Printer_, która będzie umożliwiała wydruk dokumentu w wielu kopiach.

2. Próba wydruku pustego dokumentu powinna być zgłaszana poprzez wyjątek _EmptyDocumentException_

3. Jeśli przekażemy ujemną lub zerową liczbę kopii to powinien być zgłoszony wyjątek _ArgumentException_

4. Dodaj licznik do drukarki _Counter_, który będzie zliczać sumaryczną ilość wydrukowanych kopii przy wielu wywołaniach _Print_

[5. Dodaj możliwość obliczania kosztu wydruku jeśli. Koszt za jedną stronę wynosi 0.10 zł.]

6. Zadbaj o czytelność i przejrzystość kodu. Nazewnictwo zmiennych, metody i klasy powinno być zrozumiałe i konsekwentne. Staraj się unikać zbędnych komentarzy poprzez pisanie czytelnego kodu.

7. Sprawdź, czy kod jest zgodny z zasadami SOLID i zasadami czystego kodu, takimi jak DRY, KISS, YAGNI, oraz zasadą pojedynczej odpowiedzialności.

8. Wymagania realizuj zgodnie z techniką **TDD** (_Test-driven-development_):

- **Red** - kod nieprzechodzący test
- **Green** - kod przechodzący test
- **Refactor** - refaktoryzacja kodu i testów


## Termin
45 min