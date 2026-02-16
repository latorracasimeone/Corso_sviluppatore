Console.WriteLine("Inserisci la tua età:");
int eta = int.Parse(Console.ReadLine());

// se l'età è maggiore o uguale a 18, stampo un messaggio
if (eta >= 18)
{
    Console.WriteLine("L'Utente è maggiorenne.");
}
else if (eta < 18 && eta >= 10)
{
    Console.WriteLine("L'Utente è minorenne. ACCESSO NEGATO.");
}
else if (eta < 10 && eta >= 0)
{
    Console.WriteLine("L'Utente è un bambino. MALANDRINO!!!");
}
else
{
    Console.WriteLine("Età non valida.");
}