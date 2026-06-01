namespace Varos.Epulet;

public abstract class Epulet
{
    private int epuletMerete; // m2
    private int karbantartottsag; // 0-10, 0 = lerombolodott
    private int rezsi; // a megadott penznemben kifejezve


    public Epulet(int epuletMerete, int karbantartottsag, int rezsi)
    {
        this.epuletMerete = epuletMerete;
        this.karbantartottsag = karbantartottsag;
        this.rezsi = rezsi;
    }

    public int EpuletMerete
    {
        get => epuletMerete;
        set => epuletMerete = value;
    }

    public int Karbantartottsag
    {
        get => karbantartottsag;
        set => karbantartottsag = value;
    }
    
    public int Rezsi
    {
        get => rezsi;
        set => rezsi = value;
    }

    public void Foldrenges()
    {
        int sebzes = new Random().Next(1, 11);
        
        this.karbantartottsag -= sebzes;
        
        if (this.karbantartottsag < 0) karbantartottsag = 0; 
    }
}