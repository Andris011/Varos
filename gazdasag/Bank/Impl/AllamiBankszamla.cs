using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varos.gazdasag.Bank.Impl
{
    internal class AllamiBankszamla : Bankszamla
    {
        public override string Egyenleg => "végtelen";

        public override void Feltoltes(int mennyiseg) { }

        public override void Levonas(int mennyiseg) { }

        public override bool Megfizetheto(int mennyiseg)
        {
            return true;
        }
    }
}
