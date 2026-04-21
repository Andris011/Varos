using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto
{
    internal class Loto
    {
        Dictionary<TesztEmber, int> tar;

        public Loto(Dictionary<TesztEmber, int> tar)
        {
            this.tar = tar;
        }

        internal Dictionary<TesztEmber, int> Tar { get => tar; set => tar = value; }

        public void SzelvenytVesz(TesztEmber ember, int darab)
        {
            Console.Clear();
            if (ember.Penz >= 1000)
            {
                int egySzelvenyAra = (int)(ember.Penz * 0.03);
                int osszAr = egySzelvenyAra * darab;

                if (ember.Penz >= osszAr)
                {
                    ember.Penz -= osszAr;

                    if (tar.ContainsKey(ember))
                        tar[ember] += darab;
                    else
                        tar.Add(ember, darab);

                    Console.WriteLine($"{ember.Nev} vett {darab} szelvényt. Maradék pénz: {ember.Penz}");
                }
                else
                {
                    Console.WriteLine("Nincs elég pénz a vásárláshoz.");
                }
            }
            else
            {
                Console.WriteLine("Minimum 1000 pénz szükséges.");
            }
        }

        public void TarKiir()
        {
            Console.Clear();
            Console.WriteLine("-----------------Rendszerben lévő szelvények-----------------");
            if (tar.Count == 0)
            {
                Console.WriteLine("Nincsenek még vásárolt szelvények.");
            }
            else
            {
      
                foreach (var elem in tar)
                {
                    TesztEmber ember = elem.Key;
                    int darab = elem.Value;

                    Console.WriteLine($"{ember.Nev} - {darab} db szelvény");
                }
            }
        }

    }
}
