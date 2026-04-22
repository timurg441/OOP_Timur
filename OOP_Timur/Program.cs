// See https://aka.ms/new-console-template for more information
using OOP_Timur;

// Loome Isik klassi objekti ja kasutame selle omadusi ja meetodit
//Isik inimene1 = new Isik();

//inimene1.Nimi = "Mati";
//inimene1.Sünniaasta = 200;
//inimene1.Tervita(); // Väljund: Tere! Mina olen Mati...

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
mati.KeskmineHinne = 4.0;
minuKool.LisaInimene(mati);
Õpilane kadi = new Õpilane { Nimi = "Kadi", Klass = 11, Kool = "Kutsehariduskeskus", KeskmineHinne = 3.5, Puudumised = 5, KasOnSotsTõend = false };
Õpilane jüri = new Õpilane { Nimi = "Jüri", Klass = 12, Kool = "Kutsehariduskeskus", KeskmineHinne = 4.5, Puudumised = 35, KasOnSotsTõend = true };
Õpetaja anna = new Õpetaja { Nimi = "Anna", Aine = "Python", Tunnitasu = 20, Tunnidkuus = 80 };
Õpetaja peeter = new Õpetaja { Nimi = "Peeter", Aine = "C#", Tunnitasu = 25, Tunnidkuus = 60 };
// Lisame kõik palgasaajad ühte listi
palgasaajad.AddRange(new ITööline[] { mati, kadi, jüri, anna, peeter });
minuKool.LisaInimene(kadi);
minuKool.LisaInimene(jüri);
minuKool.LisaInimene(anna);
minuKool.LisaInimene(peeter);

// MASSIIVI JA LISTIGA LISAMINE
Isik[] massiivIsikuid = new Isik[]
{
    new Õpilane { Nimi = "Mari", Klass = 9 },
    new Õpilane { Nimi = "Jaan", Klass = 10 }
};
minuKool.LisaInimene(massiivIsikuid);

List<Isik> listIsikuid = new List<Isik>
{
    new Õpetaja { Nimi = "Liisa", Aine = "Füüsika" },
    new Õpilane { Nimi = "Peeter", Klass = 11 }
};
minuKool.LisaInimene(listIsikuid);

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
        Klass = rnd.Next(1, 13),
        Kool = "TTHK",
        KeskmineHinne = rnd.NextDouble() * 5, // Keskmine hinne vahemikus 0-5
        Puudumised = rnd.Next(0, 350), // Puudumised vahemikus 0-350
        KasOnSotsTõend = rnd.Next(0, 2) == 1,
        Staatus = vormid[rnd.Next(vormid.Length)]// Valime juhusliku õppevormi enumi väärtuste hulgast
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

// testimine
Console.WriteLine("\n--- FAILI SALVESTAMINE ---");
minuKool.SalvestaFaili();
minuKool.SalvestaFaili("minu_andmed.txt");

Console.WriteLine($"Kokku on: {Isik.InimesteKoguarv} isikut");

Console.ReadLine();