//Dado lanciato 5 Volte esercitazione finale 07 Random V4
Random ra = new Random();
List<int> tenuti = new List<int>();


for (int i = 0; i < 5; i++)
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
            tenuti.Add(dado);
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
Console.WriteLine("Lista dei risultati tenuti:");
int sas = 0;
foreach (int t in tenuti)
{
    Console.WriteLine(t);
    sas += t;
}
Console.WriteLine($"La somma dei valori ottenuti è: {sas}");
