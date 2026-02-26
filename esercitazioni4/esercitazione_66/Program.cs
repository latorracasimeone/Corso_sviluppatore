using Newtonsoft.Json;


string path = @"prova.json";
string json = File.ReadAllText(path);
var partecipante = JsonConvert.DeserializeObject<dynamic>(json);

Console.WriteLine($"Nome: {partecipante.nome}");
Console.WriteLine($"Età: {partecipante.eta}");
Console.WriteLine($"Presente: {partecipante.presente}");


// creo un oggetto partecipante
var partecipantePippo = new
{
    nome = "Pippo",
    eta = 1000,
    presente = false
};
// serializzo l'oggetto in una stringa json
// il secondo parametro serve per formattare la stringa json in modo leggibile
string jsonPippo = JsonConvert.SerializeObject(partecipantePippo, Formatting.Indented);
// scrivo la stringa json su un file
File.WriteAllText(@"provaPippo.json", jsonPippo);


//Deserializzazione di un file json complesso (con chiave int e valore lista di stringhe)
string jsonKratos = File.ReadAllText(@"test.json"); // leggo il contenuto del file json con un passaggio in meno
var kratos = JsonConvert.DeserializeObject<dynamic>(jsonKratos); // deserializzazione tramite JsonConvert

Console.WriteLine($"Nome: {kratos.nome}");
Console.WriteLine($"Età: {kratos.eta}");
Console.WriteLine($"Presente: {kratos.presente}");
Console.WriteLine("Interessi:");

foreach (var interesse in kratos.interessi)
{
    Console.WriteLine($"- {interesse}");
}

// oppure con il join
Console.WriteLine($"Interessi: {string.Join(", ", kratos.interessi)}");

// oppure posso accedere ad un elemento specfico della lista, ad esempio il secondo elemento
Console.WriteLine($"Secondo interesse: {kratos.interessi[1]}");



var tonino = new
{
    nome = "Cannavacciuolo",
    eta = 45,
    presente = true,
    interessi = new List<string> { "mangiare", "pattoni", "cucina", "napoli" }
};

string jsonCanna = JsonConvert.SerializeObject(tonino, Formatting.Indented);
File.WriteAllText(@"napoli.json", jsonCanna);

// e poi posso stamparlo in modo più ordinato come prima così:
Console.WriteLine($"Nome: {tonino.nome}");
Console.WriteLine($"Età: {tonino.eta}");
Console.WriteLine($"Presente: {tonino.presente}");
Console.WriteLine("Interessi:");
foreach (var InteresseC in tonino.interessi)
{
    Console.WriteLine($"- {InteresseC}");
}