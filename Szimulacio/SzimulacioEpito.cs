using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.gazdasag.Bank;
using Varos.gazdasag.Bank.Impl;
using Varos.gazdasag.Munkahely;
using Varos.Lakossag;

namespace Varos.Szimulacio
{
    internal class SzimulacioEpito
    {
        private string[] vezetekNevek = {
            "Kovács","Szabó","Tóth","Horváth","Varga","Kiss","Molnár","Németh","Farkas","Balogh","Takács","Juhász","Mészáros","Oláh","Simon","Rácz","Fekete","Papp","Lakatos","Nagy","Kelemen","Gál","Sipos","Bíró","Antal","Kocsis","Bognár","Lukács","Veres","Vass","Szűcs","Katona","Orbán","Barna","Pintér","Császár","Benedek","Demeter","Sebestyén","Nyári","Somogyi","Illés","Dombi","Boros","Major","Pál","Barta","Vida","Csorba","Kádár","Tamás","Zsoldos","Hegedűs","Dávid","Székely","Albert","Csontos","Gergely","Sánta","Pusztai","Sándor","Kecskés","Miklós","Török","Fehér","Madarász","Füredi","Bencze","Halász","Bozsik","Jakab","Erdei","Csizmadia","Dobos","Pénzes","Kárpáti","Tímár","Kántor","Vitéz","Balla","Sárosi","Herczeg","Gönczi","Szalai","Faragó","Bagoly","Dénes","Kulcsár","Tasi","Pék","Békési","Rózsa","Zentai","Kőrösi","Kalmár","Csiki","Békés","Kende","Völgyi","Ács"
        };

        private string[] keresztNevek = {
            "Dominik", "Olivér", "Levente", "Máté", "Marcell", "Bence", "Milán", "Noel", "Zalán", "Dániel", "Ádám", "Benett", "Botond", "Zsombor", "Áron", "Dávid", "Nolen", "Balázs", "Nimród", "Benedek", "Márk", "Kristóf", "Zente", "Péter", "Barnabás", "Tamás", "Martin", "Hunor", "Kornél", "László", "Bálint", "Zétény", "Alex", "Ábel", "András", "Gergő", "István", "Vince", "Márton", "Zoltán", "Ákos", "Bendegúz", "Attila", "Soma", "Patrik", "Nándor", "Erik", "Gábor", "Zsolt", "Benjámin", "János", "Ármin", "Mátyás", "Kevin", "Krisztián", "József", "Sándor", "Csongor", "Vencel", "Kende", "Mihály", "Roland", "Richárd", "Miron", "Norbert", "Csaba", "Ferenc", "Szabolcs", "Róbert", "Denisz", "Simon", "Vilmos", "Boldizsár", "Teodor", "Eliot", "Benjamin", "Zénó", "Dorián", "Tibor", "Mirkó", "Nátán", "Sámuel", "Bertalan", "Viktor", "Adrián", "Merse", "Bende", "Donát", "Gergely", "Félix", "Laurent", "Miklós", "Flórián", "Gellért", "Csanád", "Kolen", "Bercel", "Imre", "Alexander", "Maxim",
            "Hanna", "Anna", "Luca", "Zoé", "Léna", "Emma", "Olívia", "Boglárka", "Lili", "Kamilla", "Laura", "Szofia", "Lilien", "Mira", "Alíz", "Sára", "Zsófia", "Flóra", "Lara", "Adél", "Izabella", "Jázmin", "Nóra", "Janka", "Liza", "Bella", "Linett", "Lilla", "Fanni", "Maja", "Gréta", "Zselyke", "Panna", "Dorka", "Emília", "Blanka", "Rebeka", "Liliána", "Abigél", "Csenge", "Elena", "Milla", "Nara", "Natasa", "Bianka", "Elizabet", "Eszter", "Lotti", "Dóra", "Róza", "Szofi", "Szófia", "Viktória", "Petra", "Noémi", "Odett", "Júlia", "Eliza", "Dorina", "Réka", "Lujza", "Amira", "Johanna", "Nazira", "Boróka", "Hanga", "Zora", "Panka", "Emili", "Mia", "Szonja", "Zorka", "Vivien", "Natália", "Zejnep", "Lia", "Tamara", "Elina", "Norina", "Nina", "Letícia", "Bíborka", "Diána", "Fruzsina", "Alina", "Hédi", "Borbála", "Regina", "Lana", "Mirella", "Olivia", "Dorottya", "Mirabella", "Alexandra", "Kincső", "Lora", "Zita", "Kinga", "Rozina", "Luna"
        };

        private Random rng;

        public SzimulacioEpito()
        {
            rng = new Random();
        }

        public (Epulet.Epulet?[,], List<(Epulet.Epulet, (int, int))>) MapGeneralas(int szelesseg, int magassag)
        {
            Epulet.Epulet?[,] map = new Epulet.Epulet[magassag, szelesseg];
            List<(Epulet.Epulet, (int, int))> epuletek = new List<(Epulet.Epulet, (int, int))>();

            for (int y = 0; y < magassag; y++)
            {
                for (int x = 0; x < szelesseg; x++)
                {
                    Epulet.Epulet? epulet = null;

                    int random = rng.Next(0, 3);

                    if (random == 0)
                    {
                        int rezsi = rng.Next(5, 10) * 6767;
                        int berleti = rng.Next(1, 4) * 100_000;
                        int lakok = rng.Next(1, 5);

                        epulet = new Epulet.Lakohazak.LakasAlberlet(40, 10 - rng.Next(1, 3), rezsi, lakok, berleti / 100_000 + lakok + rng.Next(1, 2), berleti);
                    }
                    else if (random == 1)
                    {
                        int rezsi = rng.Next(5, 10) * 6767;
                        int lakok = rng.Next(1, 5);

                        epulet = new Epulet.Lakohazak.LakasSajat(40, 10 - rng.Next(1, 3), rezsi, lakok, lakok + rng.Next(1, 2));
                    }

                    map[y, x] = epulet;

                    if (!(epulet is null))
                    {
                        epuletek.Add((epulet, (x, y)));
                    }
                }
            }

            List<(int, int)> ureshelyek = new List<(int, int)>();

            int korhazak = 2;
            int rendorsegek = 1;
            int tuzoltosagok = 1;
            int iskolak = 3;

            for (int y = 0; y < magassag; y++)
            {
                for (int x = 0; x < szelesseg; x++)
                {
                    if (map[y, x] is null)
                    {
                        ureshelyek.Add((x, y));
                    }
                }
            }

            for (int i = ureshelyek.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (ureshelyek[i], ureshelyek[j]) = (ureshelyek[j], ureshelyek[i]);
            }

            foreach ((int x, int y) in ureshelyek)
            {
                Epulet.Epulet? epulet = null;
                int rezsi = rng.Next(6, 7) * 6767;

                if (epulet is null && korhazak-- > 0)
                {
                    epulet = new Epulet.Segelyszervek.Korhaz(40, 10 - rng.Next(1, 3), rezsi, "Városi Korház", 6, 7, 6, 7);
                }

                if (epulet is null && rendorsegek-- > 0)
                {
                    epulet = new Epulet.Segelyszervek.Rendorseg(40, 10 - rng.Next(1, 3), rezsi, "Rendőrfőkapitányság", 6);
                }

                if (epulet is null && tuzoltosagok-- > 0)
                {
                    epulet = new Epulet.Segelyszervek.Tuzoltosag(40, 10 - rng.Next(1, 3), rezsi, "Tűzoltóság", 7);
                }

                if (epulet is null && iskolak-- > 0)
                {
                    epulet = new Epulet.Iskola.Iskola(40, 10 - rng.Next(1, 3), rezsi, "Iskola", 6, 7);
                }

                if (epulet is null)
                {
                    break;
                }

                map[y, x] = epulet;
                epuletek.Add((epulet, (x, y)));
            }

            return (map, epuletek);
        }

        public List<Ember> EmberGeneralas(int emberSzam)
        {
            List<Ember> emberek = new List<Ember>();

            for (int i = 0; i < emberSzam; i++)
            {
                string nem = rng.Next(0, 2) == 0 ? "F" : "M";
                bool hazassag = rng.Next(0, 10) == 0;

                Bankszamla szamla = new MaganBankszamla();
                szamla.Feltoltes(rng.Next(100_000, 400_000));

                emberek.Add(new Ember(TeljesNev(), rng.Next(5, 70), nem, null, szamla));
            }

            return emberek;
        }

        public void HazKereses(Epulet.Epulet?[,] map, List<Ember> emberek)
        {
            int y = 0;
            int x = 0;

            int feltoltott = 0;

            List<Ember> koltoztetendo = new List<Ember>(emberek);

            while (koltoztetendo.Count > 0)
            {
                Ember ember = koltoztetendo[0];

                bool kovetkezoHaz = false;

                if (map[y, x] is Epulet.Lakohazak.LakasSajat sajat && feltoltott < sajat.MaxLakokSzama)
                {
                    ember.LakohazID = sajat;
                    koltoztetendo.RemoveAt(0);
                    feltoltott++;
                    kovetkezoHaz = true;
                }

                if (map[y, x] is Epulet.Lakohazak.LakasAlberlet alberlet && feltoltott < alberlet.MaxLakokSzama)
                {
                    ember.LakohazID = alberlet;
                    koltoztetendo.RemoveAt(0);
                    feltoltott++;
                    kovetkezoHaz = true;
                }

                if (!(map[y, x] is Epulet.Interfaces.ILakohaz))
                {
                    kovetkezoHaz = true;
                }

                if (kovetkezoHaz)
                {
                    feltoltott = 0;
                    x++;

                    if (x >= map.GetLength(1))
                    {
                        x = 0;
                        y++;
                    }

                    if (y >= map.GetLength(0))
                    {
                        break;
                    }
                }
            }
        }

        public List<Ceg> MunkaGeneralas(List<Ember> emberek)
        {
            List<Ceg> cegek = new List<Ceg>();
            Ceg? ceg = null;

            foreach (Ember ember in emberek)
            {
                if (rng.Next(1, 20) > 1)
                {
                    if (ceg is null || rng.Next(1, 5) == 1)
                    {
                        ceg = new Ceg();
                        cegek.Add(ceg);
                    }

                    ceg.Alkalmaz(ember, 200_000 + rng.Next(0, 50_000));
                }
            }

            return cegek;
        }

        private string TeljesNev()
        {
            string vezetekNev = vezetekNevek[rng.Next(0, vezetekNevek.Length)];
            string keresztNev = keresztNevek[rng.Next(0, keresztNevek.Length)];
            return $"{vezetekNev} {keresztNev}";
        }
    }
}
