using OOP_Timur;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Timur
{
    public enum Õppevorm
    {
        Päevane,
        Kaugõpe,
        Ekstern,
        AkadeemilinePuhkus
    }
    // Õpilane pärib klassist Isik
    public class Õpilane : Isik, ITööline
    {
        public string Kool { get; set; }
        public int Klass { get; set; }
        public double KeskmineHinne { get; set; }//põhitoetus 60eur
        public int Puudumised { get; set; } = 0;//põhitoetus
        public bool KasOnSotsTõend { get; set; } = false; //eritoetus 120eur
        public TööTüüp VäljamakseTüüp { get; set; } = TööTüüp.Toetus; // Õpilase puhul on väljamakse tüüp alati toetus
        public Õppevorm Staatus { get; set; } = Õppevorm.Päevane; // Kasutame enumi andmetüübina
        public void Õpi()
        {
            Console.WriteLine($"{Nimi} õpib {Kool} {Klass}. klassis. Vorm: {Staatus}");
        }
        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen õpilane {Nimi} ja käin {Klass}. klassis. Vorm: {Staatus}");
        }

        public double ArvutaPalk()
        {
            double põhitoetus = 0;
            double eritoetus = 0;

            if (KeskmineHinne >= 3.8 && Puudumised <= 30)
            {
                põhitoetus += 60;
            }
            if (KasOnSotsTõend)
            {
                eritoetus += 120;
            }

            return põhitoetus + eritoetus;
        }
    }
}