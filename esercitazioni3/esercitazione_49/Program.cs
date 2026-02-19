//lezione 10 Metodi Lista
List<int> numeri = new List<int>();
numeri.Add(1);
numeri.Add(2);
numeri.Add(3);
Console.WriteLine(string.Join(", ", numeri)); // output: 1, 2, 3


Console.WriteLine(numeri.Count); // output: 3

numeri.Add(16);
Console.WriteLine(string.Join(", ", numeri));


// aggiunta di più elementi alla lista tramite un array
numeri.AddRange(new int[] { 4, 5, 6 });

// aggiunta diretta di più elementi alla lista
numeri.AddRange(7,8,9,10);

Console.WriteLine(string.Join(", ", numeri)); // output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10

// oppure tramite un altra lista
List<int> numeri2 = new List<int>() {11, 12, 13, 14, 15 };
numeri.AddRange(numeri2);
Console.WriteLine(string.Join(", ", numeri)); // output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15


numeri.Insert(0, 0); // inserisce il numero 1 all'inizio della lista
Console.WriteLine(string.Join(", ", numeri)); // output: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15


Console.WriteLine(numeri.Contains(5)); // output: true
Console.WriteLine(numeri.Contains(30)); // output: false

Console.WriteLine(numeri.Count);
Console.WriteLine("Prego, inserisca un numero. True= numero inserito da lei presente, in caso contrario False.");
string soreta = Console.ReadLine();
int numeropoli = int.Parse(soreta);
Console.WriteLine(numeri.Contains(numeropoli));


Console.WriteLine("Proseguiamo:");

Console.WriteLine($"L'indice del numero 16 è {numeri.IndexOf(16)}");
Console.WriteLine("Inserire un numero per verificarne l'indice");
string edicisì = Console.ReadLine();
int Cannavacciuolo = int.Parse(edicisì);
Console.WriteLine($"L'indice del numero inserito {edicisì} è {numeri.IndexOf(Cannavacciuolo)}");

Console.WriteLine("Proseguiamo:");


numeri.Sort();//ordina in ordine crescente
Console.WriteLine(string.Join(", ", numeri)); // output: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16

Console.WriteLine($"ORA l'indice del numero 16 è {numeri.IndexOf(16)}!!");


numeri.Reverse();
Console.WriteLine(string.Join(", ", numeri)); 


int[] numeriArray = numeri.ToArray();
Console.WriteLine($"Ora in Array {string.Join(", ", numeriArray)}");


Console.WriteLine(numeri.Remove(5)); // output: true
Console.WriteLine(numeri.Remove(30)); // output: false
Console.WriteLine(string.Join(", ", numeri)); // stampa la lista senza i numeri rimossi


//rimuoviamo un elemento dalla lista in base all'indice.
numeri.RemoveAt(0); // rimuove il primo elemento (16)
Console.WriteLine(string.Join(", ", numeri)); 


numeri.Clear();
Console.WriteLine($"Ora che la lista è stata svuotata con Clear contiene: {string.Join(", ", numeri)} !"); // output: (lista vuota)
