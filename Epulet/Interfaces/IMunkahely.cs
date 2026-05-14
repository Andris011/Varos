using Varos.gazdasag.Munkahely;

namespace Varos.Epulet.Interfaces;

public interface IMunkahely
{
    string Nev { get; set; } 
    int MaxAlkalmazottakSzama { get; set; }
    
}