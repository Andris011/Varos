using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varos.gazdasag.Nemzet.NAV
{
    internal class NAV
    {
        public static int FizetesAdoSzamolas(GazdasagAllampolgar ember, int brutto)
        {
            double netto = brutto;

            // személyi jövedelemadó, kivéve 25 év alattiak
            if (ember.Eletkor >= 25)
            {
                netto -= brutto * 0.15;
            }

            // társadalombiztosítás
            netto -= brutto * 0.185;

            return (int) netto;
        }
    }
}
