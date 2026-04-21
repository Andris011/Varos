namespace Varos.Rendszerek.LakossagRendszer;

internal sealed class Lakos
{
    public int Age { get; set; }
    public string EducationLevel { get; set; } = "Alap";
    public string? Workplace { get; set; }
    public double Happiness { get; set; } = 70;
    public int Salary { get; set; }
    public double TaxRate { get; set; } = 0.18;

    public int PayTax()
    {
        return (int)(Salary * TaxRate);
    }

    public bool WantsToMoveOut()
    {
        return Happiness < 25;
    }
}
