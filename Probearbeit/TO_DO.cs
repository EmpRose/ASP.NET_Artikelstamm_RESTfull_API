
//To do:

// Funktion
// Sprache wird unabhängig von [DevaultValue(0)] bzw "Deutsch" auf null gesetzt. Fehlt Routing oder DI?
// => Das Resultat daraus : Artikel.IstFertig bleibt bei "false" da "Sprache" als "null" gesetzt wird

// Refactoring
// listen von Klassen aller Auswahloptionen (Farbe, SpracheKontext etc) anlegen => interfaces erzeugen, Artikel realisiert alle interfaces
// Dependency Injection Artikel das alle Interfaces realisiert
// IstFertig => als methode implementieren und bei Post und Put einsetzen. 






//Erledigt:
// Kontext 
// Artikel- Klasse, die Auf eine Auflistung der Sprachen zugreift. Marke, Farbe etc Listen sind in der Aufgabenstellung nicht beschrieben und entfallen vorerst
// SprachenKontext Auflistung mit "bool" oder "enum" => enum to DefaultValue https://stackoverflow.com/questions/529929/choosing-the-default-value-of-an-enum-type-without-having-to-change-values


// Datenbank
// DbSet erzeugen für Artikel"s" (InMemory => Für GitHub) (Microsoft.EntityFrameworkCore)
// DbSet in "Program.cs" Klasse hinterlegen // Dependency Injection
// Routing im Controller

// HttpRequests
// => Post,     Check
// => Get,      Check
// => Put,      Check
// => Delete    Check
// => GetFilter Check (Nicht komplett eigenständig erstellt <= übernommen und angepasst)
// => GetByTimeStamp  (Nicht komplett eigenständig erstellt <= übernommen und angepasst)
// => GetTitel  Check (Nicht komplett eigenständig erstellt <= übernommen und angepasst)
// => Testen (Ok!)


//Methoden
// Filter vom Zeitstempel "von - bis"                                               <= Zeiterfassung beim erstellen des Artikels vorhanden
// => Nutzen von Linq => erfahren wie es geht. LINQ .. mhhhh

// Methode - VerboteneWorte
// => als separate Methode die aufgerufen wird (Wo will ich sie hinterlegen? =))    <= Beim Post und Udpate
// => Liste von Worten erzeugen                                                     <= Als Eigene Klasse

