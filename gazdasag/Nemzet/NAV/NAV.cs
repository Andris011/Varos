using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Lakossag;

namespace Varos.gazdasag.Nemzet.NAV
{
    internal class NAV
    {
        public static int FizetesAdoSzamolas(Ember ember, int brutto)
        {
            double netto = brutto;

            // személyi jövedelemadó, kivéve 25 év alattiak
            if (ember.EletKor >= 25)
            {
                netto -= brutto * 0.15;
            }

            // társadalombiztosítás
            netto -= brutto * 0.185;

            return (int) netto;
        }
    }
}
