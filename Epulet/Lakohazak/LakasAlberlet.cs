using Varos.Epulet.Interfaces;

namespace Varos.Epulet.Lakohazak;

internal class LakasAlberlet : Epulet, ILakohaz, IAlberlet
{
    private int maxLakokSzama;
    private int szobakSzama;
    private double berletiDij;
    // private List<Ember> emberek;

    public LakasAlberlet(int epuletMerete, int karbantartottsag, int rezsi, int maxLakokSzama, int szobakSzama, double berletiDij) : base(epuletMerete, karbantartottsag, rezsi)
    {
        this.maxLakokSzama = maxLakokSzama;
        this.szobakSzama = szobakSzama;
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