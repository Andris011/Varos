using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto
{
    internal class TesztEmber
    {
        string nev;
        int penz;

        public TesztEmber(string nev, int penz)
        {
            this.nev = nev;
            this.penz = penz;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Penz { get => penz; set => penz = value; }

        public override string ToString() 
        {
            return $"{nev}, {penz}";
        }
    }
}
