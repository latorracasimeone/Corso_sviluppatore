//ESERCITAZIONE 2 LEZIONE 13 Funzioni

string ReadLineAvanzato()// funzione che legge l'input dell'utente e lo valida
{
    while (true) // ciclo infinito
    {
        string input = Console.ReadLine().Trim().ToLower(); // leggo l'input e lo elaboro, rimuovendo spazi bianchi e convertendo tutto in minuscolo per una validazione più semplice
        if (!string.IsNullOrEmpty(input)) // verifico se l'input è valido o vuoto
        {
            return input; // restituisco l'input validato e convertito in minuscolo
            // il return si compporta come un'uscita dal ciclo e dalla funzione, quindi se l'input è valido, la funzione termina restituendo l'input
        }
        Console.WriteLine("Input non valido. Inserisci un valore non vuoto:"); // messaggio di errore
    }
}

Console.WriteLine("Inserisci un valore:"); // prompt per l'utente
string valore = ReadLineAvanzato(); // chiamo la funzione ReadLineAvanzato
Console.WriteLine($"Hai inserito: {valore}"); // stampo il valore inserito dall'utente