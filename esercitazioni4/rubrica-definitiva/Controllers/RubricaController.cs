public class RubricaController
{
    private List<Contatto> rubrica;
    private int lastId;

    public RubricaController() //questo serve per inizializzare la rubrica e il lastId leggendo i dati dai file JSON tramite il JSONHelper
    {
        rubrica = JSONHelper.LeggiContatti();
        lastId = JSONHelper.LeggiLastId();
    }

    public void AggiungiContatto(string nome, string numero) //questo serve per aggiungere un nuovo contatto alla rubrica, incrementando il lastId e salvando i dati aggiornati nei file JSON tramite il JSONHelper. Cosi via dicendo per le altre funzioni di eliminazione, modifica e stampa della rubrica
    {
        Contatto nuovoContatto = new Contatto { Nome = nome, Numero = numero, Id = ++lastId };
        rubrica.Add(nuovoContatto);
        JSONHelper.ScriviContatti(rubrica);
        JSONHelper.ScriviLastId(lastId);
    }

    public void EliminaContatto(int id)
    {
        Contatto contattoDaEliminare = rubrica.FirstOrDefault(c => c.Id == id);
        if (contattoDaEliminare != null)
        {
            rubrica.Remove(contattoDaEliminare);
            JSONHelper.ScriviContatti(rubrica);
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto con ID '{id}' non trovato.");
        }
    }

    public void ModificaContatto(int id, string nuovoNome, string nuovoNumero)
    {
        Contatto contattoDaModificare = rubrica.FirstOrDefault(c => c.Id == id);
        if (contattoDaModificare != null)
        {
            contattoDaModificare.Nome = nuovoNome;
            contattoDaModificare.Numero = nuovoNumero;
            JSONHelper.ScriviContatti(rubrica);
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto con ID '{id}' non trovato.");
        }
    }

    public void StampaRubrica()
    {
        Console.WriteLine("Rubrica attuale:");
        foreach (var contatto in rubrica)
        {
            Console.WriteLine($"ID: {contatto.Id}, Nome: {contatto.Nome}, Numero: {contatto.Numero}");
        }
    }
}