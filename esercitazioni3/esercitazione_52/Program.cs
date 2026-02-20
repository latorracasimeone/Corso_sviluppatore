//LEZIONE 11 METODI DIZIONARI
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
dizionario[1] = "uno aggiornato";//NON MI FUNZIONA MODIFICA CON
//DIZIONARIO.ADD COME SCRITTO ALL'INIZIO NELLE DISPENSE!!!!!!!!!!!!!
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


// verifico se in dizionario esiste la chiave 1
bool esisteChiave = dizionario.ContainsKey(1); // true
// verifico se in dizionario esiste la chiave 6
bool esisteChiave6 = dizionario.ContainsKey(6); // false
//li stampo a video
Console.WriteLine($"La chiave 1 esiste? {esisteChiave}");
Console.WriteLine($"La chiave 5 esiste? {dizionario.ContainsKey(5)}");
Console.WriteLine($"La chiave 6 esiste? {esisteChiave6}");
//DOMANDA: a cosa servere scrivere il bool con la variabile, 
//se scrivendo direttamente il tutto nel WriteLine come è stato fatto
//per la chiave 5 abbiamo comunque la risposta?

Console.WriteLine($"Il valore 'uno aggiornato' esiste nel dizionario? {dizionario.ContainsValue("uno aggiornato")}"); // true
Console.WriteLine($"Il valore 'sei' esiste nel dizionario? {dizionario.ContainsValue("sei")}"); // false

// provo a ottenere il valore associato alla chiave 1
if (dizionario.TryGetValue(1, out string valore))
{
    Console.WriteLine($"Il valore associato alla chiave 1 è: {valore}");
}
else
{
    Console.WriteLine("La chiave 1 non esiste nel dizionario.");
}


// rimuovo l'elemento con chiave 2
dizionario.Remove(2); // rimuove l'elemento con chiave 2
// rimuovo l'elemento con chiave 6 (non esiste)
dizionario.Remove(5); // non fa nulla

// dichiaro un dizionario string string
Dictionary<string, string> dizionarioString = new Dictionary<string, string>()
{
    { "chiave1", "valore1" },
    { "chiave2", "valore2" },
    { "chiave3", "valore3" }
};
// rimuovo l'elemento con chiave "chiave2"
dizionarioString.Remove("chiave2"); // rimuove l'elemento con chiave "chiave2"

// rimuovo tutti gli elementi dal dizionario
dizionario.Clear(); // il dizionario è vuoto


dizionario.Add(1, "Timone");
dizionario.Add(2, "NOOOOOOO");

Console.WriteLine("DAJEEEEEEEEEEEEEEEEEEEE");
// modifico il valore associato alla chiave 1
dizionario[1] = "uno modificato";
Console.WriteLine(dizionario[1]); // output: "uno modificato"

Console.WriteLine(dizionario[2]);//STAMPO ELEMENTO DEL DIZIONARIO!

Console.WriteLine(dizionarioString["chiave1"]);

foreach (KeyValuePair<int, string> kvp in dizionario)//accesso a chiavi e valori presenti nel dizionario
{
    Console.WriteLine($"Chiave: {kvp.Key}, Valore: {kvp.Value}");
}

Console.WriteLine("3333333333333333333333");

foreach (var kvp in dizionario)//prediligiamo var per semplificare la sintassi
{
    Console.WriteLine($"Chiave: {kvp.Key}, Valore: {kvp.Value}");
}


//COLLEZIONI:
// dichiaro un dizionario int List<string>
Dictionary<int, List<string>> dizionarioListe = new Dictionary<int, List<string>>()
{
    { 1, new List<string> { "nome", "prezzo" } },
    { 2, new List<string> { "nome" } },
    { 3, new List<string> { "nome", "prezzo", "quantita" } }
};
// aggiungo un elemento alla lista associata alla chiave 1
dizionarioListe[1].Add("quantita");
// posso aggiungere un elemento alla chiave 4
dizionarioListe.Add(4, new List<string> { "nome", "prezzo", "quantita" });
// stampo il dizionario
foreach (var kvp in dizionarioListe)
{
    // qui abbiamo messo kvp per "key-value pair" che è una convenzione però possiamo usare quello che vogliamo
    Console.WriteLine($"Chiave: {kvp.Key}, Valori: {string.Join(", ", kvp.Value)}");
}
// Output:
// Chiave: 1, Valori: nome, prezzo, quantita
// Chiave: 2, Valori: nome
// Chiave: 3, Valori: nome, prezzo, quantita
// Chiave: 4, Valori: nome, prezzo, quantita


//COLLEZIONI: DIZIONARIO DI DIZIONARI

// dichiaro un dizionario int Dictionary<string, string>
Dictionary<int, Dictionary<string, string>> dizionarioDizionari = new Dictionary<int, Dictionary<string, string>>()
{
    { 1, new Dictionary<string, string> { { "nome", "prodotto1" }, { "prezzo", "10" } } },
    { 2, new Dictionary<string, string> { { "nome", "prodotto2" }, { "prezzo", "20" } } },
    { 3, new Dictionary<string, string> { { "nome", "prodotto3" }, { "prezzo", "30" } } }
};
// aggiungo un elemento al dizionario associato alla chiave 1
dizionarioDizionari[1].Add("quantita", "100");
// posso aggiungere un elemento alla chiave 4
dizionarioDizionari.Add(4, new Dictionary<string, string> { { "nome", "prod4" }, { "prezzo", "4" }, { "quantita", "2" } } );
// stampo il dizionario
foreach (var kvp in dizionarioDizionari)
{
    Console.WriteLine($"Chiave: {kvp.Key}");
    foreach (var kvpInterno in kvp.Value)
    {
        Console.WriteLine($"  Chiave interna: {kvpInterno.Key}, Valore interno: {kvpInterno.Value}");
    }
}
// Output:
// Chiave: 1
//   Chiave interna: nome, Valore interno: prodotto1
//   Chiave interna: prezzo, Valore interno: 10
//   Chiave interna: quantita, Valore interno: 100


