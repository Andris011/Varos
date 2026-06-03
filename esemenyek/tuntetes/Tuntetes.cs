using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Lakossag;

namespace Varos.esemenyek.tuntetes
{
    internal class Tuntetes
    {
        Random rnd = new Random();
        int resztvevokSzama;
        List<Ember> resztvevok;

        public Tuntetes()
        {
            resztvevokSzama = rnd.Next(5, 51);
            resztvevok = new List<Ember>();
        }

        public int ResztvevokSzama { get => resztvevokSzama; set => resztvevokSzama = value; }
        public List<Ember> Resztvevok { get => resztvevok; set => resztvevok = value; }

        public void TuntetesInditasa(List<Ember> lakossag)
        {
            if (lakossag.Count == 0)
            {
                Console.WriteLine("Nincs elég ember a városban a tüntetéshez.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nTüntetés tört ki a városban!");
            Console.ResetColor();
            Console.WriteLine("\tAz emberek tüntetnek egy jobb életért: 'Legyen mindenki rohadt gazdag'");
            Console.WriteLine($"\tRésztvevők száma: {ResztvevokSzama}");

            List<Ember> masolat = new List<Ember>(lakossag);
            int kivalasztando = Math.Min(ResztvevokSzama, masolat.Count);

            for (int i = 0; i < kivalasztando; i++)
            {
                int index = rnd.Next(masolat.Count);
                Ember resztvevo = masolat[index];
                Resztvevok.Add(resztvevo);
                masolat.RemoveAt(index);
            }

            Console.WriteLine("\tA tüntetők:");
            foreach (Ember resztvevo in Resztvevok)
            {
                Console.WriteLine($"\t\t{resztvevo.Nev}");
            }

            Console.WriteLine("\tA tüntetés zajlik...");
        }
    }
}
