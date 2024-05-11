## Single Responsibility Principle (SRP)
_Zasada pojedynczej odpowiedzialności_

- Każda klasa powinna mieć tylko jeden powód do zmiany. Oznacza to, że klasa powinna być odpowiedzialna tylko za jedną rzecz.
## Open/Closed Principle (OCP)
_Zasada otwarte-zamknięte_

- Oprogramowanie powinno być otwarte na rozszerzenia, ale zamknięte na modyfikacje. Nowe funkcjonalności powinny być dodawane poprzez rozszerzanie istniejącego kodu, a nie zmienianie go.
## Liskov Substitution Principle (LSP)
_Zasada zastępowalności Liskov_
- Obiekty klasy podrzędnej powinny być zastępowalne przez obiekty klasy bazowej bez zmiany żądanych właściwości. Innymi słowy, obiekty powinny być w pełni zgodne z interfejsem klasy bazowej.

## Interface Segregation Principle (ISP)
_Zasada segregacji interfejsów_
- Klienci nie powinni być zmuszani do implementowania interfejsów, których nie używają. Interfejsy powinny być małe, specyficzne i zawierać tylko te metody, które są niezbędne dla swoich klientów.
## Dependency Inversion Principle (DIP)
_Zasada odwrócenia zależności_
- Wysokopoziomowe moduły nie powinny zależeć od niskopoziomowych modułów, ale oba powinny zależeć od abstrakcji. Abstrakcje nie powinny zależeć od szczegółów, ale szczegóły powinny zależeć od abstrakcji.