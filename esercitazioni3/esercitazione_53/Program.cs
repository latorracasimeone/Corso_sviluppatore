//ESERCITAZIONE V1 LEZIONE 11 METODI DIZIONARI:

Dictionary<string, string> rubrica = new Dictionary<string, string>();

while (true)
{
    Console.WriteLine("Inserisci un nome (oppure, digitare: 'exit' per uscire, 'canc' per eliminare un contatto, 'mod' per modificarlo):");
    string nome = Console.ReadLine();

    if (nome.ToLower() == "exit")// esce dal ciclo e termina il programma se l'utente digita "exit"
    {
        break;
    }
    else if (nome.ToLower() == "canc")// se l'utente digita "canc", mostra i contatti attuali e chiede quale contatto eliminare
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
    else if (nome.ToLower() == "mod")// se l'utente digita "mod", mostra i contatti attuali e chiede quale contatto modificare
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
    else if (rubrica.ContainsKey(nome))// se il nome inserito esiste già nella rubrica, chiede se si vuole sovrascrivere il numero esistente
    {
        Console.WriteLine($"Il contatto '{nome}' esiste già con il numero '{rubrica[nome]}'. Vuoi sovrascriverlo? (s/n)");
        string risposta = Console.ReadLine();
        if (risposta.ToLower() != "s")
        {
            Console.WriteLine("Contatto non modificato.");
            continue; // Torna all'inizio del ciclo per chiedere un nuovo nome
        }
        else if (risposta.ToLower() == "s")
        {
            Console.WriteLine("Inserisci il nuovo numero di telefono:");
            string nuovoNumero = Console.ReadLine();
            rubrica[nome] = nuovoNumero; // Sovrascrive il numero esistente con il nuovo numero
            Console.WriteLine($"Contatto '{nome}' aggiornato con il nuovo numero '{nuovoNumero}'.");
            continue; // Torna all'inizio del ciclo per chiedere un nuovo nome
        }
        
    }

    Console.WriteLine("Inserisci un numero di telefono:");
    string numero = Console.ReadLine();

    rubrica[nome] = numero; // Aggiunge o aggiorna il numero associato al nome
    Console.WriteLine($"Contatto '{nome}' aggiunto con numero '{numero}'.");
}
Console.WriteLine("Rubrica finale:");
foreach (var contatto in rubrica)// scorro tutti i contatti nella rubrica
{
    Console.WriteLine($"Nome: {contatto.Key}, Numero: {contatto.Value}");
}