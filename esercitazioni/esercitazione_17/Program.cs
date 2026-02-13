// Dichiarazione e inizializzazione del dizionario
Dictionary<string, int> dizionario = new Dictionary<string, int>();

// aggiungo delle coppie chiave-valore
dizionario.Add("Uno", 1);
dizionario.Add("Due", 4);
dizionario.Add("Tre", 3);

// stampa il valore associato alla chiave "Due"
Console.WriteLine(dizionario["Due"]);