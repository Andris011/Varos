using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek;

public class IrodaSajat : Epulet, IMunkahely
{
    private string nev;
    private int maxAlkalmazottakSzama;

    public IrodaSajat(int epuletMerete, int karbantartottsag, int rezsi, string nev, int maxAlkalmazottakSzama) : base(epuletMerete, karbantartottsag, rezsi)
    {
        this.nev = nev;
        this.maxAlkalmazottakSzama = maxAlkalmazottakSzama;
    }

    public string Nev
    {
        get => nev;
        set => nev = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int MaxAlkalmazottakSzama
    {
        get => maxAlkalmazottakSzama;
        set => maxAlkalmazottakSzama = value;
    }
}