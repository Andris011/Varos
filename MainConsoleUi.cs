using Varos.Rendszerek.EpuletRendszer;
using Varos.Rendszerek.EsemenyKezeles;
using Varos.Rendszerek.GazdasagiRendszer;
using Varos.Rendszerek.LakossagRendszer;
using Varos.Rendszerek.SzimulaciosMotor;

namespace Varos;

internal sealed class MainConsoleUi
{
    private readonly SimulationState _state = new();
    private readonly Random _random = new();
    private readonly SzimulaciosMotor _engine = new();
    private readonly Esemenykezelo _eventManager = new();
    private readonly List<Epulet> _buildings = new();
    private readonly List<Lakos> _citizens = new();

    public MainConsoleUi()
    {
        SyncCitizensWithPopulation();
        _engine.Budget.SetTaxRate(_state.TaxRate);
    }

    public void Run()
    {
        var running = true;

        while (running)
        {
            DrawHeader();
            DrawDashboard();
            DrawMenu();

            Console.Write("Válassz menüpontot: ");
            var input = Console.ReadLine()?.Trim();

            switch (input)
            {
                case "1":
                    NextTick();
                    break;
                case "2":
                    BuildMenu();
                    break;
                case "3":
                    TaxMenu();
                    break;
                case "4":
                    PolicyMenu();
                    break;
                case "5":
                    CitizenActions();
                    break;
                case "6":
                    ShowEventLog();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    AddEvent("Érvénytelen menüpont.");
                    break;
            }
        }

        Console.WriteLine("Kilépés...");
    }

    private void DrawHeader()
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("      Városszimuláció - Alap prototipus    ");
        Console.WriteLine("============================================");
    }

    private void DrawDashboard()
    {
        Console.WriteLine($"Tick: {_engine.CurrentTick}");
        Console.WriteLine($"Lakosság: {_state.Population}");
        Console.WriteLine($"Átlag boldogság: {_state.AverageHappiness:0.0}%");
        Console.WriteLine($"Munkanélküliség: {_state.Unemployment:0.0}%");
        Console.WriteLine();

        Console.WriteLine("--- Erőforrások ---");
        Console.WriteLine($"Pénz: {_state.Money}");
        Console.WriteLine($"Energia: {_state.Energy}");
        Console.WriteLine($"Élelmiszer: {_state.Food}");
        Console.WriteLine($"Nyersanyag: {_state.RawMaterial}");
        Console.WriteLine($"Oktatás: {_state.EducationCapacity}");
        Console.WriteLine($"Egészségügy: {_state.HealthCapacity}");
        Console.WriteLine();

        Console.WriteLine("--- Gazdaság ---");
        Console.WriteLine($"Adókulcs: {_state.TaxRate:P0}");
        Console.WriteLine($"Aktív politika: {_state.ActivePolicy}");
        Console.WriteLine($"Költségvetési egyenleg: {_engine.Budget.Balance}");
        Console.WriteLine($"Aktív események: {_eventManager.ActiveEvents.Count}");
        Console.WriteLine();
    }

    private static void DrawMenu()
    {
        Console.WriteLine("1) Következő tick");
        Console.WriteLine("2) Építkezés");
        Console.WriteLine("3) Adókulcs módosítása");
        Console.WriteLine("4) Politika váltása");
        Console.WriteLine("5) Lakossági műveletek");
        Console.WriteLine("6) Eseménynapló");
        Console.WriteLine("0) Kilépés");
        Console.WriteLine();
    }

    private void NextTick()
    {
        _engine.SimulateTick();

        var taxIncome = _citizens.Sum(c => c.PayTax());
        var upkeep = _buildings.Sum(b => b.MaintenanceCost);

        _state.Money += taxIncome - upkeep;
        _engine.Budget.AddIncome(taxIncome);
        _engine.Budget.AddExpense(upkeep);

        var powerPlantCount = _buildings.Count(b => b is Eleromu);
        var industrialCount = _buildings.Count(b => b is IpariEpulet);
        var schoolCapacity = _buildings.Where(b => b is Iskola).Sum(b => b.CalculateEffect());
        var hospitalCapacity = _buildings.Where(b => b is Korhaz).Sum(b => b.CalculateEffect());

        _state.Energy += powerPlantCount * 35 - _state.Population / 12;
        _state.Food += industrialCount * 10 - _state.Population / 10;
        _state.RawMaterial += industrialCount * 8;
        _state.EducationCapacity = schoolCapacity;
        _state.HealthCapacity = hospitalCapacity;

        if (_state.Energy < 0)
        {
            _state.AverageHappiness -= 3;
            AddEvent("Áramszünet: az energia hiány miatt csökkent a boldogság.");
        }

        if (_state.Food < 0)
        {
            _state.AverageHappiness -= 4;
            _state.Population = Math.Max(0, _state.Population - 5);
            SyncCitizensWithPopulation();
            AddEvent("Élelmiszer hiány: lakosságcsökkenés történt.");
        }

        if (_random.Next(1, 101) <= 12)
        {
            TriggerRandomEvent();
        }

        _state.AverageHappiness = Math.Clamp(_state.AverageHappiness, 0, 100);
        _state.Unemployment = Math.Clamp(_state.Unemployment, 0, 100);

        Pause("Következő Tick");
    }

    private void BuildMenu()
    {
        Console.WriteLine("\nÉpülettípusok:");
        Console.WriteLine("1) 10 emeletes betontömb (költség: 1200)");
        Console.WriteLine("2) Akumulátor gyár (költség: 1800)");
        Console.WriteLine("3) Sarki kisbolt (költség: 1500)");
        Console.WriteLine("4) MiniPaks (költség: 2400)");
        Console.WriteLine("5) Oskola (költség: 2000)");
        Console.WriteLine("6) Békéscsaba mentőállomás (költség: 2600)");
        Console.Write("Válassz: ");

        var selected = Console.ReadLine()?.Trim();
        switch (selected)
        {
            case "1": Build(new Lakoepulet()); break;
            case "2": Build(new IpariEpulet()); break;
            case "3": Build(new KereskedelmiEpulet()); break;
            case "4": Build(new Eleromu()); break;
            case "5": Build(new Iskola()); break;
            case "6": Build(new Korhaz()); break;
            default:
                AddEvent("Nincs ilyen épülettípus.");
                break;
        }

        Pause();
    }

    private void Build(Epulet building)
    {
        if (_state.Money < building.BuildCost)
        {
            AddEvent($"Nincs elég pénz a(z) {building.Name} építéséhez.");
            return;
        }

        _state.Money -= building.BuildCost;
        _buildings.Add(building);
        AddEvent($"Sikeres építés: {building.Name}.");
    }

    private void TaxMenu()
    {
        Console.Write("Új adókulcs (0-50%): ");
        var input = Console.ReadLine();

        if (double.TryParse(input, out var percent))
        {
            percent = Math.Clamp(percent, 0, 50);
            _state.TaxRate = percent / 100.0;
            _engine.Budget.SetTaxRate(_state.TaxRate);

            foreach (var citizen in _citizens)
            {
                citizen.TaxRate = _state.TaxRate;
            }

            AddEvent($"Adókulcs beállítva: {percent:0}%");

            if (percent > 35)
            {
                _state.AverageHappiness -= 2;
                _state.Unemployment += 1;
            }
        }
        else
        {
            AddEvent("Hibás adókulcs érték.");
        }

        Pause();
    }

    private void PolicyMenu()
    {
        Console.WriteLine("\nPolicy opciók:");
        Console.WriteLine("1) Alacsony adó");
        Console.WriteLine("2) Magas adó");
        Console.WriteLine("3) Zöld politika");
        Console.WriteLine("4) Iparorientált politika");
        Console.Write("Válassz: ");

        var option = Console.ReadLine()?.Trim();
        switch (option)
        {
            case "1":
                _state.ActivePolicy = "Alacsony adó";
                _state.TaxRate = 0.12;
                _state.AverageHappiness += 3;
                break;
            case "2":
                _state.ActivePolicy = "Magas adó";
                _state.TaxRate = 0.30;
                _state.AverageHappiness -= 3;
                break;
            case "3":
                _state.ActivePolicy = "Zöld politika";
                _state.Energy += 20;
                _state.AverageHappiness += 2;
                break;
            case "4":
                _state.ActivePolicy = "Iparorientált politika";
                _state.RawMaterial += 40;
                _state.Unemployment -= 2;
                break;
            default:
                AddEvent("Nincs ilyen politika.");
                Pause();
                return;
        }

        _engine.Budget.SetTaxRate(_state.TaxRate);

        foreach (var citizen in _citizens)
        {
            citizen.TaxRate = _state.TaxRate;
        }

        AddEvent($"Aktív politika: {_state.ActivePolicy}");
        Pause();
    }

    private void CitizenActions()
    {
        Console.WriteLine("\nLakossági műveletek:");
        Console.WriteLine("1) Bevándorlási hullám (+30 fő)");
        Console.WriteLine("2) Elköltözési hullám (-20 fő)");
        Console.Write("Válassz: ");

        var selected = Console.ReadLine()?.Trim();
        switch (selected)
        {
            case "1":
                _state.Population += 30;
                _state.Unemployment += 1.5;
                SyncCitizensWithPopulation();
                AddEvent("Bevándorlási hullám: +30 lakos.");
                break;
            case "2":
                _state.Population = Math.Max(0, _state.Population - 20);
                _state.Unemployment = Math.Max(0, _state.Unemployment - 1.0);
                SyncCitizensWithPopulation();
                AddEvent("Elköltözési hullám: -20 lakos.");
                break;
            default:
                AddEvent("Nincs ilyen lakossági művelet.");
                break;
        }

        Pause();
    }

    private void TriggerRandomEvent()
    {
        var eventId = _random.Next(1, 6);

        switch (eventId)
        {
            case 1:
                _state.Energy -= 25;
                _state.AverageHappiness -= 2;
                _eventManager.Add(new Esemeny("Áramszünet", 1));
                AddEvent("Random event: Áramszünet");
                break;
            case 2:
                _state.Money -= 1000;
                _state.Unemployment += 3;
                _eventManager.Add(new Esemeny("Gazdasági válság", 3));
                AddEvent("Random event: Gazdasági válság");
                break;
            case 3:
                _state.HealthCapacity -= 35;
                _state.AverageHappiness -= 2;
                _eventManager.Add(new Esemeny("Járvány", 2));
                AddEvent("Random event: Járvány");
                break;
            case 4:
                _state.Population += 25;
                _state.Unemployment += 1;
                SyncCitizensWithPopulation();
                _eventManager.Add(new Esemeny("Bevándorlási hullám", 1));
                AddEvent("Random event: Bevándorlási hullám");
                break;
            default:
                _state.RawMaterial += 20;
                _state.Energy += 15;
                _eventManager.Add(new Esemeny("Technológiai fejlődés", 2));
                AddEvent("Random event: Technológiai fejlődés");
                break;
        }
    }

    private void ShowEventLog()
    {
        Console.WriteLine("\n--- Eseménynapló ---");

        if (_state.EventLog.Count == 0)
        {
            Console.WriteLine("Nincs még esemény.");
        }
        else
        {
            foreach (var item in _state.EventLog.TakeLast(10))
            {
                Console.WriteLine(item);
            }
        }

        Pause();
    }

    private void AddEvent(string message)
    {
        _state.EventLog.Add($"[Tick {_engine.CurrentTick}] {message}");
    }

    private void SyncCitizensWithPopulation()
    {
        while (_citizens.Count < _state.Population)
        {
            _citizens.Add(new Lakos
            {
                Age = 30,
                Salary = 120,
                TaxRate = _state.TaxRate,
                Happiness = _state.AverageHappiness
            });
        }

        while (_citizens.Count > _state.Population)
        {
            _citizens.RemoveAt(_citizens.Count - 1);
        }
    }

    private static void Pause(string? text = null)
    {
        if (!string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine(text);
        }

        Console.WriteLine("Nyomj Entert a folytatáshoz...");
        Console.ReadLine();
    }

    private sealed class SimulationState
    {
        public int Population { get; set; } = 120;
        public double AverageHappiness { get; set; } = 72;
        public double Unemployment { get; set; } = 8;

        public int Money { get; set; } = 15000;
        public int Energy { get; set; } = 100;
        public int Food { get; set; } = 90;
        public int RawMaterial { get; set; } = 70;
        public int EducationCapacity { get; set; } = 50;
        public int HealthCapacity { get; set; } = 50;

        public double TaxRate { get; set; } = 0.18;
        public string ActivePolicy { get; set; } = "Kiegyensúlyozott";

        public List<string> EventLog { get; } = new();
    }
}
