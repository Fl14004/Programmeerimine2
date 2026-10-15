# Projektijuhtimine – ettevalmistatud Visual Studio lahendus

Lahendus sisaldab `Projektijuhtimine.Application` klassiteeki, `Projektijuhtimine.WebAPI` API projekti, kuut andmemudelit, `ApplicationDbContext` klassi ja `SeedData` näidisandmeid.

## Käivitamine
1. Ava `Projektijuhtimine.sln` Visual Studio 2022/2026-s.
2. Kontrolli, et SQL Server LocalDB on installitud. Ühendus on `appsettings.json` failis. Vajadusel muuda seda oma SQL Serveri järgi.
3. Paremklõps `Projektijuhtimine.WebAPI` → Set as Startup Project.
4. Build → Build Solution.
5. Käivita WebAPI. Esmakäivitus loob andmebaasi ja algandmed. Swagger avaneb `/swagger`.

## Andmebaasi näidisandmed
SeedData lisab vähemalt 35 kasutajat, projekti, projekti-liikme seost, ülesannet, töölogi ja manust. Seostabelites on täiendavaid ridu. API näited: `/api/users`, `/api/projects`, `/api/tasks`, `/api/worklogs`, `/api/attachments`.

## Migratsioonid (õpetaja ülesande jaoks)
See komplekt kasutab esmakäivitamisel `EnsureCreatedAsync`, et andmebaas saaks ilma eelneva migratsioonita tööle. EF Core migratsioonide kasutamiseks: (1) eemalda olemasolev `ProjektijuhtimineDb` andmebaas, (2) muuda Program.cs `EnsureCreatedAsync()` asemel `MigrateAsync()`, (3) Package Manager Console: `Add-Migration InitialCreate -Project Projektijuhtimine.Application -StartupProject Projektijuhtimine.WebAPI`, (4) käivita `Update-Database`. Ära kasuta `EnsureCreated` ja migratsioone koos.

## Tähtis
See on sinu klassiskeemi põhjal loodud eraldiseisev algprojekt, sest üles laaditud ZIP sisaldas ainult klassiskeemi ja dokumentatsiooni, mitte olemasolevat `.sln` rakendust. Selles keskkonnas ei olnud .NET SDK-d, seega ei saanud siin buildi reaalselt käivitada. Ava lahendus oma arvutis ja kontrolli Build Solution. Parooliväljad on demoandmed, mitte päris autentimise lahendus.
