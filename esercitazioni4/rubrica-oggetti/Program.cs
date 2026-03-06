

///creiamo una classe Main (in fondo)
/// sotto il programma main ci inseriamo tutte le classi (in questo caso una)
public class Triangolo
{
    public int Altezza { get; set; }//metodo automatico per rendere pubbliche determinate proprietà (in questo caso altezza e base)
    public int Base { get; set; }//ora sappiamo che il nostro triangolo ha una determinata altezza ed una determinata base
} 

public class TriangoloController
{
    Triangolo triangolo = new Triangolo { Altezza = 3, Base = 2};
    public int Area()
    {
        return triangolo.Altezza * triangolo.Base; //triangolo minuscolo per il nome che abbiamo appena dato e .Altezza per il valore int da utilizzare nel calcolo
    }
}

class Program
{
    static void Main(string[] args)//questo è il modo FISSO di creare il Main.
    {
        TriangoloController tc = new TriangoloController();
        Console.WriteLine($"L'area del triangolo in questione è {tc.Area()}");
    }
}