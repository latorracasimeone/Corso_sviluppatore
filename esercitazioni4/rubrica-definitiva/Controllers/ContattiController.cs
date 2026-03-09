using System.ComponentModel.DataAnnotations;
public class ContattiController
{
    private List<Contatto> contatti;
    private LastIdController lastIdController;

    private void ValidaContatto(Contatto contatto)
    {
        var context = new ValidationContext(contatto);
        // Questo metodo controlla tutti i decorator e lancia un'eccezione se falliscono
        Validator.ValidateObject(contatto, context, validateAllProperties: true);
    }


    public ContattiController() //questo serve per inizializzare la contatti e il lastIdController leggendo i dati dai file JSON tramite il JSONHelper
    {
        lastIdController = new LastIdController();
        contatti = new List<Contatto>();
        contatti = JSONHelper.LeggiContatti() ?? new List<Contatto>(); //questo serve per leggere i dati dei contatti dal file JSON tramite il JSONHelper, e se il file non esiste o è vuoto, inizializzare la contatti come una lista vuota. Cosi via dicendo per la lettura del lastId.
    }

    public void AggiungiContatto(string nome, string numero, bool presente, List<string> interessi) //questo serve per aggiungere un nuovo contatto alla contatti, incrementando il lastIdController e salvando i dati aggiornati nei file JSON tramite il JSONHelper. Cosi via dicendo per le altre funzioni di eliminazione, modifica e stampa della contatti
    {
        try
        {
            Contatto nuovoContatto = new Contatto
            {
                Id = lastIdController.GetNextId(),
                Nome = nome,
                Numero = numero,
                Presente = presente,
                Interessi = interessi
            };

            // CHIAMATA ALLA VALIDAZIONE
            ValidaContatto(nuovoContatto);

            Contatto nuovoContatt = new Contatto { Id = lastIdController.GetNextId(), Nome = nome, Numero = numero, Presente = presente, Interessi = interessi };
            contatti.Add(nuovoContatt);
            JSONHelper.ScriviContatti(contatti);
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"ERRORE: {ex.Message}");
        }
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

    public void ModificaContatto(int id, string nome, string numero, bool presente, List<string> interessi)
    {
        Contatto contattoDaModificare = contatti.FirstOrDefault(c => c.Id == id); //questo serve per trovare il contatto da modificare nella contatti in base all'ID fornito, e se trovato, aggiornare i suoi dati con i nuovi valori forniti e salvare i dati aggiornati nei file JSON tramite il JSONHelper. Se il contatto non viene trovato, viene stampato un messaggio di errore. Cosi via dicendo per la modifica degli interessi del contatto.
        if (contattoDaModificare != null)
        {
            try
            {
                Contatto testValidazione = new Contatto { Nome = nome, Numero = numero, Interessi = interessi };
                ValidaContatto(testValidazione);
                contattoDaModificare.Nome = nome;
                contattoDaModificare.Numero = numero;
                contattoDaModificare.Presente = presente;
                contattoDaModificare.Interessi = interessi;
                JSONHelper.ScriviContatti(contatti); //il mio Salva
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"ERRORE: {ex.Message}");
            }
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
            Console.WriteLine($"ID: {contatto.Id}, Nome: {contatto.Nome}, Numero: {contatto.Numero}, Presenza: {contatto.Presente}, Interessi: {string.Join(", ", contatto.Interessi)}");
        }
    }
}