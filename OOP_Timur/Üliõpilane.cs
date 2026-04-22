using OOP_Timur;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Timur
{
    public class Üliõpilane : Õpilane
    {
        // Omadus Eriala
        public string Eriala { get; set; }

        // Konstruktor
        /*public Üliõpilane(string nimi, string klass, string õppevorm, string eriala)
            : base(nimi, klass, õppevorm)
        {
            Eriala = eriala;
        }*/

        // Meetodi Kirjelda() ülekirjutamine
        public override void Kirjelda()
        {
            // Kutsume ülemklassi meetodi, et kuvada nimi, klass ja õppevorm
            base.Kirjelda();
            // Lisame juurde eriala info
            Console.WriteLine($"Eriala: {Eriala}");
        }
    }
}