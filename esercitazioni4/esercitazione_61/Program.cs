//ESERCITAZIONE 3 FUNZIONI LEZIONE 13

using System.ComponentModel;
using System.Diagnostics;

int verificaPari(int numero)
{
    if (numero % 2 == 0)
    {
        return numero;//ritorno il numero se è pari
    }
    else
    {
        return -1;//ritorno -1 per indicare che il numero non è pari
    }
}
Console.WriteLine("Inserisci un numero:");
int numero = Convert.ToInt32(Console.ReadLine());//chiedo all'utente di inserire un numero
int risultato = verificaPari(numero);//chiamo la funzione verificaPari e memorizzo il risultato
if (risultato != -1)
{
    Console.WriteLine($"Il numero {risultato} è pari");//stampo il risultato se è diverso da -1
}
else
{
    Console.WriteLine("ERRORE: Il numero non è pari, è dispari");//stampo un messaggio di errore se il risultato è -1
}