using Varos.Epulet.Interfaces;

namespace Varos.Epulet.Lakohazak;

public class LakasSajat : IEpulet, ILakohaz
{
    private int maxLakokSzama;
    private int szobakSzama;
    private int hazMerete;
    private double rezsi;

    public LakasSajat(int maxLakokSzama, int szobakSzama, int hazMerete, double rezsi)
    {
        this.maxLakokSzama = maxLakokSzama;
        this.szobakSzama = szobakSzama;
        this.hazMerete = hazMerete;
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

    public int EpuletMerete
    {
        get => hazMerete;
        set => hazMerete = value;
    }

    public double Rezsi
    {
        get => rezsi;
        set => rezsi = value;
    }
}