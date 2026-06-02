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
        private string nev;
        private double eletKor;
        private string nem; // F-M
        private ILakohaz lakohazID;
        private bool hazasE;
        private Ember hazastars;
        private bool varandosE;
        private bool szuletettGyermeke;
        private int varandossagSzamlalo;
        private bool halottE;
        private Bankszamla bankszamla;

        public Ember(string nev, double eletKor, string nem, ILakohaz lakohazID, Bankszamla bankszamla)
        {
            this.nev = nev;
            this.eletKor = eletKor;
            this.nem = nem;
            this.lakohazID = lakohazID;
            this.hazasE = false;
            this.hazastars = null;
            this.varandosE = false;
            this.szuletettGyermeke = false;
            this.varandossagSzamlalo = 0;
            this.halottE = false;
            this.bankszamla = bankszamla;
        }

        public string Nev { get => nev; set => nev = value; }
        public double EletKor { get => eletKor; set => eletKor = value; }
        public string Nem { get => nem; set => nem = value; }
        public ILakohaz LakohazID { get => lakohazID; set => lakohazID = value; }
        public bool HazasE { get => hazasE; set => hazasE = value; }
        public Ember Hazastars { get => hazastars; set => hazastars = value; }
        public bool VarandosE { get => varandosE; set => varandosE = value; }
        public bool SzuletettGyermeke { get => szuletettGyermeke; set => szuletettGyermeke = value; }
        public int VarandossagSzamlalo { get => varandossagSzamlalo; set => varandossagSzamlalo = value; }
        public bool HalottE { get => halottE; set => halottE = value; }
        internal Bankszamla Bankszamla { get => bankszamla; set => bankszamla = value; }

        public void Halal()
        {
            this.halottE = true;
        }
        public void VarandossagKapcsolo()
        {
            if (this.nem == "F")
            {
                this.varandosE = !this.varandosE;
            }
        }
        public void HazassagKotes(Ember leendoHazastars)
        {
            this.hazasE = true;
            this.hazastars = leendoHazastars;
        }
        public void Elvalas()
        {
            this.hazasE = false;
            this.hazastars = null;
        }
        public void Hetente()
        {
            Random rnd = new Random();
            int halalozasiSzamAlap = rnd.Next(1, 1001);
            int halalozasiSzam80 = rnd.Next(1, 101);
            this.eletKor += 0.02;
            if (this.eletKor < 80)
            {
                if (halalozasiSzamAlap == 67)
                {
                    Halal();
                    return;
                }
            }
            else
            {
                if (halalozasiSzam80 == 67)
                {
                    Halal();
                    return;
                }
            }
            if (this.varandosE)
            {
                this.varandossagSzamlalo += 1;
            }
            if (this.varandossagSzamlalo >= 39)
            {
                VarandossagKapcsolo();
                this.varandossagSzamlalo = 0;
                this.szuletettGyermeke = true;
            }
        }
    }
}