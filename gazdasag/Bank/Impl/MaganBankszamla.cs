using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Varos.gazdasag.Bank.Impl
{
    internal class MaganBankszamla : Bankszamla
    {
        private long egyenleg;

        public override string Egyenleg { get => egyenleg.ToString("C0", CultureInfo.CreateSpecificCulture("hu-HU")); }

        public override void Feltoltes(int mennyiseg)
        {
            if (mennyiseg > 0)
            {
                egyenleg += mennyiseg;
            }
        }

        public override void Levonas(int mennyiseg)
        {
            if (mennyiseg > 0)
            {
                egyenleg = Math.Max(0, egyenleg - mennyiseg);
            }
        }

        public override bool Megfizetheto(int mennyiseg)
        {
            return egyenleg >= mennyiseg;
        }
    }
}
