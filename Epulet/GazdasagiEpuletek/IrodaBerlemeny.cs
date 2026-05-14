using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek;

public class IrodaBerlemeny : Epulet, IAlberlet, IMunkahely
{
    private string nev;
    private double berletiDij;
    private int alkalmazottakSzama;

    public IrodaBerlemeny(int epuletMerete, string nev, double berletiDij, int alkalmazottakSzama) : base(epuletMerete)
    {
        this.nev = nev;
        this.berletiDij = berletiDij;
        this.alkalmazottakSzama = alkalmazottakSzama;
    }

    public string Nev
    {
        get => nev;
        set => nev = value ?? throw new ArgumentNullException(nameof(value));
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