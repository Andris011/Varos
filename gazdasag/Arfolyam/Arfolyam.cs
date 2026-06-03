using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varos.gazdasag.Arfolyam
{
    internal class Arfolyam
    {
        private double inflacioMutato;

        public Arfolyam(double inflacioMutato)
        {
            this.inflacioMutato = inflacioMutato;
        }
        private Random random = new Random(); 
        public void HetiInflacio()
        {
            this.inflacioMutato = 0.75 + random.NextDouble() * 0.5; // 0.75 - 1.25 szorzo
        }

        public double InflacioMutato { get => inflacioMutato; set => inflacioMutato = value; }


    }
}
