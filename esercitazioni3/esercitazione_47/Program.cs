//Lezione 09: METODI ARRAY
using System.Data;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
//??^

int[] numeri = { 1, 2, 3, 4, 6, 5 }; //una volta avviato con dotnet run,
// non si può aggiungere nulla all'array. 

Console.WriteLine(numeri.Length);

string[] nomi = { "Nome1", "Nome2", "Nome3", "Nome4", "Nome5" };
Console.WriteLine(nomi.Length);


int[] numeriCopia = new int[numeri.Length]; // devo dichiarare l'array
Array.Copy(numeri, numeriCopia, numeri.Length);
Console.WriteLine(string.Join(", ", numeriCopia)); // output: 1, 2, 3, 4, 6, 5


Array.Clear(numeriCopia, 0, numeriCopia.Length); // resetta i valori partendo dall indice 0 fino alla lunghezza dell array
Console.WriteLine(string.Join(", ", numeriCopia)); // output: 0, 0, 0, 0, 0


Array.Reverse(numeri); // reverse inverte l array
Console.WriteLine(string.Join(", ", numeri)); // output: 5, 6, 4, 3, 2, 1


Array.Sort(numeri); // sort ordina l array in ordine crescente
Console.WriteLine(string.Join(", ", numeri)); 


Array.Sort(numeri); // sort ordina l array in ordine crescente
Array.Reverse(numeri); // reverse inverte l'array, quindi ordine decrescente
Console.WriteLine(string.Join(", ", numeri)); 


int indice = Array.IndexOf(numeri, 3); // l'indice è la posizione (esempio il primo numero della lista sarà in indice 0, il secondo in indice 1, ecc. ecc.)
Console.WriteLine(indice); // output: 3