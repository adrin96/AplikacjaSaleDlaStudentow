--1. SELECT Z JOIN
-- Studenci kierunku Informatyka
select  s.Imie, s.Nazwisko, k.Nazwa_kierunku 
from kierunki k
join studenci s on k.id_kierunku=s.id_kierunku 
where k.nazwa_kierunku = 'Informatyka';


-- Nazwy przedmiotow w sali Konferencyjnej
select s.nazwa as NazwaSali, p.nazwa as NazwaPrzedmiotu
from sale s
join przedmioty p on s.id_sali = p.id_sali
where s.nazwa = 'Konferencyjna';


-- Rezerwacje na sale Imprezową warte wiecej niz 200 zl, z danymi Pracownika i Studenta
select stu.imie as ImieStudenta,stu.nazwisko as NazwiskoStudenta,r.Cena ,
p.imie as ImiePracownika,p.nazwisko as NazwiskoPracownika,sal.nazwa as NazwaSali
from studenci stu
join rezerwacje r on stu.nr_albumu = r.NR_ALBUMU
join pracownicy p on p.id_pracownika = r.ID_PRACOWNIKA
join sale sal on sal.id_sali = r.id_sali
where cena > 200 and sal.nazwa = 'Imprezowa';


--2. SELECT Z GROUP BY
-- Liczba studentów na danym kierunku
select Nazwa_Kierunku, count(*) as LiczbaStudentów
from studenci
join kierunki on kierunki.ID_KIERUNKU = STUDENCI.ID_KIERUNKU
group by NAZWA_KIERUNKU 
order by LiczbaStudentów desc


-- Liczba przedmiotow w poszczególnych salach
select s.NAZWA, count(*) as LiczbaPrzedmiotow
from przedmioty p
join sale s on s.id_sali = p.id_sali
group by s.nazwa

-- Liczba rezerwacji obsłużonych przez pracownika Katarzyna
select count(*) as LiczbaRezerwacji, Imie, Nazwisko
from Pracownicy
where imie = 'Katarzyna'
group by Imie, Nazwisko



--3. Podzapytania
-- Których przedmiotów jest więcej niż Drukarek
select Nazwa,Ilosc from przedmioty 
where ILOSC >  (select ILOSC from przedmioty where nazwa like 'Drukarka 3w1')
order by ilosc desc;


-- Pracownicy ktorzy maja przelozonego 
select * from pracownicy where id_pracownika in 
(select ID_PRACOWNIKA from pracownicy where ID_PRZELOZONEGO is not null)

-- Liczba kierunków danego typu_studiow, które trwają krócej niż kierunek 'Pielegniarstwo'
select count(*)as LiczbaKierunków,Typ_Studiow,Czas_Trwania from kierunki
where czas_trwania < 
(select czas_trwania from kierunki where nazwa_kierunku = 'Pielegniarstwo')
group by TYP_STUDIOW,CZAS_TRWANIA;


--4. Perspektywa złożona
-- Wszyscy pracownicy z biura 'Pracownicze'
create view PracownicyPracownicze
as
select b.Nazwa as NazwaBiura, b.Adres, p.Imie, p.Nazwisko
from biura b
right join pracownicy p on p.id_biura = b.id_biura
where b.nazwa = 'Pracownicze';

-- Imiona, nazwiska i numer albumu osób z kierunku Zarządzanie
create view osobyZarzadzanie
as
select  s.Imie, s.Nazwisko, s.Nr_albumu
from kierunki k
join studenci s on k.id_kierunku=s.id_kierunku
where k.nazwa_kierunku = 'Zarzadzanie';

-- Rezerwacje na sale Imprezową
create view rezerwacjeImprezowa as
select stu.Imie as ImieStudenta,stu.Nazwisko as NazwiskoStudenta,stu.Nr_albumu, 
prac.Imie as ImiePracownika, prac.Nazwisko as NazwiskoPracownika, Nazwa 
from rezerwacje r
join studenci stu on stu.NR_ALBUMU = r.NR_ALBUMU
join pracownicy prac on prac.ID_PRACOWNIKA = r.ID_PRACOWNIKA
join sale on sale.ID_SALI = r.ID_SALI
where nazwa = 'Imprezowa';

