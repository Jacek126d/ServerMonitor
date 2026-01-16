# ServerMonitor
Dokumentacja aplikacji ServerMonitor
1. Cel i Zakres Projektu
Celem projektu było stworzenie aplikacji typu webowego służącej do monitorowania dostępności usług sieciowych. Aplikacja umożliwia użytkownikowi dodawanie adresów URL, cykliczne sprawdzanie ich statusu (Online/Offline), mierzenie czasu odpowiedzi (Ping) oraz automatyczne określanie fizycznej lokalizacji serwera.
2. Stack technologiczny
Projekt został zrealizowany w oparciu o środowisko .NET i język C#.
Framework: ASP.NET (Web API + MVC)
Język: C#
Baza danych: Microsoft SQL Server Express
ORM: Entity Framework Core (Code First)
Frontend: Razor Views (.cshtml), Bootstrap 
API: ip-api.com (REST)
3. Architektura Systemu
Aplikacja wykorzystuje wzorzec architektoniczny MVC (Model-View-Controller) z wydzieloną warstwą usług.
3.1. Schemat działania
Użytkownik wywołuje akcję w przeglądarce.
Kontroler (HomeController) odbiera żądanie.
Kontroler zleca Serwisowi (MonitorService) wykonanie zadań (sprawdzenie dostępności serwerów).
Serwis komunikuje się z siecią (‘pingowanie’, API lokalizacji) i aktualizuje dane w bazie danych.
Kontroler pobiera zaktualizowane dane i przekazuje je do widoku.
HTML trafia do użytkownika na stronę.
4. Komponenty
4.1. MonitorService
Weryfikacja dostępności: Wykorzystuje klasę HttpClient do wysyłania żądań HTTP GET.
Maskowanie klienta: Ustawia nagłówek imituje przeglądarkę.
Pomiar wydajności: Wykorzystuje klasę stopwatch do pomiaru czasu odpowiedzi 
w milisekundach.
Geolokalizacja: Integruje się z REST API ip-api.com. Pobiera kraj i dostawcę usług (ISP) na podstawie nazwy hosta.
4.2. Baza Danych (ef)
Struktura bazy jest definiowana przez klasę modelu. Tabela zawiera:
Id (pk)
Name, Url
Category
IsOnline, ResponseTimeMs,
LastChecked,
Baza posiada dane testowe.
4.3. Interfejs API (REST) 
System udostępnia interfejs programistyczny zgodny z architekturą REST (Representational State Transfer).
Zasoby: Głównym zasobem jest Monitor, dostępny pod ścieżką /api/monitor.
Metody HTTP: Operacje mapowane są na standardowe czasowniki HTTP:
GET – pobranie stanu wszystkich monitorowanych usług.
POST – utworzenie nowej konfiguracji monitorowania.
Format danych: Komunikacja odbywa się bezstanowo z wykorzystaniem formatu JSON

5. Instrukcja Użytkownika
5.1. Panel Główny
Strona główna prezentuje kafelki reprezentujące monitorowane serwisy.
Kolor Zielony (ONLINE): Serwis odpowiada poprawnie.
Kolor Czerwony (OFFLINE): Serwis nie odpowiada lub wystąpił błąd DNS.
Dane: Każdy kafelek wyświetla aktualny ping oraz lokalizację serwera.
Strona odświeża się samoczynnie co 30 sekund (js).
5.2. Zarządzanie
Dodawanie: Formularz na górze strony pozwala zdefiniować nową usługę. Wymagane jest podanie Nazwy i poprawnego URL.
Usuwanie: Przycisk "X" w rogu kafelka trwale usuwa serwis z monitoringu.
6. Wnioski 
Zrealizowana aplikacja ServerMonitorw pełni realizuje założenia projektowe. 
CRUD: Użytkownik ma możliwość tworzenia nowych celów monitorowania oraz ich usuwania. Operacje Read i Update są w warstwie usługowej. 
Aplikacja posługuje się operacjami sieciowymi w tym TCP HTTP (handshake z monitorowanymi serwisami)
Integracja z systemami zewnętrznymi (REST API: Aplikacja łączy się z zewnętrznym API (ip-api.com) w celu uzyskania lokalizacji serwera. Wykorzystano również konfigurację HttpClient, aby móc odpytać strony z zabezpieczeniami antybotowymi.
Rozwiązanie łączy się (w tym przypadku z lokalną) bazą danych SQL SERVER EXPRESS.




