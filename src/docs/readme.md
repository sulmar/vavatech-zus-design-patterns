


# Dekorator
Dynamiczne rozszerzanie funkcjonalności obiektu bez zmiany jego kodu.

# Proxy
 
 - **Cel:** Kontrola dostępu do obiektu, optymalizacja wydajności lub opóźnione tworzenie obiektu (lazy initialization).

- **Zastosowanie:** 
  - **Zdalne wywołania (Remote Proxy)** – umożliwia zdalne połączenia z obiektami znajdującymi się na innych maszynach lub w innych procesach.
  - **Lazy loading (Virtual Proxy)** – opóźnia inicjalizację obiektów, np. w EF Core przy użyciu Lazy Loading, ładowanie danych lub obiektów tylko w momencie ich faktycznego użycia.
   - **Dynamiczne obiekty pośredniczące (Dynamic Proxy)** – generuje obiekty w czasie działania aplikacji, np. w implementacjach INotifyPropertyChanged w MVVM, automatycznie dodając dodatkową funkcjonalność.
  - **Kontrola dostępu (Protection Proxy)** – zabezpiecza dostęp do obiektów, np. przez kontrolowanie, kto i kiedy może używać zasobów lub metod.
  - **Cache (Caching Proxy)** – przechowuje wcześniej obliczone wyniki, aby uniknąć kosztownego przetwarzania tych samych danych wielokrotnie.


# Kluczowe różnice pomiędzy wzorcami Dekorator a Proxy

| Cecha            | Dekorator                         | Proxy                              |
|-----------------|---------------------------------|----------------------------------|
| **Cel**         | Rozszerzanie funkcjonalności    | Kontrola dostępu, optymalizacja  |
| **Główna idea** | Dodaje nowe zachowania         | Ukrywa lub opóźnia dostęp do obiektu |
| **Zmiana zachowania** | Tak, modyfikuje istniejące metody | Nie, zazwyczaj tylko pośredniczy |
| **Tworzenie obiektu** | Obiekt jest już utworzony | Może opóźniać inicjalizację |
| **Przykłady**   | Szyfrowanie, kompresja, logowanie | Lazy loading, zdalne wywołania, cache |



# Adapter 
jest używany, aby umożliwić komunikację między obiektami, które nie pasują do siebie pod względem interfejsu. Zmienia sposób interakcji między obiektami.

# Facade 
upraszcza interakcję z wieloma obiektami, dostarczając jeden, prosty punkt dostępu do bardziej złożonego systemu, nie zmieniając przy tym wewnętrznego działania systemu.