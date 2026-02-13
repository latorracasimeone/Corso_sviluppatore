// Numero predefinito come costante
const int NUMERO_PREDEFINITO = 10;

// Acquisire l'input dell'utente
Console.WriteLine("Inserisci un numero:");
string input = Console.ReadLine();

// Tentare di convertire l'input in un intero
// Abbiamo bisogno di out ed int per poter raccogliere il risultato della conversione e sapere se è riuscita o meno
// nel out dobbiamo specificare una variabile di tipo int che conterrà il risultato della conversione se questa ha successo
// Se la conversione ha successo, viene creata una variabile numeroUtente che contiene il valore convertito
// altrimenti numeroUtente avrà un valore di default (0) e la conversione fallirà restituendo false
if (int.TryParse(input, out int numeroUtente))
{
    // Se la conversione ha successo, sommare il numero predefinito e l'input dell'utente
    int risultato = NUMERO_PREDEFINITO + numeroUtente;
    Console.WriteLine($"La somma è: {risultato}");
}
else
{
    // Se la conversione fallisce, stampare un messaggio di errore
    Console.WriteLine("Errore: l'input inserito non è un numero valido.");
}