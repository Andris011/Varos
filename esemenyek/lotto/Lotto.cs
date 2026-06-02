using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Lakossag;



namespace Varos.esemenyek.lotto
{
    internal class Lotto
    {
        Dictionary<Ember, int> tar;
        int osszpenz;

        public Lotto(Dictionary<Ember, int> tar, int osszpenz = 0)
        {
            this.tar = tar;
            this.osszpenz = osszpenz;
        }

        internal Dictionary<Ember, int> Tar { get => tar; set => tar = value; }

        public void SzelvenytVesz(Ember vasarlo, int darab)
        {
            // Console.Clear();
            if (vasarlo.Bankszamla.Megfizetheto(1500))
            {
                int egySzelvenyAra = 1500;
                int osszAr = egySzelvenyAra * darab;

                vasarlo.Bankszamla.Levonas(osszAr);

                    if (tar.ContainsKey(vasarlo))
                        tar[vasarlo] += darab;
                    else
                        tar.Add(vasarlo, darab);

                    //Console.WriteLine($"{ember.Nev} vett {darab} szelvényt. Maradék pénz: {ember.Bankszamla.Egyenleg}");
                    osszpenz += osszAr;
                

            }
            else
            {
                //Console.WriteLine("Minimum 1500 pénz szükséges.");
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
                    Ember vasarlo = elem.Key;
                    int darab = elem.Value;

                    Console.WriteLine($"{vasarlo.Nev} - {darab} db szelvény");
                }
            }
        }

        private Random rnd = new Random();

        
        public LottoEredmeny Roll()
        {
            //Console.Clear();
            LottoEredmeny eredmeny = new LottoEredmeny();

            foreach (var item in tar)
            {
                Ember vasarlo = item.Key;
                int szelvenyek=item.Value;

                    for (int i = 0; i < szelvenyek; i++)
                    {
                        //Console.WriteLine("roll");
                        if (osszpenz <= 0) break;

                        int roll = rnd.Next(2000);
                        //roll = 0;
                        int nyeremeny = 0;

                        if (roll == 0)
                        {
                            nyeremeny = osszpenz;
                            eredmeny.JackpotNyertes=vasarlo;
                            eredmeny.JackpotOsszeg=nyeremeny;
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


                        if (nyeremeny > 0)
                        {
                            vasarlo.Bankszamla.Feltoltes(nyeremeny);
                            //vasarlo.BoldogsagSzint = 10;

                            if (vasarlo != eredmeny.JackpotNyertes)
                            {
                               eredmeny.Nyertesek.Add(vasarlo);
                            }
                            //Console.WriteLine($"{ember.Nev} nyert {nyeremeny} pénzt!");
                        }
                        else
                        {
                             //vasarlo.BoldogsagSzint -= 1;
                        }
                    }

            }
            
            tar.Clear();
            return eredmeny;

        }
    }
}

