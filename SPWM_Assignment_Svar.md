

Del 1)

Oppgave 1a) Implementer formelen i C#

Kode er tilgjengelig på "TWRCalculator.cs". 

TWR: −0,0455347578377396701790027931

For å sikre en god implementering og bærekraftig kode la jeg også til noen tester for ulike
scenarioer: Kode er tilgjengelig på "TWRCalculatorTest"

Oppgave 1b) Implementer formelen i T-SQL

Satt opp en SQL-server på localhost og brukte Azure data studio.
Opprettet en midlertidig tabell og brukte LOG/EXP-tilnærmingen for å beregne produktet,
siden T-SQL mangler muligheten for multiplisering.

Kode er tilgjengelig på "TWRCalculation.sql"

1c) Hvilken av metodene er mest effektive?
Akkurat hvilken tilnærming jeg ville brukt, avhenger litt av konteksten. Kort sagt kan det
rangeres på følgende måte fra raskest til tregest:

1. C# med verdier allerede lastet inn i minne. Dette vil være raskest, men er ofte ikke
realistisk.

2. T-SQL med verdier allerede plottet inn i en tabell. Denne er mer realistisk i et
utviklingsmiljø, der dataen ofte ligger i en database og man kanskje "kjapt" vil sjekke
hva som blir utregningen i TWR i en gitt periode.

3. C# der verdier må hentes fra database. I/O operasjoner tar ofte lang tid, og forverrer
effektiviteten betydelig i et eksempel som dette.

I et produksjonsmiljø ville jeg valg C# som løsning, selv om dette betyr at jeg velger 3. fra
listen ovenfor. Det er fordi T-SQL har sine begrensninger, kompleks logikk blir fort
uoversiktlig, og det er vanskelig å skrive ordentlige tester.

På den andre siden, vil C# gi bedre testbarhet, lettere vedlikehold, og mulighet for skalering
ved å kjøre flere servere parallelt. I tillegg vil versjoneringsverktøy som Git gjøre det enklere
å kontrollere hvilken kode som kjøres, og rulle tilbake ved eventuelle feil i prodmiljøet. Ved å
bruke caching i c# kan vi også få bedre ytelse enn ren SQL. Første utregning vil ta litt lenger
tid ettersom man må ut i databasen, men de etterfølgende utregningene vil være svært kjappe.
Min tilnærming vil være å bruke C# for API-er og brukerforespørsler, mens SQL-scripts kun
brukes for tunge batch-jobber, eller raske forespørsler som ikke skal automatiseres, hvor det
faktisk gir betydelig ytelsesgevinst. Dette gir en kodebase som er enklere å vedlikeholde,
samtidig som vi utnytter SQL der det er hensiktsmessig.

Del 2) – School map app

1) Hvordan kunne kartet og informasjonen vises til brukeren, hvordan ville vi utvikle det?
    Mitt første spørsmål ville vært: Hva er brukerens faktiske behov?
    
    Foreldre som skal velge skole eller bolig trenger ikke å se alle 500 skoler i Oslo på et kart
    samtidig. Det blir bare visuelt kaos. Jeg ville designet løsningen rundt hva brukeren trenger.
    Gi de muligheten til å definere område, aldersgruppe, ønsket karakternivå, deretter presenter
    de 5 til 10 beste alternativene i en oversiktlig liste. Først når de har avgrenset søket viser vi
    kartvisning. Teknisk sett ville jeg brukt Google Maps API for selve kartet, siden jeg vet at det
    fungerer, med fargegradering som gjør det lett å skille høy- og lavpresterende skoler visuelt.
    Det viktigste er å unngå "information overload" for brukeren i denne applikasjonen og for
    best mulig UX.

2) PC, Mac, Mobile - hvilke versjoner av applikasjonen bør vi utvikle?

    Her handler det om ressursbruk versus brukerbehov. Å bygge separate apps for iOS, Android
    og PC krever ulike koderbaser. Det er kostbart og tidkrevende. Jeg ville startet med en
    responsiv webløsning ved hjelp av .Net og Angular/React som er responsiv, og som fungerer
    på begge plattformene. Siden dette er en app bruker maksimalt en gang i året, er det liten
    grunn til å investere i mobilapper, men hvis vi senere ser at mesteparten av trafikken kommer
    fra iOS/Android kan man vurderer en app i fremtiden.

3) Ser du noen problemer med betaling, hva er din anbefaling her?

    Betaling krever at vi håndterer GDPR korrekt og sikrer brukerdata, noe som er komplekst
    men løsbart med moderne betalingsløsninger. Min hovedbekymring er at 10kr per bruk føles
    dyrt for noe foreldre bruker én gang når de skal velge skole. Jeg ville vurdert alternative
    modeller: Freemium hvor grunnleggende skoleinformasjon er gratis men detaljerte analyser
    og sammenligninger koster, abonnement for foreldre som vurderer flere skoler over tid, eller
    annonsering, som trolig kan påvirke tilliten til rangeringen, men kan være et alternativ. For
    selve betalingsløsningen ville jeg brukt Vipps som håndterer sikkerhet.

4) Brukerautentisering, dine tanker om dette?

    Autentisering er nødvendig både for betaling og for å spore bruk. Siden vi uansett trenger
    betalingsløsning, kan vi utnytte at Vipps allerede har innebygd autentisering, hvor brukere
    logger inn via Vipps, betaler, og vi får verifisert identitet i én prosess. Dette forenkler teknisk
    kompleksitet betydelig. Jeg ville også latt abonnementstypen styre autentiseringskravet:
    Freemium-brukere kan se grunnleggende info uten innlogging, men må autentisere for å lagre
    favoritter eller få tilgang til detaljerte analyser. Abonnement-brukere må selvfølgelig
    autentisere fra start siden de betaler månedlig. Dette gir oss også verdifulle data om
    brukermønstre uten å skape unødvendige barrierer for folk som bare vil kikke raskt.

5)  Når kan du ha applikasjonen ferdig?

    Det avhenger helt av scope og hva som faktisk kreves i første versjon. Vi må avklare
    handlingskrav fra oppdragsgiver. Min tilnærming ville vært å definere en MVP som dekker
    kjernebehovet som er kartvisning med skolegrenser, grunnleggende karakterdata,
    søk/filtrering, og enkel autentisering/betaling. Dette ville jeg estimert til 3-4 måneder med et
    lite team. Deretter trenger vi en testperiode for å samle bruker-feedback og justere før full
    lansering. Videre utvikling med flere «features» som for eksempel historiske trender,
    brukeranmeldelser er utenfor MVP og kommer i neste iterasjon. Cirka 4-7 måneder. Her
    tenker jeg at det er bedre å planlegge for lengre tid, slik at man får tid til testing og sikre at
    produktet er klart for lansering.

6) Andre bekymringer
    Min hovedbekymring er om foreldre faktisk vil betale for dette når mye skoleinformasjon
    allerede er tilgjengelig gratis på kommunens nettsider. Vi må skape tydelig merverdi som
    kanskje å kombinere med andre relevante faktorer som skolemiljø, trivselsmålinger, ikke bare
    karakterer. Vi bør inkludere kvalitativ data og feedback fra både elever og foreldre for et mer
    helhetlig bilde.

    Problemet er å få dette til å bli lønnsomt med tanke på betalingsløsningen. Det gir ikke
    mening at man skal ha et abonnement på et valg man tar en gang. Eller hvis man velger
    løsningen med annonser så kan ulike skoler betale for annonser som svekker tilliten til
    applikasjonen vår. En annen løsning kan være å inngå en kontrakt med ulike kommuner slik at
    de får en fullverdig oversikt over hvilke skoler som gjør det godt, og hvilke skoler de må sette
    inn tiltak på. Appen kan derfor brukes av både foreldre, elever og kommuner.
