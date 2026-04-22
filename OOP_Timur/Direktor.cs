using OOP_Timur;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Timur
{
    public class Direktor : Õpetaja
    {
        // Omadus Lisatasu
        public double Lisatasu { get; set; }

        // Konstruktor (vajalik, kui Õpetaja klassil on parameetritega konstruktor)
        /*public Direktor(string nimi, double baaspalk, double lisatasu) : base(nimi, baaspalk)
        {
            Lisatasu = lisatasu;
        }*/

        // Meetodi ArvutaPalk ülekirjutamine
        public override double ArvutaPalk()
        {
            // Kasutame ülemklassi (base) meetodit ja liidame sellele lisatasu
            return base.ArvutaPalk() + Lisatasu;
        }
    }
}