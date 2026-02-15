//Guarda esercitazione 30 per questione "fizzbuzz"
Console.WriteLine("Inserisca un numero:");
int n = int.Parse(Console.ReadLine());
switch (true)
{
    case bool _ when n % 3 == 0 && n % 5 == 0:
    Console.WriteLine("fizzbuzz");
    break;
    case bool _ when n % 3 == 0:
    Console.WriteLine("fizz");
    break;
    case bool _ when n % 5 == 0:
    Console.WriteLine("buzz");
    break;
    default:
    Console.WriteLine($"{n} non è divisibile né per 3 né per 5");
    break;
}