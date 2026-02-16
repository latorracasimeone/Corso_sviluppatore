//come l'esercizio precedente ma con do while invece di while e foreach
List <int> numeri = new List<int> {};
do
{
    Console.WriteLine("Inserisca un numero (0 per terminare):");
    string input = Console.ReadLine();
    int numero = int.Parse(input);
    if ( numero == 0)
    {
        break;
    }
    numeri.Add(numero);
}
while (true);
{
    Console.WriteLine("I numeri da lei inseriti sono:");
    foreach (var num in numeri)
    {
        Console.WriteLine($"{num}!");
    }
}            