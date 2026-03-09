public class ContattiController
{
    private List<Contatto> contatti;
    private LastIdController lastIdController;

    public ContattiController() //questo serve per inizializzare la contatti e il lastIdController leggendo i dati dai file JSON tramite il JSONHelper
    {
        lastIdController = new LastIdController();
        contatti = new List<Contatto>();
        contatti = JSONHelper.LeggiContatti() ?? new List<Contatto>();
    }

    public void AggiungiContatto(string nome, string numero, bool presente, List<string> Interessi) //questo serve per aggiungere un nuovo contatto alla contatti, incrementando il lastIdController e salvando i dati aggiornati nei file JSON tramite il JSONHelper. Cosi via dicendo per le altre funzioni di eliminazione, modifica e stampa della contatti
    {
        Contatto nuovoContatto = new Contatto { Id = ++lastIdController, Nome = nome, Numero = numero, Interessi = interessi };
        contatti.Add(nuovoContatto);
        JSONHelper.ScriviContatti(contatti);
    }

    public void EliminaContatto(int id)
    {
        Contatto contattoDaEliminare = contatti.FirstOrDefault(c => c.Id == id);
        if (contattoDaEliminare != null)
        {
            contatti.Remove(contattoDaEliminare);
            JSONHelper.ScriviContatti(contatti);
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto con ID '{id}' non trovato.");
        }
    }

    public void ModificaContatto(int id, string nome, string numero, bool presente, List<string> interessi )
    {
        Contatto contattoDaModificare = contatti.FirstOrDefault(c => c.Id == id); //
        if (contattoDaModificare != null)
        {
            contattoDaModificare.Nome = nome;
            contattoDaModificare.Numero = numero;
            contattoDaModificare.Presente = presente;
            contattoDaModificare.Interessi = interessi;
            JSONHelper.ScriviContatti(contatti); //il mio Salva
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto con ID '{id}' non trovato.");
        }
    }

    public void ModificaInteresse(int id, List<string> interessi)
    {
        Contatto contattoDaModificare = contatti.FirstOrDefault(c => c.Id == id);
        if (contattoDaModificare != null)
        {
            contattoDaModificare.Interessi = interessi;
            JSONHelper.ScriviContatti(contatti); //il mio Salva
        }
    }
    public void StampaRubrica()
    {
        Console.WriteLine("Rubrica attuale:");
        foreach (var contatto in contatti)
        {
            Console.WriteLine($"ID: {contatto.Id}, Nome: {contatto.Nome}, Numero: {contatto.Numero}");
        }
    }
}