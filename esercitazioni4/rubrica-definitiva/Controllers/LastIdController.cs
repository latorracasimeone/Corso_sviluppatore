public class LastIdController //questo serve per gestire la logica di business relativa al lastId, permettendo di ottenere il prossimo ID disponibile e di salvare l'ultimo ID utilizzato nei file JSON tramite il JSONHelper
{
    private int lastId;

    public LastIdController() //questo serve per inizializzare il lastId leggendo il dato dal file JSON tramite il JSONHelper
    {
        lastId = JSONHelper.LeggiLastId();
    }

    public int GetNextId()
    {
        return lastId++;
    }

    public void SaveLastId() //questo serve per salvare l'ultimo ID utilizzato nel file JSON tramite il JSONHelper
    {
        JSONHelper.ScriviLastId(lastId);
    }
}