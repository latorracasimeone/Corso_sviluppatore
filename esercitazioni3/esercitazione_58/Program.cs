//Le funzioni servono a non dover riscrivere la stessa operazione cento volte. Scrivi il codice
// una volta sola dentro la funzione, e poi la "chiami" ogni volta che ti serve.
int Somma(int numero1, int numero2)
{
    int risultato = numero1 + numero2;
    return risultato; // La parola chiave "return" sputa fuori il risultato finale
}

Console.WriteLine("Inserire il primo numero:");
int numero1 = int.Parse(Console.ReadLine()); // Leggo il primo numero da console e lo converto in int
Console.WriteLine("Inserire il secondo numero che si sommerà al primo:");
int numero2 = int.Parse(Console.ReadLine()); // Leggo il secondo numero da console e lo converto in int
int totale = Somma(numero1, numero2); // Chiamo la funzione Somma con i due numeri inseriti dall'utente e salvo il risultato in 'totale'
Console.WriteLine($"La somma di {numero1} e {numero2} è: {totale}"); // Stampo il risultato della somma

Console.WriteLine("Inserire un numero:");
int numero3 = int.Parse(Console.ReadLine()); // Leggo un altro numero da console e lo converto in int
Console.WriteLine("Inserire un altro numero da sommare al precedente:");
int numero4 = int.Parse(Console.ReadLine()); // Leggo un altro numero da console e lo converto in int
int totale2 = Somma(numero3, numero4); // Chiamo di nuovo la funzione Somma con i nuovi numeri inseriti dall'utente e salvo il risultato in 'totale2'
Console.WriteLine($"La somma di {numero3} e {numero4} è: {totale2}"); // Stampo il risultato della seconda somma

int sommaSomme = Somma(totale, totale2); // Posso anche sommare i risultati delle due somme precedenti usando la stessa funzione
Console.WriteLine($"La somma totale di tutte le somme è: {sommaSomme}"); // Stampo il risultato della somma totale