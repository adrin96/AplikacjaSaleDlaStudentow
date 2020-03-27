--1. Kierunki
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (1,'Informatyka','Inzynierskie   ',3.5);
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (2,'Zarzadzanie','Licencjackie   ',3);
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (3,'Pedagogika','Licencjackie   ',3);
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (4,'Polonistyka','Licencjackie   ',3);
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (5,'Filologia angielska','Licencjackie   ',3);
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (6,'Budownictwo','Inzynierskie   ',3.5);
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (7,'Energetyka','Inzynierskie   ',3.5);
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (8,'Mechanika','Inzynierskie   ',3.5);
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (9,'Zielarstwo','Inzynierskie   ',3.5);
Insert into Kierunki (ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA) values (10,'Pielegniarstwo','Licencjackie   ',5);

--2. Studenci
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (23821,'Adrian','K',667283440,1);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (23521,'Baka','Zuzanna',345872842,1);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (23822,'Mateusz','Borowiec',123456789,1);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (23823,'Tymon','Choromański',null,1);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (23824,'Joanna','Kurpka',null,1);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (24321,'Joanna','Ząbek',null,2);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (24322,'Maria','Pas',null,2);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (24323,'Łukasz','Jaki',null,2);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (24324,'Adam','Mak',123456731,2); 
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (24325,'Adrian','Nowak',772866371,5); 
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (24326,'Barańska','Natalia',772866321,6)
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (24327,'Julia','Prokop',772866321,7);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (24329,'Adam','Krzak',772866321,8);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU) values (24330,'Natalia','Kotek',662752422,8);
Insert into Studenci (NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU)values (24335,'Mateusz','Gabor',732865432,9);


--3. Sale
Insert into Sale (ID_SALI,NAZWA,OPIS) values ('1','Konferencyjna','W tej sali mogą odbywać się różnego rodzaju spotkania. Mniej lub bardziej oficjalne.');
Insert into Sale (ID_SALI,NAZWA,OPIS) values ('2','Imprezowa','Sala o dużej powierzchni, którą można wynająć na różnego rodzaju okoliczności studenckie jak Juwenalia.');
Insert into Sale (ID_SALI,NAZWA,OPIS) values ('3','Uczelnia','Sala do nauki');

--4. Przedmioty 
Insert into PRZEDMIOTY (ID_PRZEDMIOTU,NAZWA,OPIS,ILOSC,ID_SALI) values ('1','Kula dyskotekowa','Kula typu disco','1','2');


--5. Biura
Insert into BIURA (ID_BIURA,NAZWA,ADRES) values ('1','Glowne','Warszawa ul.Kwiatkowska 32');
Insert into BIURA (ID_BIURA,NAZWA,ADRES) values ('2','Pracownicze','Krosno ul.Podkarpacka 32');

--6. Pracownicy
Insert into PRACOWNICY (ID_PRACOWNIKA,IMIE,NAZWISKO,PENSJA,DATA_ZATRUDNIENIA,ID_BIURA,ID_PRZELOZONEGO,STANOWISKO)  VALUES (1,'Adam','Szefowski','3500','2003-12-18 14:00:00','1',null,'Kierownik');
Insert into PRACOWNICY (ID_PRACOWNIKA,IMIE,NAZWISKO,PENSJA,DATA_ZATRUDNIENIA,ID_BIURA,ID_PRZELOZONEGO,STANOWISKO)  VALUES (2,'Katarzyna','Cios','2100','2019-12-19 10:00:00','2','1','Recepcjonista');
insert into PRACOWNICY (ID_PRACOWNIKA,IMIE,NAZWISKO,PENSJA,DATA_ZATRUDNIENIA,ID_BIURA,ID_PRZELOZONEGO,STANOWISKO)  VALUES (3, 'Andrzej', 'Mazur',0,'2020-01-20', 2, 1,null);

--7. Rezerwacje
Insert into REZERWACJE (ID_REZERWACJI,REZERWACJA_OD,REZERWACJA_DO,CENA,NR_ALBUMU,ID_SALI,ID_PRACOWNIKA) VALUES ('1','2019-12-19 11:35:00','2019-12-21 11:35:00','300','23821','2','2');



