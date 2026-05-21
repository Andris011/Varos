using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Lakossag;

namespace Varos.gazdasag.Munkahely
{
    internal class Munkavallalo
    {
        private int fizetes;
        private Ember szemelyiseg;

        public Munkavallalo(int fizetes, Ember szemelyiseg)
        {
            this.fizetes = fizetes;
            this.szemelyiseg = szemelyiseg;
        }

        public int Fizetes { get => fizetes; set => fizetes = value; }
        public Ember Szemelyiseg { get => szemelyiseg; }
    }
}
