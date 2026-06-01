using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek;

internal class Iroda : Epulet, IMunkahely
{
    private string nev;
    private int alkalmazottakSzama;

    public Iroda(int epuletMerete, int karbantartottsag, int rezsi, string nev, int alkalmazottakSzama) : base(epuletMerete, karbantartottsag, rezsi)
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
}