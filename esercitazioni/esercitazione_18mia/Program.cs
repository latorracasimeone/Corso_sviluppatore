// 1. Creazione della lista di stringhe
List<string> listaNomi = new List<string>();
 // 2. Chiedere all'utente di inserire il primo nome
 Console.Write("Inserisci il primo nome: ");
string nome1 = Console.ReadLine();
// Aggiungere il primo nome alla lista
listaNomi.Add(nome1);
// Chiedere all'utente di inserire il secondo nome
Console.Write("Inserisci il secondo nome:");
string nome2 = Console.ReadLine();
// Aggiungere il secondo nome alla lista
listaNomi.Add(nome2);
// Chiedere all'utente di inserire il terzo nome
Console.Write("Inserisci il terzo nome:");
string nome3 = Console.ReadLine();
// Aggiungere il terzo nome alla lista
listaNomi.Add(nome3);
// Stampare in console il secondo nome della lista
Console.WriteLine("Il secondo nome inserito è:");
// Stampare il nome corrispondente
Console.WriteLine(listaNomi[1]);