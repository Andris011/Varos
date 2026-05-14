using Varos.Epulet.Interfaces;

namespace Varos.Epulet.Lakohazak;

public class LakasSajat : Epulet, ILakohaz
{
    private int maxLakokSzama;
    private int szobakSzama;

    public LakasSajat(int epuletMerete, int karbantartottsag, int rezsi, int maxLakokSzama, int szobakSzama) : base(epuletMerete, karbantartottsag, rezsi)
    {
        this.maxLakokSzama = maxLakokSzama;
        this.szobakSzama = szobakSzama;
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
}