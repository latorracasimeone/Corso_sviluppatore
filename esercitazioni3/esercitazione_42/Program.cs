Random r = new Random();
List<int> cinqueplus = new List<int> (); 

for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Inserisca 1 per lanciare il dado, 0 per uscire");
    string input = Console.ReadLine();
    if (input == "1")
    {
        int dado = r.Next(1, 7);
        Console.WriteLine($"Il numero uscito è {dado}");
        if (dado >= 5)
        {
            cinqueplus.Add(dado);
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
Console.WriteLine("Risultati dei lanci maggiori o uguali a 5:");
foreach (int cinquemaggiore in cinqueplus)
{
    Console.WriteLine(cinquemaggiore);
}