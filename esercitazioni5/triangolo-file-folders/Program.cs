//qui abbiamo il main
class Program
{
    static void Main(string[] args)//questo è il modo FISSO di creare il Main.
    {
        TriangoloController tc = new TriangoloController();
        Console.WriteLine($"L'area del triangolo in questione è {tc.Area()}");
    }
}