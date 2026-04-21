namespace Varos.Rendszerek.GazdasagiRendszer;

internal enum ResourceType
{
    Money,
    Energy,
    Food,
    RawMaterial,
    Education,
    HealthCapacity
}

internal sealed class Koltsegvetes
{
    public int Income { get; private set; }
    public int Expense { get; private set; }
    public double TaxRate { get; private set; } = 0.18;

    public int Balance => Income - Expense;

    public void SetTaxRate(double taxRate)
    {
        TaxRate = Math.Clamp(taxRate, 0, 0.5);
    }

    public void AddIncome(int amount) => Income += amount;
    public void AddExpense(int amount) => Expense += amount;
}
