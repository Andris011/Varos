using Varos.Epulet.Interfaces;
using Varos.gazdasag.Nemzet;

namespace Varos.Epulet.Segelyszervek;

internal class Rendorseg : Epulet, IMunkahely
{
    private string nev;
    private int alkalmazottakSzama;

    public Rendorseg(int epuletMerete, int karbantartottsag, int rezsi, string nev, int alkalmazottakSzama) : base(epuletMerete, karbantartottsag, rezsi)
    {
        this.nev = nev;
        this.alkalmazottakSzama = alkalmazottakSzama;
    }
    
    public string Nev
    {
        get => nev;
        set => nev = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int AlkalmazottakSzama
    {
        get => alkalmazottakSzama;
        set => alkalmazottakSzama = value;
    }

    public override void Hetente(Allam allam)
    {
        allam.AllamiBankszamla.Levonas(800_000);
    }
}