using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.gazdasag.Bank;
using Varos.gazdasag.Bank.Impl;
using Varos.gazdasag.Munkahely;
using Varos.Lakossag;

namespace Varos.gazdasag.Nemzet
{
    internal class Allam
    {
        private List<Ceg> cegek;
        private List<Ember> allampolgarok;

        private Bankszamla allamiBankszamla;

        public Allam()
        {
            cegek = new List<Ceg>();
            allampolgarok = new List<Ember>();

            allamiBankszamla = new MaganBankszamla();

            Tamogatas kezdoTamogatas = new Tamogatas("Európai Unió állam kezdőtámogatás", 167_000_000, "Csendes kis város");
            kezdoTamogatas.Felvesz(allamiBankszamla);
        }

        public void AllampolgarFelvesz(Ember ember)
        {
            allampolgarok.Add(ember);
        }

        public void CegFelvesz(Ceg ceg)
        {
            cegek.Add(ceg);
        }

        public void Havonta()
        {
            foreach (Ceg ceg in cegek)
            {
                ceg.Havonta(this);
            }

            allamiBankszamla.Levonas(allampolgarok.Count*10000);

            foreach (Ember ember in allampolgarok)
            {
                int nyugdij = 67000;
                if (ember.EletKor >= 67)
                {
                    allamiBankszamla.Utal(ember.Bankszamla, nyugdij);
                }
            }
        }

        public List<Ember> Allampolgarok { get => allampolgarok; }
        public Bankszamla AllamiBankszamla { get => allamiBankszamla; }
    }
}
