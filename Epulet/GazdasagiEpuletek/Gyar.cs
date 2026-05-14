using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek;

public class Gyar : IEpulet, IMunkahely
{
    private string nev;
    private int epuletMerete;
    private int alkalmazottakSzama;
    private string termek; //mit gyart  TODO: gazdasagban az adozast ez alapjan csinalni (?)

    public Gyar(string nev, int epuletMerete, int alkalmazottakSzama, string termek)
    {
        this.nev = nev;
        this.epuletMerete = epuletMerete;
        this.alkalmazottakSzama = alkalmazottakSzama;
        this.termek = termek;
    }

    public string Nev
    {
        get => nev;
        set => nev = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int EpuletMerete
    {
        get => epuletMerete;
        set => epuletMerete = value;
    }

    public int AlkalmazottakSzama
    {
        get => alkalmazottakSzama;
        set => alkalmazottakSzama = value;
    }
}