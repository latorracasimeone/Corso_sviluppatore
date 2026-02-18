//lezione 10 Metodi Lista
List<int> numeri = new List<int>();
numeri.Add(1);
numeri.Add(2);
numeri.Add(3);
Console.WriteLine(string.Join(", ", numeri)); // output: 1, 2, 3


Console.WriteLine(numeri.Count); // output: 3

numeri.Add(4);

Console.WriteLine(string.Join(", ", numeri));


// aggiunta diretta di più elementi alla lista
numeri.AddRange(7,8,9,10);

// aggiunta di più elementi alla lista tramite un array
numeri.AddRange(new int[] { 4, 5, 6 });

Console.WriteLine(string.Join(", ", numeri)); // output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10

// oppure tramite un altra lista
List<int> numeri2 = new List<int>() {11, 12, 13, 14 };
numeri.AddRange(numeri2);
Console.WriteLine(string.Join(", ", numeri)); // output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14


