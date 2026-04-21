namespace Varos.Rendszerek.EpuletRendszer;

internal abstract class Epulet
{
    public string Name { get; }
    public int BuildCost { get; }
    public int MaintenanceCost { get; }
    public int Capacity { get; }

    protected Epulet(string name, int buildCost, int maintenanceCost, int capacity)
    {
        Name = name;
        BuildCost = buildCost;
        MaintenanceCost = maintenanceCost;
        Capacity = capacity;
    }

    public abstract int CalculateEffect();
}

internal sealed class Lakoepulet : Epulet
{
    public Lakoepulet() : base("10 emeletes betontömb", 1200, 90, 25) { }
    public override int CalculateEffect() => Capacity;
}

internal sealed class IpariEpulet : Epulet
{
    public IpariEpulet() : base("Akumulátor gyár", 1800, 140, 15) { }
    public override int CalculateEffect() => 10;
}

internal sealed class KereskedelmiEpulet : Epulet
{
    public KereskedelmiEpulet() : base("Sarki kisbolt", 1500, 110, 20) { }
    public override int CalculateEffect() => 8;
}

internal sealed class Eleromu : Epulet
{
    public Eleromu() : base("MiniPaks", 2400, 180, 0) { }
    public override int CalculateEffect() => 35;
}

internal sealed class Iskola : Epulet
{
    public Iskola() : base("Oskola", 2000, 130, 100) { }
    public override int CalculateEffect() => Capacity;
}

internal sealed class Korhaz : Epulet
{
    public Korhaz() : base("Békéscsaba mentőállomás", 2600, 160, 90) { }
    public override int CalculateEffect() => Capacity;
}
