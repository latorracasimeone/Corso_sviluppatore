//////////PROGRAMMA COMPLETO (DA SCRIVERE) PER LA GESTIONE DI UNA RUBRICA CON CONTATTI, CHE INCLUDE:
using Newtonsoft.Json;
/// -utilizzo di classi modello per rappresentare i dati dei contatti e degli ID



/// -utilizzo di classi controller per gestire la logica di business della rubrica

//da lasciare nel file originale Program.cs?????????????


class Program
{
    // la firma del metodo Main è sempre la stessa, con un array di stringhe come parametro che indica gli argomenti della riga di comando
    static void Main(string[] args)
    {
        //vogliamo permettere all'utente di inserire i dati di un nuovo contatto tramite la console, e poi salvare questi dati in un file JSON

        Console.WriteLine("Inserisci il nome del contatto:");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome del contatto:");
        string cognome = Console.ReadLine();
        Console.WriteLine("Inserisci l'email del contatto:");
        string email = Console.ReadLine();
        Console.WriteLine("Inserisci il numero di telefono del contatto:");
        string numero = Console.ReadLine();
        Console.WriteLine("Il contatto è presente? (s/n):");
        bool presente = Console.ReadLine().ToLower() == "s";
        Console.WriteLine("Inserisci gli interessi del contatto (separati da virgola):");
        List<string> interessi = Console.ReadLine().Split(',').Select(i => i.Trim()).ToList();

    }
}



/// -suddivisione dei files in folders di Models, Controllers, Helpers e Data (e invece Services/?????????????)
/// 
/// 
/// 
/// -utilizzo di una classe statica JSONHelper per semplificare la lettura e scrittura dei file Json
/// 
/// 
///
/// -validazione dei dati di input tramite decoratori
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// Il focus di questo programma è sull'organizzazione del codice e sull'utilizzo dei decoratori per validare i dati di input
/// La suddivisione completa delle responsabilità delleclassi modello, controller e helper permette di mantenere il codice pulito, modulare e facilmente manutentibile
/// 

//
///
/// 

