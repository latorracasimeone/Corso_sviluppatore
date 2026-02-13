// Dichiarazione e inizializzazione del dizionario
Dictionary<int, string> dizionario = new Dictionary<int, string>

// aggiungo delle coppie chiave-valore
{
    { 1, "Napoli" },
    { 2, "Brianza" },
    { 3, "Genova" }
};

// stampa il valore associato alla chiave 2
Console.WriteLine(dizionario[2]);