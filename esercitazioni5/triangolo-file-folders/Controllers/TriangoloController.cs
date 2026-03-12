//qui abbiamo il controller per il triangolo
public class TriangoloController
{
    Triangolo triangolo = new Triangolo { Altezza = 3, Base = 2};
    public int Area()
    {
        return triangolo.Altezza * triangolo.Base; //triangolo minuscolo per il nome che abbiamo appena dato e .Altezza per il valore int da utilizzare nel calcolo
    }
}