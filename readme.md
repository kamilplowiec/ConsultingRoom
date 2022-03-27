# Gabinet lekarski

![Gabinet lekarski](https://kamilplowiec.tk/img/portfolio/csdesktop4.jpg)

1. Rejestracjê osób (lekarz, zwyk³a osoba, sekretarka)
2. Rejestracje wizyt zarejestrowanych osób
3. S³ownik Lekarz, osoba, pracownik itp
4. Wyszukiwanie wizyt
5. Odhaczanie, czy wizyta siê odby³a

## Opis dzia³ania

1. Logowanie 
- Uzytkownika moze stworzyc inny uzytkownik (lekarz, sekretarka) po rejestracji osoby w edycji tej osoby (nadanie loginu i hasla)
- Uzytkownik loguje sie podanym loginem i haslem lub anuluje logowanie, co wi¹¿e siê z zamkniêciem aplikacji

2. Panel dzia³añ
- W panelu dzia³añ znajduj¹ siê przyciski:
  - Pacjenci: Lista obejmuje wszystkich pacjentów gabinetu. Klikniêcie w rekord powoduje wejœcie do widoku. Z tego poziomu mo¿na planowac wizytê dla danego pacjenta po klikniêciu przycisku Planuj wizytê na jego rekordzie.
  - Rejestracja pacjenta (tylko sektretarka): Formularz umo¿liwia zapis w bazie podstawowych danych iosobowych pacjenta (imiê, nazwisko, adres, telefon, email, pesel).
  - Zaplanowane wizyty (lekarz widzi swoje, sekretarka widzi wszystkie): Lista wyœwietla infromacjê o zaplanowanej wizycie: kto, jaki lekarz (je¿eli dla sekretarki), datê i godzinê, czy zrealizowana..
  - Zaplanuj wizytê :Formularz umo¿liwia zaplanowanie wizyty pacjenta, znajduj¹cego siê ju¿ w bazie danych u lekarza. Pacjenta nale¿y wybrac z listy rozwijanej, podobnie jak lekarza. Datê mo¿na wybraæ w polu edycyjnym z kalendarza lub wpisaæ rêcznie. Godzinê nale¿y wpisac rêcznie. Je¿eli lekarz ma zaplanowan¹ wizytê na podan¹ godzinê, zaplanowanie nie bêdzie mo¿liwe. Wizyta jest planowana na 30 minut. W tym czasie nie mo¿na umówiæ innej wizyty u danego lekarza. Pole zaznaczenia, czy wizyta siê odby³a, przeznaczone jest dla lekarza. W polu informacje zarówno sekretarka mo¿e wpisywac informacje o pacjencie, jak i lekarz mo¿e uzupe³niaæ "kartê pacjenta".
  - Wyloguj: Przycisk umo¿liwia wylogowanie z systemu. Do czasu ponownego zalogowania, nie ma mo¿liwoœci wprowadzania zmian w systemie.
  - Zamknij: Przycisk zamyka aplikacjê.



## Tabele

1. Person
- id
- name
- address
- phone
- email
- pesel
- persontype_id

2. Visit
- id
- person_id
- doctor_id
- date
- visitwasheld
- comment

3. User
- id
- person_id
- login
- password