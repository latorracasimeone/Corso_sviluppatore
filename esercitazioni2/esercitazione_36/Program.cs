

List<int> numeri = new List<int> {};
while (true)
{
    Console.WriteLine("Inserisca un numero (0 èer terminare il programma)");
    string? input = Console.ReadLine();
    int numero = int.Parse(input);

    if (numero == 0)
    {
        break;
    }
    numeri.Add(numero);
}     

    Console.WriteLine("I numeri inseriti sono:");
    foreach (var n in numeri)
    {
        Console.WriteLine(n);
    }
