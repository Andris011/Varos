using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.gazdasag.Bank;
using Varos.gazdasag.Bank.Impl;
using Varos.gazdasag.Nemzet;
using Varos.gazdasag.Nemzet.NAV;

namespace Varos.gazdasag.Munkahely
{
    internal class Ceg
    {
        private List<Munkavallalo> munkavallalok;
        private Bankszamla cegBankszamla;

        public Ceg()
        {
            cegBankszamla = new MaganBankszamla();
        }

        private int ProfitSzamolas()
        {
            Random random = new Random();
            int profitMunkavallora = random.Next(400_000, 450_000);

            // minden munkavállalóra számítunk profitot
            double profit = munkavallalok.Count * profitMunkavallora;

            // -10% <-> +10% bukás/nyereség véletlenszerűen
            profit *= random.NextDouble() * 0.2 - 0.1;

            return (int) profit;
        }

        public void Havonta(Allam allam)
        {
            cegBankszamla.Feltoltes(ProfitSzamolas());

            foreach (Munkavallalo munkavallalo in this.munkavallalok)
            {
                int brutto = munkavallalo.Fizetes;
                int netto = NAV.FizetesAdoSzamolas(munkavallalo.Szemelyiseg, munkavallalo.Fizetes);

                int allamnak = brutto - netto;

                cegBankszamla.Utal(munkavallalo.Szemelyiseg.Szamla, netto);
                cegBankszamla.Utal(allam.AllamiBankszamla, allamnak);
            }
        }
    }
}
