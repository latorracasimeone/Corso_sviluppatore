Random random = new Random();
int[] lanciTenuti = new int[5];
int count = 0;

while (count < lanciTenuti.Length)
{
    Console.WriteLine("Premi 1 per lanciare il dado:");
    string input = Console.ReadLine();

    if (input == "1")
    {
        int dado = random.Next(1, 7);
        Console.WriteLine($"Hai lanciato il dado e hai ottenuto: {dado}");

        Console.WriteLine("Vuoi tenere questo risultato? Premi 1 per tenere, 0 per scartare:");
        string decisione = Console.ReadLine();

        if (decisione == "1")
        {
            lanciTenuti[count] = dado; // Aggiunge il risultato alla posizione count dell'array
            count++; // Incrementa count solo se l'utente decide di tenere il lancio
        }
    }
    else
    {
        Console.WriteLine("Input non valido. Per favore, premi 1.");
    }
}

Array.Sort(lanciTenuti); // ordina in ordine crescente
Array.Reverse(lanciTenuti); // inverte l'array per avere l'ordine decrescente

int[] lanciMaggioriUguali5 = new int[lanciTenuti.Length];
int index = 0;

foreach (int lancio in lanciTenuti)
{
    if (lancio >= 5)
    {
        lanciMaggioriUguali5[index] = lancio; // Aggiunge il lancio al nuovo array
        index++; // Incrementa l'indice del nuovo array
    }
}

Console.WriteLine("Lanci maggiori o uguali a 5:");
for (int i = 0; i < index; i++)
{
    Console.WriteLine(lanciMaggioriUguali5[i]);
}