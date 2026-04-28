// See https://aka.ms/new-console-template for more information
using OOP_Timur;

Console.WriteLine("=== HARJUTUS 8: VANUSE KONTROLL JA EXCEPTION ===\n");

// Näitame try-catch tööd
try
{
    Console.WriteLine("Proovime luua õpilase vale sünniaastaga (2030):");
    Õpilane test = new Õpilane();
    test.Nimi = "Test";
    test.Sünniaasta = 2030; // See viskab vea
    test.Kirjelda();
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Viga püütud kinni: {ex.Message}\n");
}

try
{
    Console.WriteLine("Proovime luua õpetaja õige sünniaastaga (1985):");
    Õpetaja test2 = new Õpetaja();
    test2.Nimi = "Tõnu";
    test2.Sünniaasta = 1985;
    test2.Aine = "Sport";
    test2.Tervita();
    Console.WriteLine("Edukalt loodud!\n");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Viga: {ex.Message}\n");
}

// Klassi Õpilane ja Õpetaja näited.
// Päritud Isik klassist, seega saavad kasutada Isiku omadusi ja meetodeid
Õpetaja õpetaja1 = new Õpetaja();
õpetaja1.Nimi = "Eve";
õpetaja1.Sünniaasta = 1980;
õpetaja1.Aine = "Matemaatika";
õpetaja1.Tervita(); // Väljund: Tere! Mina olen Eve...
õpetaja1.Õpeta(); // Väljund: Eve õpetab ainet: Matemaatika.
õpetaja1.Kirjelda(); // Väljund: Mina olen õpetaja Eve ja ma õpetan: Matemaatika.

Console.WriteLine("\n--- Õpilase andmed ---");
// 2. Loome Õpilase objekti
Õpilane õpilane1 = new Õpilane();
// Päritud Isik klassist
õpilane1.Nimi = "Markus";
õpilane1.Sünniaasta = 2008;
// Spetsiifilised Õpilane klassile
õpilane1.Kool = "Kutsehariduskeskus";
õpilane1.Klass = 10;
// Päritud meetod
õpilane1.Tervita();
// Õpilase enda meetod
õpilane1.Õpi();
// Ootame kasutaja sisestust, et konsooliaken kohe ei sulguks
õpilane1.Kirjelda();

Koolihaldus minuKool = new Koolihaldus();
minuKool.LisaInimene(õpetaja1);
minuKool.LisaInimene(õpilane1);

// Polümorfismi näide: ITööline liides ja erinevad klassid, mis seda rakendavad
List<ITööline> palgasaajad = new List<ITööline>();
//Lisa siia tsükli või eraldi rida, et lisada õpetajaid ja õpilasi, kes saavad palka/toetust
//1 .Variant täitmine eraldi ridadega
Õpilane mati = new Õpilane();
mati.Nimi = "Mati";
mati.Sünniaasta = 2010;
mati.KeskmineHinne = 4.0;
minuKool.LisaInimene(mati);
palgasaajad.Add(mati);

Õpilane kadi = new Õpilane { Nimi = "Kadi", Sünniaasta = 2009, Klass = 11, Kool = "Kutsehariduskeskus", KeskmineHinne = 3.5, Puudumised = 5, KasOnSotsTõend = false };
minuKool.LisaInimene(kadi);
palgasaajad.Add(kadi);

Õpilane jüri = new Õpilane { Nimi = "Jüri", Sünniaasta = 2008, Klass = 12, Kool = "Kutsehariduskeskus", KeskmineHinne = 4.5, Puudumised = 35, KasOnSotsTõend = true };
minuKool.LisaInimene(jüri);
palgasaajad.Add(jüri);

Õpilane olga = new Õpilane("Olga", "TTHK", 9);
olga.Sünniaasta = 2009;
minuKool.LisaInimene(olga);

Õpetaja anna = new Õpetaja { Nimi = "Anna", Sünniaasta = 1985, Aine = "Python", Tunnitasu = 20, Tunnidkuus = 80 };
minuKool.LisaInimene(anna);
palgasaajad.Add(anna);

Õpetaja peeter = new Õpetaja { Nimi = "Peeter", Sünniaasta = 1990, Aine = "C#", Tunnitasu = 25, Tunnidkuus = 60 };
minuKool.LisaInimene(peeter);
palgasaajad.Add(peeter);

//2. variant täitmine tsükli abil
Random rnd = new Random();
string[] nimed = { "Maria", "Kati", "Juhan", "Anna", "Siim" };
//Õppevorm[] vormid = { Õppevorm.Päevane, Õppevorm.Kaugõpe, Õppevorm.Ekstern, Õppevorm.AkadeemilinePuhkus };
Õppevorm[] vormid = (Õppevorm[])Enum.GetValues(typeof(Õppevorm));
for (int i = 0; i < nimed.Length; i++)
{
    Õpilane õpilane = new Õpilane
    {
        Nimi = nimed[rnd.Next(nimed.Length)],
        Sünniaasta = rnd.Next(1990, 2018),
        Klass = rnd.Next(1, 13),
        Kool = "TTHK",
        KeskmineHinne = rnd.NextDouble() * 5,
        Puudumised = rnd.Next(0, 350),
        KasOnSotsTõend = rnd.Next(0, 2) == 1,
        Staatus = vormid[rnd.Next(vormid.Length)]
    };
    palgasaajad.Add(õpilane);
    õpilane.Kirjelda();
    minuKool.LisaInimene(õpilane);
}
// Nüüd saame ühe tsükliga kõigile palgad/toetused välja arvutada
Console.WriteLine("--- Väljamaksed ---");
foreach (ITööline isik in palgasaajad)
{
    // Polümorfism teeb siin maagiat: 
    // Õpilase puhul käivitub toetuse loogika, õpetaja puhul palga loogika!
    string tüüp = isik.VäljamakseTüüp.ToString();
    Console.WriteLine($" {tüüp}. Summa: {isik.ArvutaPalk()} eurot. {((Isik)isik).Nimi}le");
}

minuKool.KuvaKõik();
minuKool.OtsiNimeJärgi("Mati");

// HARJUTUS 9
Console.WriteLine("\n=== HARJUTUS 9: FILTREERIMINE ===");
minuKool.KuvaAinultÕpilased();
minuKool.KuvaAinultÕpilased_LINQ();

// HARJUTUS 10
Console.WriteLine("\n=== HARJUTUS 10: KURSUS JA ÕPETAJA ===");
// Loome uue õpetaja
Õpetaja matemaatikaÕpetaja = new Õpetaja();
matemaatikaÕpetaja.Nimi = "Mare";
matemaatikaÕpetaja.Sünniaasta = 1975;
matemaatikaÕpetaja.Aine = "Matemaatika";

// Loome kursuse ja seome õpetajaga
Kursus matemaatikaKursus = new Kursus();
matemaatikaKursus.Nimi = "Kõrgem matemaatika";
matemaatikaKursus.VastutavÕpetaja = matemaatikaÕpetaja;

// Kuvame info
matemaatikaKursus.KuvaInfo();

// Teine variant konstruktoriga
Kursus programmeerimine = new Kursus("Programmeerimise alused", anna);
programmeerimine.KuvaInfo();

// Salvestame faili
minuKool.SalvestaFaili("kooli_andmed.txt");

Console.WriteLine($"Kokku on: {Isik.InimesteKoguarv} isikut");

Console.ReadLine();