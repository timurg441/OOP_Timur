using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Timur
{
    // Õpetaja pärib klassist Isik (koolon tähistab pärimist)
    public class Õpetaja : Isik
    {
        public string Aine { get; set; }

        public void Õpeta()
        {
            Console.WriteLine($"{Nimi} õpetab ainet: {Aine}.");
        }
    }
}

public class Õpetaja : Isik
{
    public string Aine { get; set; }

    // override kirjutab abstraktse meetodi üle
    public override void Kirjelda()
    {
        Console.WriteLine($"Mina olen õpetaja {Nimi} ja ma õpetan: {Aine}.");
    }
}