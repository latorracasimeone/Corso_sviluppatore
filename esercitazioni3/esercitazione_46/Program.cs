//Esercitazione finale capitolo 08
string nomi = ("Timone, Burri, Carmè, Johnny, Thanos");
string[] nomiArray = nomi.Split(", ");
Console.WriteLine("Inserire una parte del nome da cercare:");
string nomeDaCercare = Console.ReadLine();


bool trovato = false;
foreach (string nome in nomiArray)
{
    if (nome.Contains(nomeDaCercare))
    {
        Console.WriteLine($"Il pezzo '{nomeDaCercare}' è presente nella stringa. Il nome corrispettivo è: {nome}");
        trovato = true;
        break;
    } 
}
if (!trovato)
{
    Console.WriteLine($"Il pezzo '{nomeDaCercare}' non è presente nella stringa.");
}



