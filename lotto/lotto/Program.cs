namespace lotto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loto l =new Loto(new Dictionary<TesztEmber, int>());
            TesztEmber e=new TesztEmber("Nagy Laci",100000000);
            l.TarKiir();
            Console.WriteLine(e);
            l.SzelvenytVesz(e, 2);
            Console.WriteLine(e);
            l.TarKiir(); 
            l.Roll();
            l.TarKiir();
        }
    }
}
