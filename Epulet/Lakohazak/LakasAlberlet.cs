using Varos.Epulet.Interfaces;

namespace Varos.Epulet.Lakohazak;

public class LakasAlberlet : IEpulet, ILakohaz, IAlberlet
{
    private int maxLakokSzama;
    private int szobakSzama;
    private int hazMerete;
    private double rezsi;
    private double berletiDij;

    public LakasAlberlet(int maxLakokSzama, int szobakSzama, int hazMerete, double rezsi, double berletiDij)
    {
        this.maxLakokSzama = maxLakokSzama;
        this.szobakSzama = szobakSzama;
        this.hazMerete = hazMerete;
        this.rezsi = rezsi;
        this.berletiDij = berletiDij;
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

    public double BerletiDij
    {
        get => berletiDij;
        set => berletiDij = value;
    }

    public void BerletiDijKifizetese()
    {
        // TODO: ha kesz az ember a penzebol vonja le a berleti dijat
    }
}