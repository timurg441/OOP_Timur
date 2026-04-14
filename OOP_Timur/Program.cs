using OOP_Timur;

//Looome Isik klassi objekti ja kasutame selle omadusi ja meetodit
// Isik inimene1 = new Isik();
//inimene1.Nimi = "Mati";
//inimene1.Sünniaasta = 200;
//inimene1.Tervita(); // Väljund: Tere! Mina olen Mati...
Õpetaja õpetaja1 = new Õpetaja();
õpetaja1.Nimi = "Eve";
õpetaja1.Sünniaasta = 1980;
õpetaja1.Aine = "Matemaatika";
õpetaja1.Tervita(); // Väljund: Tere! Mina olen Eve...
õpetaja1.Õpeta(); // Väljund: Eve õpetab ainet: Matemaatika.

Console.WriteLine("\n--- Õpilase andmed ---");
// 2. Loome Õpilase objekti
Õpilane õpilane1 = new Õpilane();
// Päritud isik klassist
õpilane1.Nimi = "Markus";
õpilane1.Sünniaasta = 2008;
// Spetsiifilised Õpilane klassile
õpilane1.Kool = "Kutsehariduskeskus";
õpilane1.Klass = 10;
//Päritud meetod
õpilane1.Tervita();
//Õpilase enda meetod
õpilane1.Õpi();
//Ootame kasutaja sisestus, et konsooliaken kohe ei sulguks
Console.ReadLine();

