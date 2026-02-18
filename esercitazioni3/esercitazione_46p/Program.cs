string[] nomi = { "Nome1", "Nome2", "Nome3", "Nome4", "Nome5" };

Console.WriteLine("Inserisci una parte del nome da cercare:");
string nomeDaCercare = Console.ReadLine();

bool trovato = false;

foreach (string nome in nomi)
{
    if (nome.Contains(nomeDaCercare))
    {
        Console.WriteLine($"Nome trovato: {nome}");
        trovato = true;
        break; // Esce dal ciclo dopo aver trovato il primo nome che contiene la stringa cercata
    }
}

if (!trovato)
{
    Console.WriteLine("Nome non trovato.");
}