using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.gazdasag.Bank;
using Varos.gazdasag.Bank.Impl;
using Varos.gazdasag.Munkahely;

namespace Varos.gazdasag.Nemzet
{
    internal class Allam
    {
        private List<Ceg> cegek;
        private List<GazdasagAllampolgar> allampolgarok;

        private Bankszamla allamiBankszamla;

        public Allam()
        {
            cegek = new List<Ceg>();
            allampolgarok = new List<GazdasagAllampolgar>();

            allamiBankszamla = new AllamiBankszamla();
        }

        public Bankszamla AllamiBankszamla { get => allamiBankszamla; }
    }
}
