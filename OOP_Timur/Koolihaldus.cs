using OOP_Timur;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}