// acquisisco l'età dell'utente
using System.Diagnostics.Tracing;
using System.Globalization;

Console.WriteLine("Inserisci la tua età:");
int eta = int.Parse(Console.ReadLine());

// se l'età è maggiore o uguale a 18, stampo un messaggio
if (eta >= 18)
{
    Console.WriteLine("L'Utente è maggiorenne.");
}
else // se l'età è minore di 18, stampo un messaggio di accesso negato
{
    Console.WriteLine("L'Utente è minorenne. ACCESSO NEGATO.");
}
