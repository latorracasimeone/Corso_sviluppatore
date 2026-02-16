for (int i = 0; i < 3; i++)
{
    Console.WriteLine("Inserisca un numero:");
    string? inp = Console.ReadLine();//lettura dell'inserzione dell'utente
    int num = int.Parse(inp);//conversione dell'inserzione da testo a int
    Console.WriteLine($"Il numero inserito è {num}");
}    