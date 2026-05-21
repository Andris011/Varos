using System.Text;
using Varos.esemenyek.foldrenges;
using Varos.Szimulacio;

namespace Varos;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SzimulacioMotor.Futtatas();

        Console.WriteLine("Város szimulátor");
        Console.WriteLine("Enter hogy tovább menj");

        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("--- Fő menü ---");
        Console.WriteLine("1. Lorem Ipsum");
        Console.WriteLine("2. Dolor Sit Amet");
        Console.WriteLine("3. Consectetur Adipiscing");

        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Igazán ki lehetett volna jelölni egy vezetőt a projektnek");
        Console.WriteLine("Enter hogy kilépj");
        Console.ReadLine();


    }
}