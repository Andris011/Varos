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
        int erosseg;
        int hatosugar;
        bool aktiv;
        int aldozatok;
        int kar;

        Random rnd = new Random();

        public Foldrenges()
        {
            Erosseg = rnd.Next(1, 11);
            Hatosugar = Erosseg * 5;
            Aktiv = false;
            Aldozatok = Erosseg * rnd.Next(2, 40);
            Kar = Erosseg * rnd.Next(20000, 100000);
        }

        public int Erosseg { get => erosseg; set => erosseg = value; }
        public int Hatosugar { get => hatosugar; set => hatosugar = value; }
        public bool Aktiv { get => aktiv; set => aktiv = value; }
        public int Aldozatok { get => aldozatok; set => aldozatok = value; }
        public int Kar { get => kar; set => kar = value; }

        public void FoldrengesInditasa()
        {
            Aktiv = true;
            Console.WriteLine("---------------A földrengés elindult---------------");
            Console.WriteLine($"-----------------Erőssége: {Erosseg}--------------");
            Console.WriteLine($"-----------------Hatósugara: {Hatosugar}km--------");
            FoldrengesVege();
            Console.WriteLine($"-----------------Áldozatok száma: {Aldozatok}km--------");
            Console.WriteLine($"-----------------Kár: {Kar}ft--------");
        }
        public void FoldrengesVege()
        {
            Aktiv = false;
            Console.WriteLine("A földrengés véget ért");
        }
    }
}