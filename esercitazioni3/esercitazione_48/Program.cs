// Dado lanciato 5 volte esercitazione finale 09 Metodo Array
// Differenza sostanziale nel stampare sempre e comunque 5 cifre, a 
//prescindere da quando si molli o di quanti valori non si conservino.
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;
using System.Xml;

Random ra = new Random();
int[] tenuti = new int[5];
int count = 0;

while (count < tenuti.Length)
{
    Console.WriteLine("Inserisca 1 per lanciare il dado, 0 per uscire");
    string input = Console.ReadLine();
    if (input == "1")
    {
        int dado = ra.Next(1, 7);
        Console.WriteLine($"Il numero uscito è {dado}");
        Console.WriteLine("Vuole tenere il risultato del lancio? 1=sì 0=no");
        string input2 = Console.ReadLine();
        if (input2 == "0")
        {
            Console.WriteLine("Ultimo lancio non conservato. Prosegua pure");
        }
        else if (input2 == "1")
        {
            tenuti[count] = dado;// Aggiunge il risultato alla posizione count dell'array
            count++;// Incrementa count solo se l'utente decide di tenere il lancio
        }
        else
        {
            Console.WriteLine("Inserisca un comando valido");
        }
    }
    else if (input == "0")
    {
        Console.WriteLine("Uscita dal programma. Arrivederci.");
        break;
    }
    else
    {
        Console.WriteLine("Input non valido. Prema 1 per eseguire il programma o 0 per uscire.");

    }
}
Array.Sort(tenuti);
Array.Reverse(tenuti);
int[] tenutiMaggioriUgualiDi5 = new int[tenuti.Length];
int index = 0;
foreach (int t in tenuti)
{
    if (t >= 5)
    {
        tenutiMaggioriUgualiDi5[index] = t;
        index++;
    }
}
Console.WriteLine("Lanci x>=5:");
for (int i = 0; i < index; i++)
{
    Console.WriteLine(tenutiMaggioriUgualiDi5[i]);
}