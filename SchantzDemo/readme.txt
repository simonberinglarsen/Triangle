Designbeslutninger og Implementeringsvalg:

Design:
* Jeg har inddelt programmet i namespaces/områder, da det er en vigtig del af system udvikling - det er en del af "arkitekturen", og hjælper os med at overskue udbygning og vedligehold når det bliver kompliceret.
* Jeg har valgt at implementere programmet som consoleapp. for at have noget konkret at køre
* Det er trekanten selv der ved hvilken type den er - ud fra dens sider
* Resterende klasser der opererer på domænet eller bruger-input findes i "Services" namespacet
* Jeg har valgt at lave en primitiv udgave af et factory pattern, da jeg mistænker at forretningen nok har flere krav til hvordan trekanten skabes. Jeg udbygger det ikke før jeg har mere viden om hvad fremtiden bringer for vores trekant.
* Parsing af inputs er flyttet til en selvstændig klasse der håndterer den del.
* Logning foretages også af en selvstændig klasse
* Generelt forsøger jeg at overholde Single Responsibility - een klasse et ansvar.
* Jeg har lagt unittests i et seperat projekt, så de ikke deployes til prod sammen med min kode
* Unit tests følger namespace strukturen fra applikationen
* Unit tests tester grænseværdier for at sikre at applikationen er rubust.

Implementeringsvalg:
* Jeg har valgt at udbygge løsningsrummet til at indeholde "ikke gyldig", da det kan være misvisende at returnere "Andet" til en ugyldig trekant (specielt hvis jeg andre applikationer afhænger af mit output)
* Jeg udskriver sidernes længde sammen med svaret for at vise brugeren hvordan programmet forstår inputtet (f.eks. med "dansk" regional setting er 3.111 det samme som 3111 :))
* Inputtet til trekanten angives som argumenter til en console app.
* Loggeren skriver direkte til console-vinduet (men bruger et prefix ERROR når der logges)
* Applikationen skriver også til console-vinduet. (her kunne man måske overveje at bruge stdout og stderr til output for app og log)
* Jeg har valgt at trekantens (som er vores domæne) sider repræsenteres ved 3 floats. Float er et tilnærmet tal, og jeg vurderer det passer fint til et længdemål. Sammenligning kan blive et problem alt efter hvordan programmet bruges, og man kan overveje at indføre en fejl tolerance.
* Jeg har brugt autofac til håndtere afhængigheder
* Jeg har brugt Moq til at skabe mock-klasser i unit testen.

Jeg håber jeg har demonstreret noget af det i ønsker at se, og håber jeg får lov til at uddybe mine kompetencer ved en samtale :)










