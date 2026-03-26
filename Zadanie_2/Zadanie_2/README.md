# Zadanie_2

Projekt napisałam w C# jako aplikację konsolową.  
Tematem projektu jest uczelniana wypożyczalnia sprzętu.

Celem programu jest umożliwienie rejestrowania sprzętu, wypożyczania go użytkownikom, zwrotów, kontrolowania dostępności oraz generowania podstawowych raportów.

## Zakres projektu

W projekcie występują:

- wspólna klasa bazowa `Equipment`
- trzy typy sprzętu:
    - `Laptop`
    - `Projector`
    - `Camera`
- wspólna klasa bazowa `User`
- dwa typy użytkowników:
    - `Student`
    - `Employee`
- klasa `Rental`, która opisuje wypożyczenie

Program obsługuje:

- dodawanie użytkowników
- dodawanie sprzętu
- wyświetlanie całego sprzętu
- wyświetlanie dostępnego sprzętu
- wypożyczanie sprzętu
- zwrot sprzętu
- naliczanie kary za spóźniony zwrot
- oznaczenie sprzętu jako niedostępny
- wyświetlanie aktywnych wypożyczeń użytkownika
- wyświetlanie przeterminowanych wypożyczeń
- raport końcowy

## Zasady biznesowe

W projekcie przyjęłam następujące zasady:

- student może mieć maksymalnie 2 aktywne wypożyczenia
- pracownik może mieć maksymalnie 5 aktywnych wypożyczeń
- sprzęt niedostępny nie może zostać wypożyczony
- sprzęt już wypożyczony nie może być wypożyczony drugi raz
- opóźniony zwrot powoduje naliczenie kary

Reguły dotyczące limitów i kar zapisałam w osobnych klasach, żeby w razie potrzeby można je było łatwo zmienić.

## Struktura projektu

Projekt podzieliłam na kilka części:

- `Domain` – znajdują się tu klasy modelu i enumy
- `Repositories` – przechowywanie danych w pamięci
- `Services` – logika biznesowa
- `UI` – scenariusz demonstracyjny i dane testowe

## Uzasadnienie decyzji projektowych

Nie chciałam umieszczać całej logiki w `Program.cs`, dlatego podzieliłam projekt na osobne klasy odpowiedzialne za konkretne zadania.

Wybrałam taki podział, ponieważ dzięki temu kod jest czytelniejszy i łatwiej pokazać, która część projektu odpowiada za model danych, która za operacje biznesowe, a która tylko za uruchomienie przykładowego scenariusza.

Dziedziczenie wykorzystałam tam, gdzie wynika ono naturalnie z modelu domenowego:
- `Equipment` jako klasa bazowa dla różnych typów sprzętu
- `User` jako klasa bazowa dla różnych typów użytkowników

## Kohezja, coupling i odpowiedzialności klas

Starałam się zadbać o spójność klas i sensowny podział odpowiedzialności.

### Kohezja
Każda klasa ma jedno główne zadanie:

- `RentalService` obsługuje wypożyczenia, zwroty i zmianę statusu sprzętu
- `PenaltyCalculator` odpowiada tylko za naliczanie kary
- `RentalPolicy` odpowiada tylko za limity wypożyczeń
- `ReportService` odpowiada za raporty
- klasy w folderze `Domain` opisują obiekty systemu

### Coupling
Powiązania między klasami starałam się ograniczyć przez rozdzielenie logiki na mniejsze elementy.  
Na przykład zasady kar i limitów nie są rozproszone po całym projekcie, tylko znajdują się w osobnych klasach serwisowych.

### Odpowiedzialności klas
W projekcie widać podział odpowiedzialności:
- model domenowy jest oddzielony od logiki operacji
- logika operacji jest oddzielona od części uruchamiającej program
- `Program.cs` pełni głównie rolę startową i łączy obiekty razem

## Scenariusz demonstracyjny

W metodzie `Main` pokazuję przykładowy scenariusz działania programu:

- dodanie kilku użytkowników
- dodanie kilku egzemplarzy sprzętu
- poprawne wypożyczenie sprzętu
- próbę wykonania niepoprawnej operacji
- zwrot w terminie
- zwrot opóźniony z naliczeniem kary
- wyświetlenie raportu końcowego

## Uruchomienie

Projekt można uruchomić w Riderze jako aplikację konsolową.

1. Otworzyć projekt `Zadanie_2`
2. Uruchomić plik `Program.cs`
3. Program wykona przygotowany scenariusz demonstracyjny i wyświetli wyniki w konsoli