using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Lakossag;

namespace Varos.esemenyek.karacsony
{
    internal class Karacsony
    {
        public void KaracsonyInditasa(List<Ember> lakossag)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nKarácsony elkezdődött");

            Console.ResetColor();
            Console.WriteLine("\tHo-ho-ho! Boldog Karácsonyt!"); // Kringelin nem jár mellé
            Console.WriteLine("\tMindenki boldogsága nőtt 2-vel");
            Console.WriteLine("\tAz ünnepi vacsora csökkentette az éhséget és szomjúságot 3-mal");

            foreach (Ember ember in lakossag)
            {
                ember.BoldogsagSzint = Math.Min(10, ember.BoldogsagSzint + 2);
                ember.EhessegSzint = Math.Max(1, ember.EhessegSzint - 3);
                ember.SzomjSzint = Math.Max(1, ember.SzomjSzint - 3);
            }

            //KaracsonyVege();
        }

        public void KaracsonyVege()
        {
            Console.WriteLine("A karácsony véget ért.");
        }
    }
}
