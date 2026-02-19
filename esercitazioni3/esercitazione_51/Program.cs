
// dichiaro un dizionario int string
Dictionary<int, string> dizionario = new Dictionary<int, string>()
{
    { 1, "uno" },
    { 2, "due" },
    { 3, "tre" }
};
// aggiungo un elemento al dizionario
dizionario.Add(4, "quattro");
// se la chiave esiste già, il valore deve essere gestito in modo da essere aggiornato
dizionario[1] = "uno aggiornato";
dizionario[5] = "cinque";

Console.WriteLine(dizionario.Count); // output: 3
if (dizionario.Count == 0)
{
    Console.WriteLine("Il dizionario è vuoto.");
}
else
{
    Console.WriteLine($"Il dizionario contiene {dizionario.Count} elementi.");
}

