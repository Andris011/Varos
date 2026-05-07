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
        int osszpenz;

        public Loto(Dictionary<TesztEmber, int> tar)
        {
            this.tar = tar;
            this.osszpenz = 0;
        }

        internal Dictionary<TesztEmber, int> Tar { get => tar; set => tar = value; }

        public void SzelvenytVesz(TesztEmber ember, int darab)
        {
            Console.Clear();
            if (ember.Penz >= 1500)
            {
                int egySzelvenyAra = 1500;
                int osszAr = egySzelvenyAra * darab;

                if (ember.Penz >= osszAr)
                {
                    ember.Penz -= osszAr;

                    if (tar.ContainsKey(ember))
                        tar[ember] += darab;
                    else
                        tar.Add(ember, darab);

                    Console.WriteLine($"{ember.Nev} vett {darab} szelvényt. Maradék pénz: {ember.Penz}");
                    osszpenz += osszAr;
                }
                else
                {
                    Console.WriteLine("Nincs elég pénz a vásárláshoz.");
                }
            }
            else
            {
                Console.WriteLine("Minimum 1500 pénz szükséges.");
            }
        }

        public void TarKiir()
        {
            Console.Clear();
            Console.WriteLine("-----------------Rendszerben lévő pénz-----------------------");
            Console.WriteLine(this.osszpenz);
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

        private Random rnd = new Random();
        public void Roll()
        //100%- 1/10000 | 10% - 1/1000 | 1% - 1/100 | 0.1% - 1/10
        {

            Console.Clear();

            foreach (var item in tar)
            {
                TesztEmber ember =item.Key;
                int szelvenyek=item.Value;

                    for (int i = 0; i < szelvenyek; i++)
                    {
                        if (osszpenz <= 0) break;

                        int roll = rnd.Next(10000);
                        int nyeremeny = 0;

                        if (roll == 0)
                        {
                            nyeremeny = osszpenz;
                            osszpenz = 0;
                        }
                        else if (roll < 10)
                        {
                            nyeremeny = (int)(osszpenz * 0.1);
                            osszpenz -= nyeremeny;
                        }
                        else if (roll < 100)
                        {
                            nyeremeny = (int)(osszpenz * 0.01);
                            osszpenz -= nyeremeny;
                        }
                        else if (roll < 1000)
                        {
                            nyeremeny = (int)(osszpenz * 0.001);
                            osszpenz -= nyeremeny;
                        }

                        if (nyeremeny > 0)
                        {
                            ember.Penz += nyeremeny;
                            Console.WriteLine($"{ember.Nev} nyert {nyeremeny} pénzt!");
                        }

                    }

            }
            tar.Clear();

        }
    }
}

