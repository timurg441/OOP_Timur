using OOP_Timur;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_Timur
{
    public class Koolihaldus
    {
        // Kapseldatud list
        private List<Isik> inimesed = new List<Isik>();

        public void LisaInimene(Isik isik)
        {
            inimesed.Add(isik);
        }

        // massiivi lisamine
        public void LisaInimene(Isik[] uuedInimesed)
        {
            inimesed.AddRange(uuedInimesed);
        }

        // listi lisamine
        public void LisaInimene(List<Isik> uuedInimesed)
        {
            inimesed.AddRange(uuedInimesed);
        }

        public void KuvaKõik()
        {
            Console.WriteLine("\n--- KOOLI NIMEKIRI ---");
            foreach (var isik in inimesed)
            {
                // Polümorfism teeb siin imesid! 
                // C# teab ise, kas käivitada Õpetaja või Õpilase Kirjelda() meetod.
                isik.Kirjelda();
            }
        }

        public void OtsiNimeJärgi(string otsitavNimi)
        {
            Console.WriteLine($"\n--- OTSINGU TULEMUSED (päring: '{otsitavNimi}') ---");
            bool leitud = false;

            foreach (var isik in inimesed)
            {
                // Kasutame meetodit Contains(), et leida nimesid, mis sisaldavad otsitavat osa.
                // StringComparison.OrdinalIgnoreCase muudab otsingu tõstutundetuks (suured/väikesed tähed ei loe).
                if (isik.Nimi.Contains(otsitavNimi, StringComparison.OrdinalIgnoreCase))
                {
                    isik.Kirjelda();
                    Console.WriteLine("-------------------");
                    leitud = true;
                }
            }

            if (!leitud)
            {
                Console.WriteLine("Ühtegi isikut sellise nimega ei leitud.");
            }
        }

        // 1. Otsing nime järgi (võtab vastu stringi)
        public void Otsi(string otsitavNimi)
        {
            Console.WriteLine($"\nOtsime nime: {otsitavNimi}");
            foreach (var isik in inimesed)
            {
                if (isik.Nimi.Contains(otsitavNimi)) isik.Kirjelda();
            }
        }

        // 2. Otsing nimekirjas numbri/sünniaasta järgi (sama nimi, aga võtab vastu int)
        public void Otsi(int otsitavAasta)
        {
            Console.WriteLine($"\nOtsime kedagi, kes on sündinud aastal: {otsitavAasta}");
            // Siin eeldame, et lisasime Isik klassile ka Sünniaasta tagasi
            Console.WriteLine($"\n--- OTSINGU TULEMUSED (Sünniaasta : {otsitavAasta}) ---");
            bool leitud = false;

            foreach (var isik in inimesed)
            {
                //Võrdleme isiku Sünniaasta property't otsitava numbriga
                if (isik.Sünniaasta == otsitavAasta)
                {
                    isik.Kirjelda(); // Polümorfism: kutsub välja õige klassi kirjelduse
                    Console.WriteLine("------------------");
                    leitud = true;
                }
            }
            if (!leitud)
            {
                Console.WriteLine($"Aastal {otsitavAasta} sündinud isikut ei leitud.");
            }
        }

        // faili salvestamine
        public void SalvestaFaili(string failinimi)
        {
            StreamWriter writer = new StreamWriter(failinimi, false, Encoding.UTF8));

            writer.WriteLine("--- KOOLI NIMEKIRI (Salvestatud: {DateTime.Now}) ---");

            foreach (var isik in inimesed)
            {
                if (isik is Õpetaja)
                {
                    Õpetaja op = (Õpetaja)isik;
                    writer.WriteLine($"Õpetaja: {op.Nimi}, õpetab: {op.Aine}");
                }
                else if (isik is Õpilane)
                {
                    Õpilane opil = (Õpilane)isik;
                    writer.WriteLine($"Õpilane: {opil.Nimi}, klass: {opil.Klass}");
                }
            }

            writer.Close();
            Console.WriteLine($"Salvestatud faili: {failinimi}");
        }

        public void SalvestaFaili()
        {
            SalvestaFaili("kooli_andmed.txt");
        }
    }
}