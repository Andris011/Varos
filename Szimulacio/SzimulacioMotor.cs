using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Epulet;
using Varos.gazdasag.Bank;
using Varos.gazdasag.Bank.Impl;
using Varos.gazdasag.Munkahely;
using Varos.gazdasag.Nemzet;
using Varos.Lakossag;

namespace Varos.Szimulacio
{
    internal class SzimulacioMotor
    {
        public static void Futtatas()
        {
            int menuSzelesseg = 15;
            int mapSzelesseg = 10;
            int mapMagassag = 10;
            int emberSzam = 100;

            int hetekSzama = 0;

            SzimulacioEpito epito = new SzimulacioEpito();
            EsemenyMotor esemenyek = new EsemenyMotor();

            (Epulet.Epulet?[,] map, List<Epulet.Epulet> epuletek) = epito.MapGeneralas(mapSzelesseg, mapMagassag);
            List<Ember> emberek = epito.EmberGeneralas(map, emberSzam);
            List<Ceg> cegek = epito.MunkaGeneralas(emberek);

            epito.HazKereses(map, emberek);

            Allam allam = new Allam();

            foreach (Ember ember in emberek) allam.AllampolgarFelvesz(ember);
            foreach (Ceg ceg in cegek) allam.CegFelvesz(ceg);

            bool futAJatek = true;

            while (futAJatek)
            {
                esemenyek.Hetente(allam, epuletek);

                if (hetekSzama % 4 == 0)
                {
                    allam.Havonta();
                }

                StringBuilder menuIro = new StringBuilder();
                menuIro.AppendLine(MenuOsszerak(menuSzelesseg, hetekSzama));
                MapNyomtat(menuIro, map);

                Console.Clear();
                Console.WriteLine(menuIro.ToString());

                while (!Console.KeyAvailable) { }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                        hetekSzama++;
                        break;
                }
            }
        }

        private static string MenuOsszerak(int menuSzelesseg, int hetekSzama)
        {
            string menuSzalag = $"{hetekSzama + 1}. hét";
            string elotte = new string(' ', Math.Max(menuSzelesseg - menuSzalag.Length, 0) / 2);
            string utana = new string(' ', Math.Max(menuSzelesseg - menuSzalag.Length, 0) - elotte.Length);

            return $"====== {elotte}{menuSzalag}{utana} ======";
        }

        public static void MapNyomtat(StringBuilder menuIro, Epulet.Epulet?[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] is Epulet.Lakohazak.LakasSajat)
                    {
                        menuIro.Append("\x1B[0;34m");
                        menuIro.Append('▣');
                    }
                    else if (map[y, x] is Epulet.Lakohazak.LakasAlberlet)
                    {
                        menuIro.Append("\x1B[0;36m");
                        menuIro.Append('◩');
                    }
                    else
                    {
                        menuIro.Append(' ');
                    }
                }

                menuIro.AppendLine("\x1B[0m");
            }
        }
    }
}
