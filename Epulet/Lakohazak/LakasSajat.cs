using Varos.Epulet.Interfaces;

namespace Varos.Epulet.Lakohazak;

public class LakasSajat : Epulet, ILakohaz
{
    private int maxLakokSzama;
    private int szobakSzama;
    private double rezsi;

    public LakasSajat(int epuletMerete, int maxLakokSzama, int szobakSzama, double rezsi) : base(epuletMerete)
    {
        this.maxLakokSzama = maxLakokSzama;
        this.szobakSzama = szobakSzama;
        this.rezsi = rezsi;
    }

    public int MaxLakokSzama
    {
        get => maxLakokSzama;
        set => maxLakokSzama = value;
    }

    public int SzobakSzama
    {
        get => szobakSzama;
        set => szobakSzama = value;
    }

    public double Rezsi
    {
        get => rezsi;
        set => rezsi = value;
    }
}