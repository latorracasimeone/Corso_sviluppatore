// Dichiarazione e inizializzazione del dizionario
Dictionary<int, string> dizionario = new Dictionary<int, string>

// aggiungo delle coppie chiave-valore
{
    { 1, "Valore1" },
    { 2, "Trento" },
    { 3, "Valore3" }
};

// stampa il valore associato alla chiave 2
Console.WriteLine(dizionario[2]);