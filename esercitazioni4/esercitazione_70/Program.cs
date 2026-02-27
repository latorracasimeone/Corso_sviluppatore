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
