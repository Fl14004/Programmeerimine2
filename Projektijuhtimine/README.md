# Projektijuhtimine – Get/List päringud CQRS-i ja MediatR-iga

Lahendus sisaldab Application klassiteeki, kuut andmemudelit, ApplicationDbContexti ning kõigi DbSetide jaoks Get/List querysid, handlereid ja WebAPI kontrollereid.

## Käivitamine
1. Ava `Projektijuhtimine.sln` Visual Studios.
2. Kontrolli `appsettings.json` SQL Serveri ühendust (`DefaultConnection`).
3. Sea `Projektijuhtimine.WebAPI` käivitusprojektiks.
4. Build → Build Solution.
5. Käivita API ja ava `/swagger`. Esmakordsel kasutamisel loo andmebaas EF migratsioonide abil või lisa andmebaasi tabelid enne päringute testimist.

## API aadressid
Iga kontroller pakub `GET /api/{Kontroller}/get/{id}` ja `GET /api/{Kontroller}/list`. Kontroller tagastab `NotFound()` kui ID on 0 või väiksem või kui Get-päring ei leia kirjet.

Kontrollerid: Users, Projects, ProjectMembers, Tasks, WorkLogs, Attachments.

## Märkus
ZIP sisaldas algselt ainult WebAPI projekti viiteid, klassiskeemi ja dokumentatsiooni, mitte Application projekti ega mudelite lähtekoode. Application projekt ja mudelid on nüüd loodud klasside dokumentatsiooni põhjal. Käivita Visual Studios Build Solution ja kontrolli enda SQL Serveri ühendust. Andmebaasi tabelite loomiseks kasuta Package Manager Console'is: `Add-Migration InitialCreate -Project Projektijuhtimine.Application -StartupProject Projektijuhtimine.WebAPI`, seejärel `Update-Database`.
