using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek;

public class IrodaBerlemeny : Epulet, IAlberlet, IMunkahely
{
    private string nev;
    private double berletiDij;
    private int maxAlkalmazottakSzama;

    public IrodaBerlemeny(int epuletMerete, int karbantartottsag, int rezsi, string nev, double berletiDij, int maxAlkalmazottakSzama) : base(epuletMerete, karbantartottsag, rezsi)
    {
        this.nev = nev;
        this.berletiDij = berletiDij;
        this.maxAlkalmazottakSzama = maxAlkalmazottakSzama;
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

    public int MaxAlkalmazottakSzama
    {
        get => maxAlkalmazottakSzama;
        set => maxAlkalmazottakSzama = value;
    }

    public void BerletiDijKifizetese()
    {
        // ha kesz az ember
    }
}