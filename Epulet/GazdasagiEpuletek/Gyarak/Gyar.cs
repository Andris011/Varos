using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek.Gyarak;

public class Gyar : Epulet, IMunkahely
{
    private string nev;
    private int alkalmazottakSzama;
    private string termek; //mit gyart  TODO: gazdasagban az adozast ez alapjan csinalni (?)

    public Gyar(int epuletMerete, string nev, int alkalmazottakSzama, string termek) : base(epuletMerete)
    {
        this.nev = nev;
        this.alkalmazottakSzama = alkalmazottakSzama;
        this.termek = termek;
    }

    public string Nev
    {
        get => nev;
        set => nev = value ?? throw new ArgumentNullException(nameof(value));
    }

    // public int EpuletMerete
    // {
    //     get => epuletMerete;
    //     set => epuletMerete = value;
    // }

    public int AlkalmazottakSzama
    {
        get => alkalmazottakSzama;
        set => alkalmazottakSzama = value;
    }
}