using Varos.Rendszerek.GazdasagiRendszer;

namespace Varos.Rendszerek.SzimulaciosMotor;

internal sealed class SzimulaciosMotor
{
    public int CurrentTick { get; private set; }
    public Koltsegvetes Budget { get; } = new();

    public int LastTickIncome { get; private set; }
    public int LastTickExpense { get; private set; }

    public void StartTick()
    {
        LastTickIncome = 0;
        LastTickExpense = 0;
    }

    public void RegisterIncome(int amount)
    {
        LastTickIncome += amount;
        Budget.AddIncome(amount);
    }

    public void RegisterExpense(int amount)
    {
        LastTickExpense += amount;
        Budget.AddExpense(amount);
    }

    public void SimulateTick()
    {
        CurrentTick++;
    }
}
