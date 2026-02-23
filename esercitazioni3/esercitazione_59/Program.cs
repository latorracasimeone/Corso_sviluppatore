while (true)
{
    Console.WriteLine("Inserisci un numero ('e' per uscire):");
    string input = Console.ReadLine();  
    if (input == "e")
    {
        break;
    }
    else
    {
        int numero1 = int.Parse(input); // Converto l'input in un numero intero
        Console.WriteLine("Inserisci un altro numero da sommare allo scorso precedentemente inserito:");
        string input2 = Console.ReadLine();
        int numero2 = int.Parse(input2);
        int somma = numero1 + numero2;
        Console.WriteLine($"La somma di {numero1} e {numero2} è: {somma}");
        continue; // Torno all'inizio del ciclo per chiedere un nuovo numero o uscire
    }
    
}
