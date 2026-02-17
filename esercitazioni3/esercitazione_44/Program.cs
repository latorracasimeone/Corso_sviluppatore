//Prima parte lezione 08
string nome = "Simeone";
int lunghezza = nome.Length; //.Length è il metodo di stringa che ci 
//permette di vedere quanti caratteri compongono la stringa testuale
Console.WriteLine(lunghezza); 

Console.WriteLine(string.IsNullOrWhiteSpace(nome)); // output: false

Console.WriteLine(string.IsNullOrEmpty(nome)); // output: false

Console.WriteLine(nome.ToLower()); // output: simeone

Console.WriteLine(nome.ToUpper()); // output: SIMEONE

Console.WriteLine(nome.Trim()); // output: Simeone (rimuove gli spazi bianchi all'inizio e alla fine della stringa)

string sostituzione = nome.Replace("Simeone", "Cognome");
Console.WriteLine(sostituzione); // output: Cognome

string sottostringa = nome.Substring(0, 4); // estrae i primi 4 caratteri di nome
Console.WriteLine(sottostringa); // output: Sime

string nomeDaCercare = "ime";
Console.WriteLine(nome.Contains(nomeDaCercare)); // output: true

string inizioDaCercare = "Sim";
Console.WriteLine(nome.StartsWith(inizioDaCercare)); // output: true

string fineDaCercare = "one";
Console.WriteLine(nome.EndsWith(fineDaCercare)); // output: true

string nomeCompletoInterpolato = $"{nome} Latorraca";
Console.WriteLine(nomeCompletoInterpolato); // output: Simeone Cognome1
    