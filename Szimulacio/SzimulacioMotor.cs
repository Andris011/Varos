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
        private static string kiemeltSzoveg = "";

        public static string KiemeltSzoveg { get => kiemeltSzoveg; set => kiemeltSzoveg = value; }

        public static void Futtatas()
        {
            int menuSzelesseg = 36;
            int mapSzelesseg = 10;
            int mapMagassag = 10;
            int emberSzam = 250;

            int hetekSzama = 0;

            Random rng = new Random();

            SzimulacioEpito epito = new SzimulacioEpito();
            EsemenyMotor esemenyek = new EsemenyMotor();

            (Epulet.Epulet?[,] map, List<(Epulet.Epulet, (int, int))> epuletek) = epito.MapGeneralas(mapSzelesseg, mapMagassag);
            List<Ember> emberek = epito.EmberGeneralas(emberSzam);
            List<Ceg> cegek = epito.MunkaGeneralas(emberek);

            epito.HazKereses(map, emberek);

            Allam allam = new Allam();

            foreach (Ember ember in emberek) allam.AllampolgarFelvesz(ember);
            foreach (Ceg ceg in cegek) allam.CegFelvesz(ceg);

            string leallasUzenet = "";
            bool mindenkeppLeall = false;
            bool futAJatek = true;
            bool lepes = false;

            int hetenHalottak = 0;
            int hetenSzulettek = 0;

            Console.CursorVisible = false;

            while (futAJatek)
            {
                StringBuilder iro = new StringBuilder();

                iro.Append(new string('\n', 1000));
                iro.AppendLine(MenuOsszerak(menuSzelesseg, hetekSzama));

                MapNyomtat(iro, map);
                StatNyomtat(iro, allam, cegek.Count, epuletek.Count, hetenSzulettek, hetenHalottak);

                iro.Append("\n");
                iro.Append("\x1B[0;32m");
                MenuKiir(iro, menuSzelesseg, kiemeltSzoveg);
                iro.Append("\x1B[0m");

                Console.Write(iro.ToString());

                hetenHalottak = 0;
                hetenSzulettek = 0;

                if (mindenkeppLeall)
                {
                    futAJatek = false;
                }

                if (!mindenkeppLeall)
                {
                    if (lepes)
                    {
                        lepes = false;
                        esemenyek.Hetente(allam, epuletek, map);

                        List<Ember> emberekClone = new List<Ember>(emberek);

                        foreach (Ember ember in emberekClone)
                        {
                            ember.Hetente();

                            if (rng.Next(1, 350) == 1 && !ember.VarandosE)
                            {
                                ember.VarandossagKapcsolo();
                            }

                            if (ember.EletKor == 18 && !allam.VanMunkaja(ember))
                            {
                                Ceg ceg = cegek[rng.Next(0, cegek.Count)];
                                ceg.Alkalmaz(ember, (ceg.Munkavallalok.Sum(vall => vall.Fizetes) / ceg.Munkavallalok.Count) + rng.Next(-15_000, 15_000));
                            }

                            if (ember.SzuletettGyermeke)
                            {
                                ember.SzuletettGyermeke = false;

                                List<Ember> ujszulottek = epito.EmberGeneralas(rng.Next(1, 2));

                                foreach (Ember szuletett in ujszulottek)
                                {
                                    hetenSzulettek++;
                                    emberek.Add(szuletett);
                                    allam.AllampolgarFelvesz(szuletett);
                                }
                            }

                            if (ember.HalottE)
                            {
                                hetenHalottak++;
                                ember.HalottE = false;
                                emberek.Remove(ember);
                                allam.AllampolgarElhunyt(ember);
                            }
                        }

                        foreach ((Epulet.Epulet epulet, _) in epuletek)
                        {
                            epulet.Hetente(allam);
                        }

                        if (hetekSzama % 4 == 0)
                        {
                            allam.Havonta();
                        }
                    }

                    if (allam.Allampolgarok.Count == 0)
                    {
                        mindenkeppLeall = true;
                        leallasUzenet = "Mindenki meghalt!";
                    }

                    if (epuletek.Count == 0)
                    {
                        mindenkeppLeall = true;
                        leallasUzenet = "Minden epület ledőlt!";
                    }

                    if (!allam.AllamiBankszamla.Megfizetheto(1))
                    {
                        if (rng.Next(1, 10) == 1)
                        {
                            mindenkeppLeall = true;
                            leallasUzenet = "Az állam csődbe ment!";
                        } else
                        {
                            Tamogatas tamogatas = new Tamogatas("Európai Unió csődkisegítő támogatás", 100_000_000, "Csendes kis város");
                            tamogatas.Felvesz(allam.AllamiBankszamla);
                        }
                    }
                }

                if (mindenkeppLeall)
                {
                    string sor = new string('─', leallasUzenet.Length + 2);
                    Console.WriteLine($"\n{sor}\n {leallasUzenet} \n{sor}");
                }

                ConsoleKey betu = Console.ReadKey(true).Key;

                if (betu == ConsoleKey.Escape)
                {
                    futAJatek = false;
                }

                hetekSzama++;
                lepes = true;
            }

            Console.WriteLine("\nKilépés a szimulációból...");
        }

        private static void MenuKiir(StringBuilder iro, int menuSzelesseg, string line)
        {
            menuSzelesseg += 14;

            for (int i = 0; i < line.Length; i += menuSzelesseg)
            {
                iro.AppendLine(line.Substring(i, Math.Min(menuSzelesseg, line.Length - i)));
            }
        }

        private static string MenuOsszerak(int menuSzelesseg, int hetekSzama)
        {
            string menuSzalag = $"{hetekSzama + 1}. hét";
            string elotte = new string(' ', Math.Max(menuSzelesseg - menuSzalag.Length, 0) / 2);
            string utana = new string(' ', Math.Max(menuSzelesseg - menuSzalag.Length, 0) - elotte.Length);

            return $"====== {elotte}{menuSzalag}{utana} ======";
        }

        public static void StatNyomtat(StringBuilder iro, Allam allam, int cegSzam, int epuletSzam, int szuletesek, int halalok)
        {
            iro.Append("\n");

            iro.AppendLine("Állam adatai:");
            iro.AppendLine($"- államkincstár nagysága: {allam.AllamiBankszamla.Egyenleg}");
            iro.Append("\n");

            iro.AppendLine("Város adatai:");
            iro.AppendLine($"- épületek: {epuletSzam}");
            iro.Append("\n");

            int nyugdijasok = 0;
            int varandosok = 0;

            foreach (Ember ember in allam.Allampolgarok)
            {
                varandosok += (ember.VarandosE ? 1 : 0);
                nyugdijasok += (ember.EletKor > 67 ? 1 : 0);
            }

            iro.AppendLine("Demográfiai adatok:");
            iro.AppendLine($"- lakosok: {allam.Allampolgarok.Count}");
            iro.AppendLine($"- születések/természetes halálok: {szuletesek}/{halalok}");
            iro.AppendLine($"- várandósok: {varandosok} ({Math.Round(((double)varandosok / allam.Allampolgarok.Count) * 100)}%)");
            iro.AppendLine($"- nyugdíjasok: {nyugdijasok} ({Math.Round(((double)nyugdijasok / allam.Allampolgarok.Count) * 100)}%)");
        }

        public static void MapNyomtat(StringBuilder iro, Epulet.Epulet?[,] map)
        {

            string[,] kepernyoMatrix = new string[map.GetLength(0) * 3, map.GetLength(1) * 6];

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    string kiirt = "";

                    if (map[y, x] is Epulet.Lakohazak.LakasSajat)
                    {
                        kiirt = "\x1B[0;32mL\x1b[0m";
                    }
                    else if (map[y, x] is Epulet.Lakohazak.LakasAlberlet)
                    {
                        kiirt = "\x1B[0;92mA\x1b[0m";
                    }
                    else if (map[y, x] is Epulet.Segelyszervek.Korhaz)
                    {
                        kiirt = "\x1B[0;31mK\x1b[0m";
                    }
                    else if (map[y, x] is Epulet.Segelyszervek.Rendorseg)
                    {
                        kiirt = "\x1B[0;34mR\x1b[0m";
                    }
                    else if (map[y, x] is Epulet.Segelyszervek.Tuzoltosag)
                    {
                        kiirt = "\x1B[0;33mT\x1b[0m";
                    }
                    else if (map[y, x] is Epulet.Iskola.Iskola)
                    {
                        kiirt = "\x1B[0;35mI\x1b[0m";
                    }

                    if (kiirt.Length > 0)
                    {
                        kepernyoMatrix[y * 3, x * 5] = "┌";
                        kepernyoMatrix[y * 3, x * 5 + 4] = "┐";

                        kepernyoMatrix[y * 3 + 1, x * 5] = "│";
                        kepernyoMatrix[y * 3 + 1, x * 5 + 4] = "│";

                        kepernyoMatrix[y * 3 + 2, x * 5] = "└";
                        kepernyoMatrix[y * 3 + 2, x * 5 + 4] = "┘";

                        kepernyoMatrix[y * 3 + 1, x * 5 + 2] = kiirt;

                        for (int i = 0; i < 3; i++)
                        {
                            kepernyoMatrix[y * 3, x * 5 + 1 + i] = "─";
                            kepernyoMatrix[y * 3 + 2, x * 5 + 1 + i] = "─";
                        }
                    }
                }
            }

            for (int y = 0; y < kepernyoMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < kepernyoMatrix.GetLength(1); x++)
                {
                    string szoveg = kepernyoMatrix[y, x];
                    if (szoveg is null) szoveg = " ";
                    iro.Append(szoveg);
                }
                iro.Append("\n");
            }
        }
    }
}
