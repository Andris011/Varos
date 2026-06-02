# 11.D Város Projekt

## A csapatok kiosztása

### 1. Csapat: Lakosság
- Nguyen Van Tamás (Csapatvezető)
- Szilágyi Domonkos
- Major Bence

### 2. Csapat: Gazdaság
- Fata Dávid (Csapatvezető)
- Kereszturi Balázs
- Csíkszentmihályi Döme
- Pongor Márk

### 3. Csapat: Epületek
- Fébert András (Csapatvezető)
- Juhász Cecília
- Fodor Balázs
- Béki Zsolt

### 4. Csapat: Események
- Gyárfás Bálint (Csapatvezető)
- Heim Péter Máté (Csapatvezető helyettes)
- Huszti Tamás
- Rábai Miklós

## Dokumentáció

### Áttekintés

A projekt egy város működését próbálja szimulálni emberekkel, epületekkel, eseményekkel és működő egy gazdasággal. A szimulált város egy a forint értékéhez közeli, meg nem nevezett pénznemet használ a fizetések, költségek, adók számításakor. Az objektumorientált programozáshoz megfelelő módon, több osztállyal van kialakítva a végső projekt, amelyek csoportokra bonthatók az általuk ellátott feladat szempontjából. Ezek a csoportok a mapparendszer szerint a következők: Epület, Események, Gazdaság, Lakosság, és Szimuláció.

### Fő osztályok, és kapcsolataik

- **SzimulacioMotor**: Felel a város kezdőállapotának kialakításáról (a SzimulacioEpito osztállyal együttműködve), és futtatja a szimulációt (EsemenyMotor, Allam és más osztályokat használva).
- **SzimulacioEpito**: Véletlenszerűen készíti el a szimuláció kezdő állapotát, epületeket helyez el, emberek készít és ad nekik munkát, cégeket alapít.
- **EsemenyMotor**: A véletlen események indításáért és a heti lottó húzásért felel.
- **Ember**: A szimuláció egészén használt. Követi az emberek életkorát, házassági állapotát, és a lakosság növekedését/csökkenését is megvalósítja.
- **Allam**: Egy ország gazdaságát modellezi. Számontartja az állampolgárokat, cégeket, és az államnak elérhető pénzösszeget. Nyugdíjat fizet a rá jogosult állampolgároknak.
- **Bankszamla**: Abstract osztály, amiből két bankszámlatípus van származtatva. Minden pénzügyi tranzakció rajta keresztül valósul meg.
    - **MaganBankszamla**: Egy bankszámla, amiben long típusként számon van tartva a jelenlegi egyenleg.
    - **AllamiBankszamla**: Végtelen pénzzel rendelkező számla. Eredetileg az állam használta, de azóta leváltásra került egy MaganBankszamla példánnyal, így most használatlan.
- **Lotto**: A heti lottó sorsolásért felelős. Számontartja a jackpot összegét, és lehetővé teszi az emberek számára a szelvények vásárlását.
- **Epulet**: Az épület osztály ősosztálya minden a városban megtalálható épületnek. A közöttük mind megjelenő adattagokat (mint a karbantartottsági szintjük), és metódusokat (Foldrenges()) tartalmazza.

### A program működése ábrázolva

<h4 align="center">A szimuláció felépítése</h4>

```mermaid
flowchart LR
    motor["Szimulációs Motor (SzimulacioMotor.cs)"]

    subgraph epito_graph[Szimuláció Építő]
        epito_epulet_ososztaly["Epület ősosztály származtatottjai (Korhaz.cs, ...)"]
        epito_ember_osztaly["Ember (Ember.cs)"]
        epito_ceg_osztaly["Cég (Ceg.cs)"]

        epito["Szimuláció Építő (SzimulacioEpito.cs)"]

        epito -- Épületek elhelyezése --> epito_epulet_ososztaly
        epito -- Emberek létrehozása --> epito_ember_osztaly
        epito -- Cégek létrehozása, emberek felvétele --> epito_ceg_osztaly
    end

    subgraph ciklus_graph[Szimuláció Ciklus]
        direction TB
        
        subgraph esemeny_graph[Esemény Motor]
            esemeny_esemeny_osztalyok["Esemény osztályok (Karacsony.cs, ...)"]
            esemeny_lotto_osztaly["Lottó rendszer<br>(Lotto.cs, ...)"]

            esemeny["Esemény Motor (EsemenyMotor.cs)"]

            esemeny --> esemeny_esemeny_osztalyok
            esemeny --> esemeny_lotto_osztaly
        end

        ciklus["Szimuláció ciklus"]

        ember_heti["Minden ember Hetente() metódusa"]
        epulet_heti["Minden epület Hetente() metódusa"]
        gazdasag_heti["Állam példány Hetente() metódusa"]

        ciklus -- Periodikus események indítása --> esemeny_graph

        ciklus -- Öregedés, várandósság --> ember_heti
        ciklus -- Állami intézmények költségei --> epulet_heti
        ciklus -- Fizetések, nyugdíjak --> gazdasag_heti
    end

    motor -- A város véletlenszerű felépítése --> epito_graph
    epito_graph -- A szimuláció indítása --> ciklus_graph
```


<h4 align="center">A szimulációs motor működése</h4>

<div align="center">

```mermaid
flowchart TD
    kezdet[A szimuláció kezdete]
    
    kiiratas[A szimuláció állapotának kiírása]
    heti_lepes[Hetek számának növelése, emberek, epületek, állam heti frissítése]
    esemenyek[Események indítása]
    szimulacio_vege[A szimuláció véget ér]
    szimulacio_feltetel{"Van ember, epület, pénz?"}

    kezdet --> szimulacio_feltetel -- IGEN --> kiiratas
    kiiratas --> heti_lepes --> esemenyek --> szimulacio_feltetel

    szimulacio_feltetel -- NEM ----> szimulacio_vege
```

</div>