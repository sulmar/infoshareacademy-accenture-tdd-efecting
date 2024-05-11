## Ćwiczenie - Taxi Service

Napisz klasę ComplicatedPipeCuttingCalculator, która oblicza ilość odpadów pozostawionych po cięciu rury na konkretne długości. Jednakże, istnieją pewne problemy związane z zasadami programowania.

### Problemy:

Zasada DRY (Nie Powtarzaj Się) jest naruszona przez zduplikowaną logikę walidacji i obliczeń.
Zasada KISS (Trzymaj to proste, głupcze) jest naruszona przez bardziej skomplikowany kod walidacji i obliczeń, co sprawia, że kod jest mniej czytelny.
Zasada YAGNI (Nie Zamierzasz Tego Potrzebować) jest naruszona przez dodatkowe walidacje, które mogą być zbędne, oraz redundancję w kodzie.
Twoim zadaniem jest zrefaktoryzowanie kodu ComplicatedPipeCuttingCalculator, aby przestrzegał zasad DRY, KISS i YAGNI.

### Wymagania:

1. Zrefaktoryzuj kod tak, aby uniknąć zduplikowanej logiki walidacji i obliczeń.
2. Uprość kod walidacji i obliczeń, aby był bardziej czytelny i przestrzegał zasady KISS.
3. Usuń zbędne walidacje i redundancję w kodzie, aby przestrzegać zasady YAGNI.

Klasa _ComplicatedPipeCuttingCalculator_ powinna zawierać:

Publiczną metodę _CalculateWaste_, która przyjmuje długość rury (pipeLength) i tablicę długości cięć (cuts) oraz zwraca ilość odpadów pozostawionych po cięciu rury.

### Założenia:
- Długość rury (pipeLength) musi być większa niż zero.
- Tablica długości cięć (cuts) nie może być null ani pusta.
- Suma długości cięć nie może przekraczać długości rury.

Pamiętaj o przetestowaniu zrefaktoryzowanego kodu, aby upewnić się, że zachowuje on poprawność obliczeń.