# Projektijuhtimine – klasside dokumentatsioon

## 1. User

Süsteemi kasutaja. Süsteemi saavad kasutada ainult sisse loginud kasutajad.

| Väli | Tüüp | Kirjeldus |
|---|---|---|
| id | Integer | Kasutaja unikaalne ID |
| username | String | Kasutajanimi |
| email | String | Kasutaja e-posti aadress |
| password | String | Kasutaja parool |

## 2. Project

Kirjeldab ettevõtte projekti.

| Väli | Tüüp | Kirjeldus |
|---|---|---|
| id | Integer | Projekti unikaalne ID |
| name | String | Projekti nimi |
| startDate | Date | Projekti alguskuupäev |
| deadline | Date | Projekti tähtaeg |
| budget | Decimal | Projekti eelarve |
| hourlyRate | Decimal | Projekti tunnihind |

Ühel projektil võib olla mitu ülesannet ja mitu meeskonnaliiget.

## 3. ProjectMember

Seob kasutajad projektidega ning kirjeldab projekti meeskonda.

| Väli | Tüüp | Kirjeldus |
|---|---|---|
| id | Integer | Seose unikaalne ID |
| projectId | Integer | Projekti ID |
| userId | Integer | Kasutaja ID |

Üks kasutaja võib kuuluda mitmesse projekti ja ühes projektis võib olla mitu kasutajat.

## 4. Task

Kirjeldab projekti tööülesannet.

| Väli | Tüüp | Kirjeldus |
|---|---|---|
| id | Integer | Ülesande unikaalne ID |
| projectId | Integer | Projekti ID |
| title | String | Ülesande pealkiri |
| startDate | Date | Ülesande alguskuupäev |
| estimatedHours | Decimal | Eeldatav ajakulu tundides |
| fixedPrice | Decimal? | Fikseeritud hind, kui ülesandele on määratud fikseeritud hind |
| responsibleUserId | Integer | Ülesande vastutaja kasutaja ID |
| description | Text | Ülesande kirjeldus |
| isCompleted | Boolean | Kas ülesanne on valmis |

Üks projekt võib sisaldada mitut ülesannet. Ülesanne ei pea sisaldama alamülesandeid.

## 5. WorkLog

Kirjeldab ühe ülesande tegelikult tehtud tööd ehk töölogi.

| Väli | Tüüp | Kirjeldus |
|---|---|---|
| id | Integer | Töölogi unikaalne ID |
| taskId | Integer | Ülesande ID |
| date | Date | Töö tegemise kuupäev |
| hours | Decimal | Tegelik ajakulu tundides |
| userId | Integer | Töö tegija kasutaja ID |
| description | Text | Tehtud tegevuse kirjeldus |

Ühel ülesandel võib olla mitu töölogi.

## 6. Attachment

Kirjeldab ülesande juurde lisatud faili.

| Väli | Tüüp | Kirjeldus |
|---|---|---|
| id | Integer | Faili unikaalne ID |
| taskId | Integer | Ülesande ID |
| fileName | String | Faili nimi |
| filePath | String | Faili asukoht |
| uploadedAt | DateTime | Faili üleslaadimise aeg |
| userId | Integer | Faili üleslaadinud kasutaja ID |

Ühe ülesande juurde võib lisada mitu faili, näiteks dokumente või jooniseid.

# Klasside vahelised seosed

- User 1:N ProjectMember
- Project 1:N ProjectMember
- Project 1:N Task
- User 1:N Task (vastutaja)
- Task 1:N WorkLog
- User 1:N WorkLog (teostaja)
- Task 1:N Attachment
- User 1:N Attachment (üleslaadija)

# Arvutusloogika

Projekti senine maksumus arvutatakse töölogide põhjal.

Tavalise ülesande korral:

`kulu = töölogide tunnid × projekti tunnihind`

Kui ülesandele on määratud fikseeritud hind:

`kulu = fixedPrice`

Ülesande tegelik ajakulu saadakse selle ülesande kõigi töölogide tundide summana:

`tegelik ajakulu = SUM(WorkLog.hours)`

Nii saab võrrelda ülesande eeldatavat ajakulu (`estimatedHours`) ja tegelikku ajakulu.

Projektis saab võrrelda projekti eelarvet (`budget`) ja senist maksumust.
