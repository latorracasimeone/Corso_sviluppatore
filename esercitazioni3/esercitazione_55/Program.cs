//creo il dizionario prodotti
using System.Diagnostics.Contracts;
using System.Formats.Asn1;

Dictionary<string, DateTime> prodotti = new Dictionary<string, DateTime>();

//Creo il ciclo
while (true)
{
    Console.WriteLine("Inserisci il nome del prodotto (o 'exit' per uscire):");
    string prodotto = Console.ReadLine();
    if (prodotto == "exit")
    {
        break;//esce dal programma se si inserisce "exit" dove andrebbero inseriti i prodotti
    }
    Console.WriteLine("Inserisci data di scadenza:");
    string dataInput = Console.ReadLine();
    DateTime data = DateTime.Parse(dataInput);//converto l'input string testuale dell'Utente in Data
    prodotti[prodotto] = data;//aggiunge prodotto e data di scadenza nel dizionario
    DateTime oggi = DateTime.Today;
    TimeSpan mancanzaScadenza = data - oggi;
    Console.WriteLine($"Alla scadenza del prodotto {prodotto} mancano {mancanzaScadenza.TotalDays} giorni");
    if (mancanzaScadenza.TotalDays > 3)
    {
        Console.WriteLine($"Prodotto {prodotto} ancora ampiamente utilizzabile. Mancano ancora {mancanzaScadenza.TotalDays} giorni alla scadenza.");
    }
    else if (mancanzaScadenza.TotalDays > 0)
    {
        Console.WriteLine($"Il prodotto {prodotto} sta per scadere. Consumarlo tempestivamente. Scade fra {mancanzaScadenza.TotalDays} giorni");
    }
    else if (mancanzaScadenza.TotalDays <= 0)
    {
        Console.WriteLine($"ATTENZIONE: il prodotto {prodotto} è scaduto da {mancanzaScadenza.TotalDays} giorni");
    }
    continue;
}
Console.WriteLine("Prodotti e Scadenze:");//stampo tutti i prodotti precedentemente inseriti con data di scadenza estesa
foreach (var scadenza in prodotti)
{
    Console.WriteLine($"Prodotto: {scadenza.Key}, Scadenza: {scadenza.Value.ToLongDateString()}");
}
