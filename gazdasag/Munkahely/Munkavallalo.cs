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
        private IGazdasagAllampolgar szemelyiseg;

        public Munkavallalo(int fizetes, IGazdasagAllampolgar szemelyiseg)
        {
            this.fizetes = fizetes;
            this.szemelyiseg = szemelyiseg;
        }

        public int Fizetes { get => fizetes; set => fizetes = value; }
        public IGazdasagAllampolgar Szemelyiseg { get => szemelyiseg; }
    }
}
