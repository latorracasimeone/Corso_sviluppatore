using Newtonsoft.Json;

//leggo il file
string lastidjson = File.ReadAllText(@"lastId.json");

//deserializzo
var shrek = JsonConvert.DeserializeObject<dynamic>(lastidjson);
//prendo il valore di lastid
int lastid = shrek.lastid; //l'ultimo è il nome del file

Console.Write("Inserisca il Nome: ");
string nome = Console.ReadLine();
Console.Write("Inserisca l'età: ");
int eta = int.Parse(Console.ReadLine());
Console.Write("Presenza (true/false): ");
string presente = Console.ReadLine();
bool presenza = bool.Parse(presente);

var partecipante = new
{ //es: '"nome": nome,' nel .json, quando lo crei è '"nome" = nome,'
    "id" = lastid +1,
    "nome" = $"{nome}",
    "eta" = $"{eta}",
    "presente" = $"{presenza}"
};

//aggiorno
shrek.lastId = lastid +1;

//serializzo
string update = JsonConvert.SerializeObject(partecipante, Formatting.Indented);

// scrivo la stringa json aggiornata su file
File.WriteAllText(@"partecipante.json", update);

// serializzo l'oggetto aggiornato in una stringa json
string updatedLastIdJson = JsonConvert.SerializeObject(shrek, Formatting.Indented);

// scrivo la stringa json aggiornata su file
File.WriteAllText(@"lastId.json", updatedLastIdJson);