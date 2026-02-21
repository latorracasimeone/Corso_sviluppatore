//ESERCITAZIONE V1 LEZIONE 11 METODI DIZIONARI:

Dictionary<string, string> rubrica = new Dictionary<string, string>();

while (true)
{
    Console.WriteLine("Inserisci un nome (oppure, digitare: 'exit' per uscire, 'canc' per eliminare un contatto, 'mod' per modificarlo):");
    string nome = Console.ReadLine();

    if (nome.ToLower() == "exit")
    {
        break;
    }
    else if (nome.ToLower() == "canc")
    {
        Console.WriteLine("Contatti attuali:");
        foreach (var contatto in rubrica)// scorro tutti i contatti nella rubrica prima di chiedere quale contatto eliminare
        {
            Console.WriteLine($"Nome: {contatto.Key}, Numero: {contatto.Value}");
        }
        Console.WriteLine("Inserisci il nome del contatto da eliminare:");
        string nomeDaEliminare = Console.ReadLine();

        if (rubrica.Remove(nomeDaEliminare))
        {
            Console.WriteLine($"Contatto '{nomeDaEliminare}' eliminato.");
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto '{nomeDaEliminare}' non trovato.");
        }
        continue; 
        // Torna all'inizio del ciclo per chiedere un nuovo nome
    }
    else if (nome.ToLower() == "mod")
    {
        Console.WriteLine("Contatti attuali:");
        foreach (var contatto in rubrica)
        {
            Console.WriteLine($"Nome: {contatto.Key}, Numero: {contatto.Value}");
        }
        Console.WriteLine("Inserisci il nome del contatto da modificare:");
        string nomeDaModificare = Console.ReadLine();

        if (rubrica.ContainsKey(nomeDaModificare))
        {
            Console.WriteLine("Inserisci il nuovo numero di telefono:");
            string nuovoNumero = Console.ReadLine();
            rubrica[nomeDaModificare] = nuovoNumero;
            Console.WriteLine($"Contatto '{nomeDaModificare}' modificato con il nuovo numero '{nuovoNumero}'.");
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto '{nomeDaModificare}' non trovato.");
        }
        continue; // Torna all'inizio del ciclo per chiedere un nuovo nome
    }

    Console.WriteLine("Inserisci un numero di telefono:");
    string numero = Console.ReadLine();

    rubrica[nome] = numero; // Aggiunge o aggiorna il numero associato al nome
    Console.WriteLine($"Contatto '{nome}' aggiunto/aggiornato con numero '{numero}'.");
}
Console.WriteLine("Rubrica finale:");
foreach (var contatto in rubrica)// scorro tutti i contatti nella rubrica
{
    Console.WriteLine($"Nome: {contatto.Key}, Numero: {contatto.Value}");
}