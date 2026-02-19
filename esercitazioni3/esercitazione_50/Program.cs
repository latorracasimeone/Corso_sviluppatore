//IMPORTANTE?
using System.Runtime.InteropServices;

List<string> nomi = new List<string>();//creo la lista
string input;//creo l'acquisizione di input dell'utente per la lista appena creata
Random nomiCas = new Random();//per generare numeri casuali
while (true) //chiediamo all'utente di inserire nomi che verranno aggiunti alla lista finché non preme 0, dove passerà direttamente all'estrazione casuale dei nomi
{
    Console.WriteLine("Inserisca dei nomi che verranno aggiunti ad una lista. Prema 0 per passare all'estrazione casuale di uno dei nomi inseriti.");
    input = Console.ReadLine();//generiamo l'input di ciò che scrive l'Utente
    if (input == "0")
    {
        break;
    }
    nomi.Add(input);
}

while (nomi.Count > 0)//indica che la fase di estrazione casuale dei nomi continuerà finché la lista non è vuota (nomi.Couunt = 0)
{
    int indiceCas = nomiCas.Next(nomi.Count);
    string estratto = nomi[indiceCas];//assegno alla variabile estratto il nome pescato casualmente dalla lista
    
    Console.WriteLine($"i nomi estratti sono: {estratto}");
    nomi.RemoveAt(indiceCas);//rimuovi il nome casuale appena pescato e mostrato all'utente per evitare che venisse ripescato e permettere al while di ultimarsi

    Console.WriteLine("Vuoi estrarre un altro nome? (y/n)");
    string risposta = Console.ReadLine();//variabile risposta come input per proseguire o menio
    if (risposta == "n")
    {
        break;//il while viene interrotto come se fossero finiti i nomi da sorteggiare
    }
}