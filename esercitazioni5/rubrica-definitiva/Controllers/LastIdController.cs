public class LastIdController //questo serve per gestire la logica di business relativa al lastId, permettendo di ottenere il prossimo ID disponibile e di salvare l'ultimo ID utilizzato nei file JSON tramite il JSONHelper
{
    private int lastId;


    public int GetNextId()
    {
        return lastId++;
    }
}

