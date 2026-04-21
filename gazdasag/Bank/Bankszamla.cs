using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varos.gazdasag.Bank
{
    internal abstract class Bankszamla
    {
        private string szamlaszam;

        public Bankszamla()
        {
            Random random = new Random();

            this.szamlaszam = "";

            for (int i = 0; i < 16; i++)
            {
                this.szamlaszam += $"{random.Next(0, 10)}";

                if (i != 15 && (i + 1) % 4 == 0)
                {
                    this.szamlaszam += "-";
                }
            }
        }

        public string Szamlaszam { get => szamlaszam; }

        abstract public string Egyenleg { get; }

        abstract public void Levonas(int mennyiseg);
        abstract public void Feltoltes(int mennyiseg);
        abstract public bool Megfizetheto(int mennyiseg);

        public bool Utal(Bankszamla szamla, int mennyiseg)
        {
            if (Megfizetheto(mennyiseg))
            {
                Levonas(mennyiseg);
                szamla.Feltoltes(mennyiseg);

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Számla(szam: {Szamlaszam}, egyenleg: {Egyenleg})";
        }
    }
}
