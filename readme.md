# Gabinet lekarski

![Gabinet lekarski](https://kamilplowiec.tk/img/portfolio/csdesktop4.jpg)

1. Rejestracj� os�b (lekarz, zwyk�a osoba, sekretarka)
2. Rejestracje wizyt zarejestrowanych os�b
3. S�ownik Lekarz, osoba, pracownik itp
4. Wyszukiwanie wizyt
5. Odhaczanie, czy wizyta si� odby�a

## Opis dzia�ania

1. Logowanie 
- Uzytkownika moze stworzyc inny uzytkownik (lekarz, sekretarka) po rejestracji osoby w edycji tej osoby (nadanie loginu i hasla)
- Uzytkownik loguje sie podanym loginem i haslem lub anuluje logowanie, co wi��e si� z zamkni�ciem aplikacji

2. Panel dzia�a�
- W panelu dzia�a� znajduj� si� przyciski:
  - Pacjenci: Lista obejmuje wszystkich pacjent�w gabinetu. Klikni�cie w rekord powoduje wej�cie do widoku. Z tego poziomu mo�na planowac wizyt� dla danego pacjenta po klikni�ciu przycisku Planuj wizyt� na jego rekordzie.
  - Rejestracja pacjenta (tylko sektretarka): Formularz umo�liwia zapis w bazie podstawowych danych iosobowych pacjenta (imi�, nazwisko, adres, telefon, email, pesel).
  - Zaplanowane wizyty (lekarz widzi swoje, sekretarka widzi wszystkie): Lista wy�wietla infromacj� o zaplanowanej wizycie: kto, jaki lekarz (je�eli dla sekretarki), dat� i godzin�, czy zrealizowana..
  - Zaplanuj wizyt� :Formularz umo�liwia zaplanowanie wizyty pacjenta, znajduj�cego si� ju� w bazie danych u lekarza. Pacjenta nale�y wybrac z listy rozwijanej, podobnie jak lekarza. Dat� mo�na wybra� w polu edycyjnym z kalendarza lub wpisa� r�cznie. Godzin� nale�y wpisac r�cznie. Je�eli lekarz ma zaplanowan� wizyt� na podan� godzin�, zaplanowanie nie b�dzie mo�liwe. Wizyta jest planowana na 30 minut. W tym czasie nie mo�na um�wi� innej wizyty u danego lekarza. Pole zaznaczenia, czy wizyta si� odby�a, przeznaczone jest dla lekarza. W polu informacje zar�wno sekretarka mo�e wpisywac informacje o pacjencie, jak i lekarz mo�e uzupe�nia� "kart� pacjenta".
  - Wyloguj: Przycisk umo�liwia wylogowanie z systemu. Do czasu ponownego zalogowania, nie ma mo�liwo�ci wprowadzania zmian w systemie.
  - Zamknij: Przycisk zamyka aplikacj�.



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