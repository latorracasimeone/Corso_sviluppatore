using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Creazione della lista di stringhe
        List<string> listaNomi = new List<string>();

        // 2. Chiedere all'utente di inserire il primo nome
        Console.Write("Inserisci il primo nome: ");
        string nome1 = Console.ReadLine();

        // 3. Aggiungere il primo nome alla lista (Indice 0)
        listaNomi.Add(nome1);

        // 4. Chiedere all'utente di inserire il secondo nome
        Console.Write("Inserisci il secondo nome: ");
        string nome2 = Console.ReadLine();

        // 5. Aggiungere il secondo nome alla lista (Indice 1)
        listaNomi.Add(nome2);

        // 6. Chiedere all'utente di inserire il terzo nome
        Console.Write("Inserisci il terzo nome: ");
        string nome3 = Console.ReadLine();

        // 7. Aggiungere il terzo nome alla lista (Indice 2)
        listaNomi.Add(nome3);

        // 8. Stampare in console il secondo nome della lista
        // Ricorda: il secondo elemento è all'indice [1]
        Console.WriteLine("\nIl secondo nome inserito è:");
        
        // 9. Stampare il nome corrispondente
        Console.WriteLine(listaNomi[1]);
    }
}