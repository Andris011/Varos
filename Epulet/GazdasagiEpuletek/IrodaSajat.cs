using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek;

public class IrodaSajat : Epulet, IMunkahely
{
    private string nev;
    private int alkalmazottakSzama;

    public IrodaSajat(int epuletMerete, string nev, int alkalmazottakSzama) : base(epuletMerete)
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