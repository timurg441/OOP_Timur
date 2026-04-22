

namespace OOP_Timur
{
    public abstract class Isik
    {
        // Privaatne väli - otse ligi ei saa
        private int sünniaasta;
        public static int InimesteKoguarv = 0;
        // Avalik omadus (Property) automaatse get/set logikaga
        public string Nimi { get; set; }
        public Isik()
        {
            InimesteKoguarv++;
        }

        public Isik(string nimi) : this()
        {
            Nimi = nimi;
        }

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
        public int Vanus => sünniaasta == 0 ? 0 : DateTime.Now.Year - sünniaasta;

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
        // Abstraktne meetod – sisu puudub, alamklassid PEAVAD selle ise looma
        public abstract string Kirjelda();

    }
}