//uguale a 33 ma con Foreach
List<int> numeri = new List<int> { 1, 3, 5, 10, 11, 12, 15, 19, 33};
foreach (var numero in numeri)
{
    if (numero % 3 == 0 && numero % 5 == 0)
    {
        Console.WriteLine($"{numero}fizzbuzz");
    }
    else if (numero % 3 == 0)
    {
        Console.WriteLine($"{numero}fizz");
    }
    else if (numero % 5 == 0)
    {
        Console.WriteLine($"{numero}buzz");
    }
    else
    {
        Console.WriteLine(numero);
    }
}    