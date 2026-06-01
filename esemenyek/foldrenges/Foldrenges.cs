using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Varos.esemenyek.foldrenges
{
    internal class Foldrenges
    {
        Random rnd = new Random();

        int erosseg;
        int hatosugar;
        int aldozatok;
        int kar;
        int idotartam;

        bool aktiv;

        public Foldrenges()
        {
            Erosseg = rnd.Next(1, 11);
            Hatosugar = Erosseg * 5;
            Aldozatok = Erosseg * rnd.Next(2, 40);
            Kar = Erosseg * rnd.Next(20000, 100000);
            FoldrengesIdotartam();

            Aktiv = false;
        }

        public int Erosseg { get => erosseg; set => erosseg = value; }
        public int Hatosugar { get => hatosugar; set => hatosugar = value; }
        public int Aldozatok { get => aldozatok; set => aldozatok = value; }
        public int Kar { get => kar; set => kar = value; }
        public int Idotartam { get => idotartam; set => idotartam = value; }
        public bool Aktiv { get => aktiv; set => aktiv = value; }

        public void FoldrengesInditasa()
        {
            Aktiv = true;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nKitört egy földrengés!");

            Console.ResetColor();
            Console.WriteLine($"\tErőssége: {Erosseg}");
            Console.WriteLine($"\tHatósugara: {Hatosugar} km");
            Console.WriteLine($"\tIdőtartam: {Idotartam} másodperc");
            Console.WriteLine($"\tÁldozatok száma: {Aldozatok}");
            Console.WriteLine($"\tKár: {Kar} Ft");

            VeszelySzint();

            FoldrengesVege();
        }
        public void FoldrengesVege()
        {
            //Console.WriteLine("A földrengés véget ért");
            Aktiv = false;
        }
        public void VeszelySzint()
        {
            if (aldozatok <= 10)
            {
                Console.WriteLine("\tBelépő szintű földrengés.");
            }
            else if (aldozatok <= 100)
            {
                Console.WriteLine("\tÁtlagos földrengés.");
            }
            else if (aldozatok <= 1000)
            {
                Console.WriteLine("\tErős földrengés.");
            }
            else
            {
                Console.WriteLine("\tTermészeti katasztrófa.");
            }
        }
        public void FoldrengesIdotartam()
        {
            if (Erosseg <= 3)
            {
                Idotartam = rnd.Next(5, 15);
            }
            else if (Erosseg <= 6)
            {
                Idotartam = rnd.Next(15, 40);
            }
            else if (Erosseg <= 8)
            {
                Idotartam = rnd.Next(40, 80);
            }
            else
            {
                Idotartam = rnd.Next(80, 180);
            }
        }
    }
}