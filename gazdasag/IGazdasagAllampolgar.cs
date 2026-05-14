using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.gazdasag.Bank;

namespace Varos.gazdasag
{
    interface IGazdasagAllampolgar
    {
        int Eletkor { get; }

        Bankszamla Szamla { get; } // ha elmult 70 nem kotelezo (talan)
        
        // 
    }
}
