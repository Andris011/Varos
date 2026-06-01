using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Epulet.Interfaces;
using Varos.gazdasag.Nemzet;

namespace Varos.Epulet.Segelyszervek
{
    internal class Korhaz : Epulet, IMunkahely
    {
        private string nev;
        private int alkalmazottakSzama;
        private int befogadoKepesseg;
        private int betegekSzama;
        private int felszereltseg; //1-10ig, a halalozasi rata ettol fugg

        public Korhaz(int epuletMerete, int karbantartottsag, int rezsi, string nev, int alkalmazottakSzama, int befogadoKepesseg, int betegekSzama, int felszereltseg) : base(epuletMerete, karbantartottsag, rezsi)
        {
            this.nev = nev;
            this.alkalmazottakSzama = alkalmazottakSzama;
            this.befogadoKepesseg = befogadoKepesseg;
            this.betegekSzama = betegekSzama;
            this.felszereltseg = felszereltseg;
        }

        public string Nev
        {
            get => nev;
            set => nev = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int AlkalmazottakSzama
        {
            get => alkalmazottakSzama;
            set => alkalmazottakSzama = value;
        }

        public override void Hetente(Allam allam)
        {
            allam.AllamiBankszamla.Levonas(1_000_000);
        }
    }
}
