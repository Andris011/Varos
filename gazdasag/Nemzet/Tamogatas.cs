using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.gazdasag.Bank;

namespace Varos.gazdasag.Nemzet
{
    internal class Tamogatas
    {
        private string szarmazas;
        private int osszeg;
        private string kinek;
        private bool elerhetoE;

        

        public Tamogatas(string szarmazas, int osszeg, string kinek)
        {
            this.szarmazas = szarmazas;
            this.osszeg = osszeg;
            this.kinek = kinek;
            this.elerhetoE = true;
        }

        public void Felvesz(Bankszamla szamla)
        {
            if (elerhetoE)
            {
                szamla.Feltoltes(osszeg);
                elerhetoE = false;
            }
            
        }

        public string Szarmazas { get => szarmazas; set => szarmazas = value; }
        public int Osszeg { get => osszeg; set => osszeg = value; }
        public string Kinek { get => kinek; set => kinek = value; }
    }
}
