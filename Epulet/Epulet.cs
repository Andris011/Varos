namespace Varos.Epulet;

public class Epulet
{
    private int epuletMerete; // m2
    //TODO Allapot romlas, karban tartas, felujitas, fogyastas

    
    public Epulet(int epuletMerete)
    {
        this.epuletMerete = epuletMerete;
    }

    public int EpuletMerete
    {
        get => epuletMerete;
        set => epuletMerete = value;
    }
    
    // gazdasag: 
}