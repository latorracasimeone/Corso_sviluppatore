// acquisisco il punteggio di un esame
Console.WriteLine("Inserisci il punteggio dell'esame:");
int punteggio = int.Parse(Console.ReadLine());

// verifico il punteggio e stampo il voto corrispondente
if (punteggio >= 90)
{
    Console.WriteLine("Voto: A");
}
else if (punteggio >= 80)
{
    Console.WriteLine("Voto: B");
}
else if (punteggio >= 70)
{
    Console.WriteLine("Voto: C");
}
else if (punteggio >= 60)
{
    Console.WriteLine("Voto: D");
}
else
{
    Console.WriteLine("Voto: F");
}