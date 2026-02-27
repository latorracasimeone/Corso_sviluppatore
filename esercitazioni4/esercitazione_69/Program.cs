//Json parte 2 teorica
//public è un modificatore come uso interno dell'applicazione per il determinato dato

//Esempio di deserializzazione di un file json con una classe modello!!!!!!!!!!!!
//programma che legge un files Json e lo deserializza in un oggetto contatto 

using Newtonsoft.Json; //necessario per il funzionamento


//percorso del file json
string pathLastId = @"last_Id.json";
string pathContatti = @"contatti.json";

//deserializza il file json in un oggetto
string jsonLastId = File.ReadAllText(pathLastId);
string jsonContatti = File.ReadAllText(pathContatti);

//deserializzazione tramite JsonConvert
Identificatore lastId = JsonConvert.DeserializeObject<Identificatore>(jsonLastId);
List<Contatto> contatti = JsonConvert.DeserializeObject<List<Contatto>>(jsonContatti);

//una volta deserializzato, posso accedere ai campi dell'oggetto
//id
Console.WriteLine($"Last Id: {lastId.Id}");
//contatti
foreach (var contatto in contatti)
{
    Console.WriteLine($"ID: {contatto.Id}");
    Console.WriteLine($"Nome: {contatto.Nome}");
    Console.WriteLine($"Cognome: {contatto.Cognome}");
    Console.WriteLine($"Telefono: {contatto.Telefono}");
    Console.WriteLine($"Presente: {contatto.Presente}");
    Console.WriteLine("Interessi:");
    foreach (var interesse in contatto.Interessi)
    {
        Console.WriteLine(interesse);
    }
}

//provo a sovvrascrivere dopo aver deserializzato

Console.Write("Inserisca il Nome:");
string nomeNuovo = Console.ReadLine();
Console.Write("Inserisca il Cognome:");
string cognomeNuovo = Console.ReadLine();
Console.Write("Inserisca il numero di Telefono:");
string telefonoNuovo = Console.ReadLine();
Console.Write("Inserisca la presenza (true/false):");
string presenteNuovo = Console.ReadLine();

var partecipanteNuovo = new
{
    "id" = lastId +1,
    "Nome" = $"{nomeNuovo}",
    "Cognome" = $"{cognomeNuovo}",
    "Telefono" = $"{telefonoNuovo}",
    "Presente" = $"{presenteNuovo}"
};

//aggiorno contatti
contatti.lastId = lastId +1;

//serializzo
string updateNuovo = JsonConvert.SerializeObject(partecipanteNuovo, Formatting.Indented);

//scrivo la stringa json aggiornata sul file
File.WriteAllText(@"contatti.json", updateNuovo);


//le classi vanno in fondo (come le funzioni???)
public class Identificatore
{
    public int Id { get; set; }
}

public class Contatto
{
    public int Id { get; set; }
    public string Nome  { get; set; }
     public string Cognome  { get; set; }
     public string Telefono   { get; set; } 
     public bool Presente { get; set; }
     //proprietà lista d'interessi
     public List<string> Interessi  { get; set; }
}
