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

            allamiBankszamla = new AllamiBankszamla();
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
        }

        public Bankszamla AllamiBankszamla { get => allamiBankszamla; }
    }
}
