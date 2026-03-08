//ESERCITAZIONE V1 LEZIONE 11 METODI DIZIONARI:

Dictionary<string, string> rubrica = new Dictionary<string, string>();

while (true)
{
    Console.WriteLine("Inserisci un comando: \n'exit' per uscire, \n'agg' per aggiungere contatti, \n'canc' per eliminare un contatto, \n'mod' per modificarlo \n'stamp' per visionare i contatti esistenti:");
    string nome = Console.ReadLine();

    if (nome.ToLower() == "exit")// esce dal ciclo e termina il programma se l'utente digita "exit"
    {
        break;
    }
    else if (nome.ToLower() == "canc")// se l'utente digita "canc", mostra i contatti attuali e chiede quale contatto eliminare
    {
        Stampa();
        Console.WriteLine("Inserisci il nome del contatto da eliminare:");
        string nomeDaEliminare = Console.ReadLine();
        Elimina(nomeDaEliminare);
        continue;
        // Torna all'inizio del ciclo per chiedere un nuovo nome
    }
    else if (nome.ToLower() == "mod")// se l'utente digita "mod", mostra i contatti attuali e chiede quale contatto modificare
    {
        Stampa();
        Console.WriteLine("Inserisci il nome del contatto da modificare:");
        string nomeDaModificare = Console.ReadLine();
        Modifica(nomeDaModificare);
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
    else if (nome.ToLower() == "stamp")
    {
        Stampa();
        continue;
    }
    else if (nome.ToLower() == "agg")
    {
        Aggiungi();
        continue;
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

//qui inserirò le funzioni
void Stampa()
{
    Console.WriteLine("Contatti attuali:");
    foreach (var contatto in rubrica)// scorro tutti i contatti nella rubrica prima di chiedere quale contatto eliminare
    {
        Console.WriteLine($"Nome: {contatto.Key}, Numero: {contatto.Value}");
    }
}

void Elimina(string nome)
{
    if (rubrica.Remove(nome))
        {
            Console.WriteLine($"Contatto '{nome}' eliminato.");
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto '{nome}' non trovato.");
        }
}

void Modifica(string nome)
{
    if (rubrica.ContainsKey(nome))
        {
            Console.WriteLine("Inserisci il nuovo numero di telefono:");
            string nuovoNumero = Console.ReadLine();
            rubrica[nome] = nuovoNumero;
            Console.WriteLine($"Contatto '{nome}' modificato con il nuovo numero '{nuovoNumero}'.");
        }
        else
        {
            Console.WriteLine($"ERRORE: Contatto '{nome}' non trovato.");
        }
}

void Aggiungi()
{
    while (true)
    {
        Console.WriteLine("Inserire un nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("Insererire il numero di telefono:");
        string telefono = Console.ReadLine();
        rubrica.Add(nome, telefono);
        Console.WriteLine("Vuoi aggiungere un altro contatto? (n per uscire)");
        if (Console.ReadLine() == "n")
        {
            break;//esce dal ciclo della funzione Aggiungi();
        }
    }    
}