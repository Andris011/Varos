using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek;

public class IrodaSajat : IEpulet, IMunkahely
{
    private int epuletMerete;
    private string nev;
    private int alkalmazottakSzama;

    public IrodaSajat(int epuletMerete, string nev, int alkalmazottakSzama)
    {
        this.epuletMerete = epuletMerete;
        this.nev = nev;
        this.alkalmazottakSzama = alkalmazottakSzama;
    }

    public int EpuletMerete
    {
        get => epuletMerete;
        set => epuletMerete = value;
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