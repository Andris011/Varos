using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.esemenyek.foldrenges;
using Varos.esemenyek.lotto;
using Varos.gazdasag.Nemzet;
using Varos.Lakossag;

namespace Varos.Szimulacio
{
    internal class EsemenyMotor
    {
        private Random rng;

        public EsemenyMotor()
        {
            rng = new Random();
        }

        private void LottoFuttatas(Allam allam)
        {
            Dictionary<Ember, int> tar = new Dictionary<Ember, int>();
            Lotto lotto = new Lotto(tar, 0);

            for (int i = 0; i < allam.Allampolgarok.Count / 3; i++)
            {
                Ember ember = allam.Allampolgarok[rng.Next(0, allam.Allampolgarok.Count)];
                lotto.SzelvenytVesz(ember, 1);
            }

            lotto.Roll();
        }

        public void Hetente(Allam allam, List<Epulet.Epulet> epuletek)
        {
            LottoFuttatas(allam);

            int val = rng.Next(1, 101);

            if (val == 1)
            {
                Foldrenges renges = new Foldrenges();
                int sebzettEpuletekSzama = Math.Min(renges.Erosseg * 2, epuletek.Count);
                List<Epulet.Epulet> sebzettek = new List<Epulet.Epulet>();

                renges.FoldrengesInditasa();

                allam.AllamiBankszamla.Levonas(renges.Kar);

                while (sebzettek.Count < sebzettEpuletekSzama)
                {
                    int epuletIndex = rng.Next(0, epuletek.Count);
                    Epulet.Epulet epulet = epuletek[epuletIndex];

                    if (sebzettek.Contains(epulet))
                    {
                        sebzettek.Add(epulet);
                        epulet.Foldrenges();
                    }
                }

                for (int i = 0; i < renges.Aldozatok; i++) {
                    allam.Allampolgarok.RemoveAt(rng.Next(0, allam.Allampolgarok.Count));
                }
            } else if (val == 2)
            {

            }
        }
    }
}
