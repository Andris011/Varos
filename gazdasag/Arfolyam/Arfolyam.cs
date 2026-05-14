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
            this.inflacioMutato = inflacioMutato * ((random.NextDouble()-0.5)/0.5)*0.23;
        }

        public double InflacioMutato { get => inflacioMutato; set => inflacioMutato = value; }


    }
}
