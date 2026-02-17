//progamma un dado a 6 facce che con 1 lanci il dado e con 0 esce dal programma
Random r = new Random();
while (true)
{
    Console.WriteLine("Prema 1 per lanciare il dado, 0 per uscire");
    string i = Console.ReadLine();
    int n = int.Parse(i);//conversione non necessaria?
    int dado = r.Next(1, 7);
    if (n == 0)
    {
        break;
    }
    else if (n == 1)
    {
        Console.WriteLine($"Faccia numero {dado}");
    }
    else
    {
        Console.WriteLine("inserito comando non valido, prego ritenti.");
    }
}    





