using Varos.Epulet.Interfaces;

namespace Varos.Epulet.GazdasagiEpuletek;

internal class Etterem : Epulet, IMunkahely
{
    private string nev; 
    private string tipus; // gyorsetterem.. , kesobb orokolt osztaly ehelyett, ha szukseges
    private double ar; // mennyi egy fore egy etkezes, egyszeruseg kedveert ez legyen fix szerintem
    private int alkalmazottakSzama;

    public Etterem(int epuletMerete, int karbantartottsag, int rezsi, string nev, string tipus, double ar, int alkalmazottakSzama) : base(epuletMerete, karbantartottsag, rezsi)
    {
        this.nev = nev;
        this.tipus = tipus;
        this.ar = ar;
        this.alkalmazottakSzama = alkalmazottakSzama;
    }

    public string Nev
    {
        get => nev;
        set => nev = value ?? throw new ArgumentNullException(nameof(value));
    }
    

    public string Tipus
    {
        get => tipus;
        set => tipus = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Ar
    {
        get => ar;
        set => ar = value;
    }

    public int AlkalmazottakSzama
    {
        get => alkalmazottakSzama;
        set => alkalmazottakSzama = value;
    }

    // TODO: fuggveny arra, hogy ha eszik itt az ember akkor a penzebol levonja az arat

}