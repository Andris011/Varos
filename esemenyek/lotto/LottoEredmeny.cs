using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Lakossag;

namespace Varos.esemenyek.lotto
{
    internal class LottoEredmeny
    {
        Ember jackpotNyertes;
        int jackpotOsszeg;
        List<Ember> nyertesek = new List<Ember>();

        public Ember JackpotNyertes { get => jackpotNyertes; set => jackpotNyertes = value; }
        public int JackpotOsszeg { get => jackpotOsszeg; set => jackpotOsszeg = value; }
        public List<Ember> Nyertesek { get => nyertesek; set => nyertesek = value; }
    };
}
