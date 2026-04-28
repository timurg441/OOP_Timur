

namespace OOP_Timur
{
    public abstract class Isik
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
                // HARJUTUS 8
                if (value > 1900 && value <= DateTime.Now.Year)
                    sünniaasta = value;
                else
                    throw new ArgumentException("Vigane aasta! Sünniaasta peab olema vahemikus 1901 kuni " + DateTime.Now.Year);
            }
        }

        public int Vanus => sünniaasta == 0 ? 0 : DateTime.Now.Year - sünniaasta;

        public static int InimesteKoguarv = 0;

        public Isik()
        {
            InimesteKoguarv++;
        }

        // Tegevus ehk meetod
        public void Tervita()
        {
            if (string.IsNullOrEmpty(Nimi) || sünniaasta == 0)
            {
                Console.WriteLine("Tere! Ma ei tea veel oma nime ega sünniaastat.");
            }
            else
                Console.WriteLine($"Tere! Mina olen {Nimi} ja ma olen {Vanus} aastat vana. Olen sündinud {Sünniaasta} aastal.");
        }
        public abstract void Kirjelda();

    }
}