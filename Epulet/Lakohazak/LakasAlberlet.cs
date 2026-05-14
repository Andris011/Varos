using Varos.Epulet.Interfaces;

namespace Varos.Epulet.Lakohazak;

public class LakasAlberlet : Epulet, ILakohaz, IAlberlet
{
    private int maxLakokSzama;
    private int szobakSzama;
    private double rezsi;
    private double berletiDij;
    // private List<Ember> emberek;

    public LakasAlberlet(int epuletMerete, int maxLakokSzama, int szobakSzama, double rezsi, double berletiDij) : base(epuletMerete)
    {
        this.maxLakokSzama = maxLakokSzama;
        this.szobakSzama = szobakSzama;
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