namespace lotto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loto l =new Loto(new Dictionary<TesztEmber, int>());
            TesztEmber e=new TesztEmber("Nagy Laci",10000);
            l.TarKiir();
            Console.WriteLine(e);
            l.SzelvenytVesz(e, 1);
            Console.WriteLine(e);
            l.TarKiir();

            

        }
    }
}
