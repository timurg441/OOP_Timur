using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Timur
{
    // HARJUTUS 10
    public class Kursus
    {
        // Omadused
        public string Nimi { get; set; }
        public Õpetaja VastutavÕpetaja { get; set; }

        // Konstruktor (valikuline)
        public Kursus(string nimi, Õpetaja õpetaja)
        {
            Nimi = nimi;
            VastutavÕpetaja = õpetaja;
        }

        // Vaikekonstruktor
        public Kursus() { }

        // Meetod info kuvamiseks
        public void KuvaInfo()
        {
            Console.WriteLine($"Kursus: {Nimi}");
            if (VastutavÕpetaja != null)
            {
                Console.WriteLine($"Vastutav õpetaja: {VastutavÕpetaja.Nimi}");
            }
            else
            {
                Console.WriteLine("Õpetaja puudub!");
            }
        }
    }
}