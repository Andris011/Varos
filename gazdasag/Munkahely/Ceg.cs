using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.gazdasag.Bank;
using Varos.gazdasag.Bank.Impl;
using Varos.gazdasag.Nemzet;
using Varos.gazdasag.Nemzet.NAV;
using Varos.Lakossag;

namespace Varos.gazdasag.Munkahely
{
    internal class Ceg
    {
        private List<Munkavallalo> munkavallalok;
        private Bankszamla cegBankszamla;

        public Ceg()
        {
            munkavallalok = new List<Munkavallalo>();
            cegBankszamla = new MaganBankszamla();
        }

        public void Alkalmaz(Ember ember, int fizetes)
        {
            munkavallalok.Add(new Munkavallalo(fizetes, ember));
        }

        private int ProfitSzamolas()
        {
            Random random = new Random();
            int profitMunkavallora = random.Next(400_000, 450_000);

            // minden munkavállalóra számítunk profitot
            double profit = munkavallalok.Count * profitMunkavallora;

            // -10% <-> +10% bukás/nyereség véletlenszerűen
            profit *= 1 + (random.NextDouble() * 0.2 - 0.1);

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

                cegBankszamla.Utal(munkavallalo.Szemelyiseg.Bankszamla, netto);
                cegBankszamla.Utal(allam.AllamiBankszamla, allamnak);
            }
        }
    }
}
