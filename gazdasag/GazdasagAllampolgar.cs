using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.gazdasag.Bank;

namespace Varos.gazdasag
{
    interface GazdasagAllampolgar
    {
        int Eletkor { get; }

        Bankszamla Szamla { get; }
    }
}
