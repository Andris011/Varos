namespace Varos.Rendszerek.EsemenyKezeles;

internal sealed class Esemeny
{
    public string Name { get; }
    public int DurationInTicks { get; }

    public Esemeny(string name, int durationInTicks)
    {
        Name = name;
        DurationInTicks = durationInTicks;
    }
}

internal sealed class Esemenykezelo
{
    private readonly List<Esemeny> _activeEvents = new();

    public IReadOnlyCollection<Esemeny> ActiveEvents => _activeEvents;

    public void Add(Esemeny cityEvent)
    {
        _activeEvents.Add(cityEvent);
    }
}
