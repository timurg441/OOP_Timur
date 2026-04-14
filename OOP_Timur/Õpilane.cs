using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Timur
{
    // Õpilane pärib klassist Isik
    public class Õpilane : Isik
    {
        public string Kool { get; set; }
        public int Klass { get; set; }

        public void Õpi()
        {
            Console.WriteLine($"{Nimi} õpib {Kool} {Klass}. klassis.");
        }
    }
}

public class Õpilane : Isik
{
    public int Klass { get; set; }

    public override void Kirjelda()
    {
        Console.WriteLine($"Mina olen õpilane {Nimi} ja käin {Klass}. klassis.");
    }
}