using Newtonsoft.Json; // importazione della libreria Newtonsoft.Json

string json = File.ReadAllText(@"lastId.json"); // leggo il contenuto del file json
var partecipante = JsonConvert.DeserializeObject<dynamic>(json); // deserializzazione tramite JsonConvert

// una volta deserializzato, posso accedere ai campi dell'oggetto in modo oggetto.chiave e il tipo di dato è dinamico
Console.WriteLine($"Stampa: {partecipante.lastId}");

int lastId = partecipante.lastId;//prendo il valore di lastId

var nuovoPartecipante = new
{
    id = lastId +1,
    nome = $"Napoletano {lastId + 1}"
};

//serializzo il nuovo partecipante in una stringa json
///Formatting.Indented ti stampa in ordine sequenziale andando a capo
string nuovoPartecipanteJson = JsonConvert.SerializeObject(nuovoPartecipante, Formatting.Indented);

// scrivo il nuovo partecipante su un file json
File.WriteAllText(@"partecipante.json", nuovoPartecipanteJson);

//aggiorno il valore di LastId
partecipante.lastId = lastId +1;

//
string update = JsonConvert.SerializeObject(partecipante, Formatting.Indented);

//scrivo la stringa json aggiornata su file
File.WriteAllText(@"lastId.json", update);