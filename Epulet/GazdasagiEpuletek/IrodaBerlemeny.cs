using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek;

public class IrodaBerlemeny : IEpulet, IAlberlet, IMunkahely
{
    private string nev;
    private int epuletMerete;
    private double berletiDij;
    private int alkalmazottakSzama;

    public IrodaBerlemeny(string nev, int epuletMerete, double berletiDij, int alkalmazottakSzama)
    {
        this.nev = nev;
        this.epuletMerete = epuletMerete;
        this.berletiDij = berletiDij;
        this.alkalmazottakSzama = alkalmazottakSzama;
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

    public double BerletiDij
    {
        get => berletiDij;
        set => berletiDij = value;
    }

    public int AlkalmazottakSzama
    {
        get => alkalmazottakSzama;
        set => alkalmazottakSzama = value;
    }

    public void BerletiDijKifizetese()
    {
        // ha kesz az ember
    }
}