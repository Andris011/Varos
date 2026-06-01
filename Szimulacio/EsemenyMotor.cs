using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.esemenyek.bankrablas;
using Varos.esemenyek.foldrenges;
using Varos.esemenyek.karacsony;
using Varos.esemenyek.lotto;
using Varos.gazdasag.Nemzet;
using Varos.Lakossag;

namespace Varos.Szimulacio
{
    internal class EsemenyMotor
    {
        private Random rng;
        private Lotto lotto;
        private int hetekSzama;

        public EsemenyMotor()
        {
            rng = new Random();
            lotto = new Lotto(new Dictionary<Ember, int>(), 0);
            hetekSzama = 1;
        }

        private void LottoFuttatas(Allam allam)
        {
            for (int i = 0; i < allam.Allampolgarok.Count / 3; i++)
            {
                Ember ember = allam.Allampolgarok[rng.Next(0, allam.Allampolgarok.Count)];
                lotto.SzelvenytVesz(ember, 1);
            }

            

            LottoEredmeny eredmeny = lotto.Roll();

            string message;
            
            if (eredmeny.JackpotNyertes != null)
            {
                message = $"\x1B[4;32m*** Jackpot nyertes: {eredmeny.JackpotNyertes.Nev} - {eredmeny.JackpotOsszeg} Ft! ***\x1B[0m";
            }
            else
            {
                string nyertesekString="";
                foreach(Ember e in eredmeny.Nyertesek)
                {
                    nyertesekString += e.Nev;
                    if (eredmeny.Nyertesek.Last() != e)
                    {
                        nyertesekString += ", ";
                    }
                }
                message = $"*** Heti nyertesek: {nyertesekString}! ***";
            }

            SzimulacioMotor.KiemeltSzoveg = message;
            
        }

        public void Hetente(Allam allam, List<(Epulet.Epulet, (int, int))> epuletek, Epulet.Epulet[,] map)
        {
            hetekSzama++;
            LottoFuttatas(allam);

            int val = rng.Next(1, 10);

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
                    (Epulet.Epulet epulet, (int epuletX, int epuletY)) = epuletek[epuletIndex];

                    if (!sebzettek.Contains(epulet))
                    {
                        sebzettek.Add(epulet);
                        epulet.Foldrenges();

                        if (epulet.Karbantartottsag <= 0)
                        {
                            epuletek.Remove(epuletek[epuletIndex]);
                            map[epuletY, epuletX] = null;
                        }
                    }
                }

                for (int i = 0; i < Math.Min(renges.Aldozatok, 10); i++) {
                    allam.Allampolgarok.RemoveAt(rng.Next(0, allam.Allampolgarok.Count));
                }
            } else if (val == 2)
            {
                Bankrablas bankrablas = new Bankrablas();
                bankrablas.BankrablasInditasa(allam.Allampolgarok);
            }

            if (hetekSzama%52== 0)
            {
                Karacsony karacsony = new Karacsony();
                karacsony.KaracsonyInditasa(allam.Allampolgarok);
            }
        }
    }
}
