using Varos.Epulet.Interfaces;

namespace Varos.Epulet.Iskola;

public class Iskola : Epulet, IMunkahely
{
    private string nev;
    private int alkalmazottakSzama;
    private int tanulokSzama;

    public Iskola(int epuletMerete, int karbantartottsag, int rezsi, string nev, int alkalmazottakSzama, int tanulokSzama) : base(epuletMerete, karbantartottsag, rezsi)
    {
        this.nev = nev;
        this.alkalmazottakSzama = alkalmazottakSzama;
        this.tanulokSzama = tanulokSzama;
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

    public int TanulokSzama
    {
        get => tanulokSzama;
        set => tanulokSzama = value;
    }
}