using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Timur
{
    public enum TööTüüp
    {
        Palk,
        Toetus
    }
    public interface ITööline
    {
        public TööTüüp VäljamakseTüüp { get; set; } // Töö tüübi omadus
        double ArvutaPalk(); // Meetod, mis arvutab tööline palga
    }
}