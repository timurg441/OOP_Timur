using OOP_Timur;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Timur
{
    // Õpetaja pärib klassist Isik (koolon tähistab pärimist)
    public class Õpetaja : Isik, ITööline
    {
        public string Aine { get; set; }
        public double Tunnitasu { get; set; }
        public int Tunnidkuus { get; set; }
        public TööTüüp VäljamakseTüüp { get; set; } = TööTüüp.Palk; // Õpetaja puhul on väljamakse tüüp alati palk

        // Konstruktor, mis küsib nime, õpetatavat ainet ja tunnitasu
        public Õpetaja(string nimi, string aine, double tunnitasu) : base(nimi)
        {
            Aine = aine;
            Tunnitasu = tunnitasu;
            Nimi = nimi;
        }

        // Vaikekonstruktor (olemasoluks, kui keegi kasutab object initializerit)
        public Õpetaja() : base()
        {
        }

        public void Õpeta()
        {
            Console.WriteLine($"{Nimi} õpetab ainet: {Aine}.");
        }

        // override kirjutab abstraktse meetodi üle
        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen õpetaja {Nimi} ja ma õpetan: {Aine}.");
        }

        // ITööline liidese meetodi realiseerimine
        public virtual double ArvutaPalk()
        {
            return Tunnitasu * Tunnidkuus; // Palk arvutatakse tunnitasu ja töötatud tundide korrutisena
        }

        // IHindaja liidese rakendamine
        public void Hinda(string hinne)
        {
            Console.WriteLine($"Õpetaja {Nimi} pani hindeks: {hinne}");
        }
    }
}