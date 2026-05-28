using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Varos.Epulet.Interfaces;
using Varos.gazdasag.Bank;
using Varos.gazdasag.Bank.Impl;

namespace Varos.Lakossag
{
    internal class Ember
    {
        private int emberID;
        private string nev;
        private int eletKor;
        private string nem;
        private ILakohaz lakohazID;
        private string munka;
        private List<string> tulajdon;
        private int penz;
        private string statusz; //nagykoru, kiskoru, nyugdijas
        private int boldogsagSzint; //1-10
        private int ehessegSzint;// 1-10
        private int szomjSzint; //1-10
        private int fizikum; //1-10
        private bool hazasE;
        private bool varandosE;
        private int egeszsegSzint; //1-100
        private int veralkoholSzint; // 1-100 7 felett kampo, 3 felett korhaz
        private Bankszamla bankszamla;

        public Ember(int emberID, string nev, int eletKor, string nem, ILakohaz lakohazID, string munka, List<string> tulajdon, int penz, string statusz, int boldogsagSzint, int ehessegSzint, int szomjSzint, int fizikum, bool hazasE, bool varandosE, int egeszsegSzint, int veralkoholSzint, Bankszamla bankszamla)
        {
            this.EmberID = emberID;
            this.Nev = nev;
            this.EletKor = eletKor;
            this.Nem = nem;
            this.LakohazID = lakohazID;
            this.Munka = munka;
            this.Tulajdon = tulajdon;
            this.Penz = penz;
            this.Statusz = statusz;
            this.BoldogsagSzint = boldogsagSzint; // pl ide alap ertek
            this.EhessegSzint = ehessegSzint;
            this.SzomjSzint = szomjSzint;
            this.Fizikum = fizikum;
            this.HazasE = hazasE;
            this.VarandosE = varandosE;
            this.EgeszsegSzint = egeszsegSzint;
            this.VeralkoholSzint = veralkoholSzint;
            this.Bankszamla = bankszamla;
        }

        public int EmberID { get => emberID; set => emberID = value; }
        public string Nev { get => nev; set => nev = value; }
        public int EletKor { get => eletKor; set => eletKor = value; }
        public string Nem { get => nem; set => nem = value; }
        public ILakohaz LakohazID { get => lakohazID; set => lakohazID = value; }
        public string Munka { get => munka; set => munka = value; }
        public List<string> Tulajdon { get => tulajdon; set => tulajdon = value; }
        public int Penz { get => penz; set => penz = value; }
        public string Statusz { get => statusz; set => statusz = value; }
        public int BoldogsagSzint { get => boldogsagSzint; set => boldogsagSzint = value; }
        public int EhessegSzint { get => ehessegSzint; set => ehessegSzint = value; }
        public int SzomjSzint { get => szomjSzint; set => szomjSzint = value; }
        public int Fizikum { get => fizikum; set => fizikum = value; }
        public bool HazasE { get => hazasE; set => hazasE = value; }
        public bool VarandosE { get => varandosE; set => varandosE = value; }
        public int EgeszsegSzint { get => egeszsegSzint; set => egeszsegSzint = value; }
        public int VeralkoholSzint { get => veralkoholSzint; set => veralkoholSzint = value; }
        internal Bankszamla Bankszamla { get => bankszamla; set => bankszamla = value; }
    }
    
    // TODO boldogsag meg ilyenek bentrol valtoztatni (mint egy metodus)
}
