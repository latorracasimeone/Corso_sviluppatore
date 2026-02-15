//Chiediamo all'Utente di inserire un numero
Console.WriteLine("Inserisca un numero:");
int num = int.Parse(Console.ReadLine());
//Se il numero è divisibile, e quindi offre resto (simbolo %) 0, per 3 
//e allo stesso tempo (simbolo &&) è divisibile per 5, allora stampiamo "fizzbuzz"
if (num % 3 == 0 && num % 5 == 0)
{
    Console.WriteLine("fizzbuzz");
}
//Altrimenti, se il numero è divisibile solo per 3, allora stampiamo "fizz"
else if (num % 3 == 0)
{
    Console.WriteLine("fizz");
}
//Altrimenti, se il numero è divisibile solo per 5, allora stampiamo "buzz"
else if (num % 5 == 0)
{
    Console.WriteLine("buzz");
}
//altrimenti, se il numero non è devisibile né per 3 né per 5, 
//allora stampiamo nuovamente il numero inserito dall'Utente.
else
{
    Console.WriteLine(num);
}
