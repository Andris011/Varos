using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varos.gazdasag.Munkahely
{
    internal class Munkavallalo
    {
        private int fizetes;
        private GazdasagAllampolgar szemelyiseg;

        public Munkavallalo(int fizetes, GazdasagAllampolgar szemelyiseg)
        {
            this.fizetes = fizetes;
            this.szemelyiseg = szemelyiseg;
        }

        public int Fizetes { get => fizetes; set => fizetes = value; }
        public GazdasagAllampolgar Szemelyiseg { get => szemelyiseg; }
    }
}
