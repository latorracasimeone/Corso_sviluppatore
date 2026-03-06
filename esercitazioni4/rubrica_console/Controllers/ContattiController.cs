public class ContattiController
{
    private readonly string path = "contatti.json";
    private List<Contatto> contatti;
    private LastIdController lastIdController;

    public ContattiController()
    {
        lastIdController = new LastIdController();
        contatti = JsonHelper.Leggi<List<Contatto>>(path) ?? new List<Contatto>();
            
    }

    public List<Contatto> GetContatti()
    {
        return contatti;
    }

    private void Salva()
    {
        JsonHelper.Salva(path, contatti);
    }

    public void AggiungiContatto (int id, string nome, string cognome, string email, string telefono, bool presente, List<string> interessi )
    {
        Contatto nuovoContatto = new Contatto
        {
            Id = lastIdController.GetNextId(),
            Nome = nome,
            Cognome = cognome,
            Email = email,
            Telefono = telefono,
            Presente = presente,
            Interessi = interessi

        };
        contatti.Add(nuovoContatto);
        Salva();
    }

    public void ModificaContatto (int id, string nome, string cognome, string email, string telefono, bool presente, List<string> interessi )
    {
        Contatto contattoEsistente = null;
        foreach (var contatto in contatti)
        {
            if (contatto.Id == id)
            {
                contattoEsistente = contatto;
                break;
            }
        }
        if (contattoEsistente != null)
        {
            contattoEsistente.Nome = nome;
            contattoEsistente.Cognome = cognome;
            contattoEsistente.Email = email;
            contattoEsistente.Telefono = telefono;
            contattoEsistente.Presente = presente;
            contattoEsistente.Interessi = interessi;
            Salva();
        }
    }

    public void EliminaContatto(int id)
    {
        Contatto contattoEsistente = null;
        foreach (var contatto in contatti)
        {
            if (contatto.Id == id)
            {
                contattoEsistente = contatto;
                break;
            }
        }
        if (contattoEsistente != null)
        {
            contatti.Remove(contattoEsistente);
            Salva();
        }
    }

    public Contatto VisualizzaContatto (int id) //questa non è void perché è una classe/funzione che deve restituire un valore da riutilizzare, per esempio per stamparlo
    {
        Contatto? contattoEsistente = null;
        foreach (var contatto in contatti)
        {
            if (contatto.Id == id)
            {
                contattoEsistente = contatto;
                break;
            }
        }
        if ( contattoEsistente == null)
        {
            throw new Exception($"Contatto con ID {id} non trovato!");
        }
        return contattoEsistente;

    }
}