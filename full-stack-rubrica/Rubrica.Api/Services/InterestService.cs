using Rubrica.Api.Data;
using Rubrica.Api.Dtos;
using Rubrica.Api.Models;
///////////////////CHIEDI ANCHE DI VERIFICARE NON SOLO I COMMENTI MA ANCHE SE IL CODICE FOSSE INCOMPLETO, NEL CASO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
namespace Rubrica.Api.Services;

/// <summary>
/// Questo Service gestisce la "Logica di Business" per gli Interessi.
/// Si occupa delle operazioni CRUD (Create, Read, Update, Delete) assicurandosi 
/// che ogni utente possa vedere o modificare solo i propri dati.
/// </summary>
public class InterestService
{
    // Il Context è il nostro ponte verso il Database.
    // Viene iniettato nel costruttore per permetterci di interrogare le tabelle.
    private readonly ApplicationDbContext _context;/*ApplicationDbContext è il "ponte" verso il
    database. È l'oggetto più importante quando si parla di dati in ASP.NET Core.*/

    public InterestService(ApplicationDbContext context)
    {
        _context = context; //riceve l'istanza dal campo privato di DbContext
    }

    /// Recupera tutti gli interessi associati a uno specifico utente
    public async Task<List<InterestDto>> GetAllByUserIdAsync(string userId)
    {
        List<InterestDto> result = new List<InterestDto>();

        // 1. Recupero dati: Carichiamo la lista degli interessi dalla tabella "Interests".
        // .ToList() esegue la query (richiesta) e porta i dati dal DB alla memoria del server.
        List<Interest> allInterests = _context.Interests.ToList();

        // 2. Filtro di sicurezza: Cicliamo tutti gli interessi e prendiamo solo quelli
        // il cui UserId corrisponde a quello dell'utente loggato.
        for (int i = 0; i < allInterests.Count; i++)
        {
            Interest currentInterest = allInterests[i];

            if (currentInterest.UserId == userId)
            {
                // Mapping: trasformiamo il Modello (DB) in DTO (Risposta per il client).
                // --- PUNTO DI TRASFORMAZIONE (MAPPING) ---
                // Qui 'currentInterest' è un oggetto di tipo 'Interest' (Modello DB)
                // Creiamo un nuovo oggetto 'InterestDto' (Oggetto di scambio)
                InterestDto dto = new InterestDto();
                // Copiamo i valori uno per uno dal Modello al DTO
                dto.Id = currentInterest.Id;
                dto.Nome = currentInterest.Nome;

                // Ora il DTO è pronto per essere aggiunto alla lista dei risultati (?)
                result.Add(dto);
            }
        }

        // Restituiamo il risultato come Task (operazione asincrona).
        return await Task.FromResult(result);
    }

    /// Recupera un singolo interesse tramite il suo ID, verificandone la proprietà. (ricevendo id e userId dell'Interesse)
    public async Task<InterestDto?> GetByIdAsync(int id, string userId)
    {
        // Cerchiamo l'interesse nel DB tramite la Chiave Primaria (ID) con FindAsync.
        Interest? interest = await _context.Interests.FindAsync(id);

        // Se non esiste, restituiamo null (il Controller risponderà con un 404 Not Found).
        if (interest == null)
        {
            return null;
        }

        // Controllo di Proprietà: Impediamo che un utente veda gli interessi di un altro
        // semplicemente indovinando l'ID nell'URL.
        if (interest.UserId != userId)
        {
            return null; // Trattiamo l'accesso non autorizzato come "non trovato" per sicurezza.
        }

        /* --- PUNTO DI TRASFORMAZIONE (MAPPING) ---
        Qui 'currentInterest' è un oggetto di tipo 'Interest' (Modello DB) 
        Creiamo un nuovo oggetto 'InterestDto' (Oggetto di scambio)*/
        InterestDto dto = new InterestDto();//vado ad estrapolare solo i dati da rendere pubblici ed esporre al client
        // Copiamo i valori uno per uno dal Modello al DTO
        dto.Id = interest.Id;
        dto.Nome = interest.Nome;

        return dto;
    }

    /// Crea un nuovo interesse per l'utente loggato.
    public async Task<InterestDto?> CreateAsync(InterestCreateDto dto, string userId)
    {
        // 1. Validazione: Controlliamo se l'utente ha già un interesse con lo stesso nome.
        List<Interest> allInterests = _context.Interests.ToList();
        for (int i = 0; i < allInterests.Count; i++)
        {
            Interest currentInterest = allInterests[i];
            if (currentInterest.UserId == userId && currentInterest.Nome == dto.Nome)
            {
                return null; // Evitiamo duplicati per lo stesso utente.
            }
        }

        // 2. Creazione: Prepariamo l'oggetto Modello da salvare.
        Interest interest = new Interest();
        interest.Nome = dto.Nome;
        interest.UserId = userId; // Colleghiamo l'interesse all'utente attuale.

        // 3. Persistenza: Add lo aggiunge in memoria, SaveChangesAsync scrive effettivamente nel DB.
        _context.Interests.Add(interest);
        await _context.SaveChangesAsync();

        // 4. Risposta: Restituiamo il DTO completo (compreso l'ID appena generato dal DB).
        InterestDto result = new InterestDto();//vado ad estrapolare solo i dati da rendere pubblici ed esporre al client
        result.Id = interest.Id;
        result.Nome = interest.Nome;

        return result;
    }

    /// Aggiorna il nome di un interesse esistente. (Ricevendo i dati fra parentesi tonde!)
    public async Task<InterestDto?> UpdateAsync(int id, InterestCreateDto dto, string userId)
    {
        // Cerchiamo l'interesse originale.
        Interest? interest = await _context.Interests.FindAsync(id);

        // Verifichiamo esistenza e proprietà (non si può modificare ciò che non ci appartiene).
        if (interest == null || interest.UserId != userId)
        {
            return null;
        }

        // Aggiorniamo solo i campi necessari.
        interest.Nome = dto.Nome;

        // EF Core tiene traccia delle modifiche: basta salvare per aggiornare il DB.
        //codice incompleto?????
        await _context.SaveChangesAsync();

        InterestDto result = new InterestDto();//vado ad estrapolare solo i dati da rendere pubblici ed esporre al client
        result.Id = interest.Id;
        result.Nome = interest.Nome;

        return result;
    }

    /// Elimina definitivamente un interesse dal database.
    public async Task<bool> DeleteAsync(int id, string userId)
    {
        Interest? interest = await _context.Interests.FindAsync(id);

        if (interest == null || interest.UserId != userId)
        {
            return false;
        }

        // Rimuoviamo l'entità dal set degli Interessi.
        _context.Interests.Remove(interest);
        await _context.SaveChangesAsync();

        return true; // Operazione riuscita.
    }
}