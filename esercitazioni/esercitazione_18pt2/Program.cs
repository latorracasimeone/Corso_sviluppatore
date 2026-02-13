// 1. Creazione della lista di stringhe
List<string?> listaNomi = new List<string?>();
 // 2. Chiedere all'utente di inserire il primo nome
 Console.Write("Inserisci il primo nome:");
string? nome1 = Console.ReadLine();
// Aggiungere il primo nome alla lista
listaNomi.Add(nome1);
// Chiedere all'utente di inserire il secondo nome
Console.Write("Inserisci il secondo nome:");
string? nome2 = Console.ReadLine();
// Aggiungere il secondo nome alla lista
listaNomi.Add(nome2);
// Chiedere all'utente di inserire il terzo nome
Console.Write("Inserisci il terzo nome:");
string? nome3 = Console.ReadLine();
// Aggiungere il terzo nome alla lista
listaNomi.Add(nome3);


//Chiedi all'utente quale nome vuole stampare
Console.WriteLine("Quale nome vuoi stampare? (1°, 2° o 3°)?");
int indice = int.Parse(Console.ReadLine());

//Stampare il nome preselezionato dall'utente
Console.WriteLine($"Il nome scelto è: {listaNomi[indice - 1]}");

