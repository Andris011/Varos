using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Lakossag;

namespace Varos.esemenyek.bankrablas
{
    internal class Bankrablas
    {
        Random rnd = new Random();
        int tettesekSzama;
        int osszZsakmany;
        List<Ember> tettesek;

        public Bankrablas()
        {
            tettesekSzama = rnd.Next(1, 7);
            osszZsakmany = rnd.Next(50000, 500001); // még nem lehet tudni mennyi van összesen a bankban, de egyenlőre jó lesz random.
            tettesek = new List<Ember>();           // majd később megcsinálom, hogy a bankból lévő pénzt vigyék el, ne csak a semmiből legyen 
        }

        public int TettesekSzama { get => tettesekSzama; set => tettesekSzama = value; }
        public int OsszZsakmany { get => osszZsakmany; set => osszZsakmany = value; }
        public List<Ember> Tettesek { get => tettesek; set => tettesek = value; }

        public void BankrablasInditasa(List<Ember> lakossag)
        {
            if (lakossag.Count == 0)
            {
                Console.WriteLine("Nincs elég ember a városban a bankrabláshoz.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nA bankot kirabolták!");
            Console.ResetColor();
            Console.WriteLine($"\tTettesek száma: {TettesekSzama}");
            Console.WriteLine($"\tZsákmány: {OsszZsakmany}ft");

            // Tettesek kiválasztása
            List<Ember> masolat = new List<Ember>(lakossag);
            int kivalasztando = Math.Min(TettesekSzama, masolat.Count);
            
            for (int i = 0; i < kivalasztando; i++)
            {
                int index = rnd.Next(masolat.Count);
                Ember tettes = masolat[index];
                Tettesek.Add(tettes);
                masolat.RemoveAt(index);
            }

            // Pénz szétosztása
            int egyennekJuto = OsszZsakmany / Tettesek.Count;
            int maradek = OsszZsakmany % Tettesek.Count;

            Console.WriteLine("\tA tettesek és zsákmányuk:");
            for (int i = 0; i < Tettesek.Count; i++)
            {
                Ember tettes = Tettesek[i];
                int zsakmany = egyennekJuto;
                if (i == 0) zsakmany += maradek; // Maradékot az első kapja
                
                tettes.Bankszamla.Feltoltes(zsakmany);
                Console.WriteLine($"\t\t{tettes.Nev}: +{zsakmany}ft");
            }

            Console.WriteLine("\tA bankrablás sikeres volt!");
        }
    }
}
