using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Text;

namespace OOP_Timur
    {
        public class Isik
        {
            // Privaatne väli - otse ligi ei saa
            private int sünniaasta;

            // Avalik omadus (Property) automaatse get/set logikaga
            public string Nimi { get; set; }

            // Kontrollitud omadus
            public int Sünniaasta
            {
                get { return sünniaasta; }
                set
                {
                    if (value > 1900 && value <= DateTime.Now.Year)
                        sünniaasta = value;
                    else
                        Console.WriteLine("Vigane sünniaasta!");
                }
            }

            // Arvutatud omadus (ainult lugemiseks / getter)
            public int Vanus => DateTime.Now.Year - sünniaasta;

            // Tegevus ehk meetod
            public void Tervita()
            {
                if (string.IsNullOrEmpty(Nimi) || sünniaasta == 0)
                {
                    Console.WriteLine("Tere! Ma ei tea veel oma nime ega sünniaastat.");
                }
                else
                {
                    Console.WriteLine($"Tere! Mina olen {Nimi}, ma olen {Vanus} aastat vana. Olen sündinud aastal {sünniaasta}.");
                }
            }
        }
    }

public abstract class Isik
{
    public string Nimi { get; set; }

    // Abstraktne meetod – sisu puudub, alamklassid PEAVAD selle ise looma
    public abstract void Kirjelda();
}