///ESERCITAZIONE GUIDA

//creo una lista di operatori validi alla quale attingere
List<string> operatoriValidi = new List<string> {"+", "-", "*", "/"};//lista di operatori validi

//scrivo funzione
double calcolatrice(string input)
{
    //divido l'input in parti (invece di doverne scrivere uno alla volta) usando lo spazio come delimitatore
    string[] parti = input.Split(' ');
    //verifico se l'input ha esattamente 3 parti (numero, operatore e numero)
    if (parti.Length != 3)
    {
        Console.WriteLine("ERRORE: input non valido. Inserire operazione in formato 'numero operatore numero'");
        //restituisco NaN (Not a Number) per indicare errore
        return double.NaN;
    }

    //tento di convertire la prima parte in un numero anche decimale (difatti si parla di 
    // double' e non 'int')
    //PS: ! significa "Se non è vero che..."
    //PPS: standard: double numero1 = double.Parse(input); versione try (meglio): double.TryParse(input, out double numero1) 
    if (!double.TryParse(parti[0], out double numero1))
    {
        Console.WriteLine($"ERRORE: '{parti[0]}' non è un numero valido.");
        return double.NaN;
    }

    //verifico se l'operatore è valido
    //prendo l'operatore dalla seconda parte scrivendo questo string perché nel tryparse è già incorporato nella funzione fra parentesi??????????
    string operatore = parti[1];
    if (!operatoriValidi.Contains(operatore))
    {
        Console.WriteLine($"ERRORE: '{operatore}' non è un operatore valido. Inserire +, -, * o /");
        return double.NaN;
    }
    //tento di convertire la terza parte in un numero decimale
    if (!double.TryParse(parti[2], out double numero2))
    {
        Console.WriteLine($"ERRORE: '{parti[2]}' non è un numero valido.");
        return double.NaN;
    }

    //eseguo l'operazione in base all'operatore tramite SWITCH
    switch (operatore)
    //Divido il tutto caso per caso a seconda dell'operazione
    {
        case "+":
        return numero1 + numero2;
        case "-":
        return numero1 - numero2;
        case "*":
        return numero1 * numero2;
        case "/":
        //se il divisore è 0 deve darmi errore
        if (numero2 == 0)
            {
                Console.WriteLine("ERRORE: divisione per zero non consentita.");
                return double.NaN;
            }
        return numero1 / numero2;
        //ora definisco un default, simile all'else utilizzato dopo gli if
        default:
        Console.WriteLine("ERRORE: operatore non riconosciuto...");
        return double.NaN;
    }
}
Console.WriteLine("Calcolatrice per singola operazione. Inserire l'operazione (es: '15 + 18'):");
string input = Console.ReadLine();
//chiamo la funzione calcolatrice creata all'inizio (parte destra "dell'equazione") con l'input dell'utente e creo un nuovo double da stampare
double risultato = calcolatrice(input);
Console.WriteLine($"{input} = {risultato}");