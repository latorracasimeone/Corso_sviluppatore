//LEZIONE 12: DATE

DateTime birthDate = new DateTime(1999, 1, 21, 9, 0, 0);
// Il costruttore di DateTime accetta tre parametri: anno, mese e giorno. I 3 parametri opzionali sono: ore, minuti e secondi. Se non vengono specificati, vengono impostati a 0.
Console.WriteLine($"Sei nato il {birthDate}");

DateTime today = DateTime.Today; // Oggi
Console.WriteLine($"Oggi è {today}"); //come mai se attinge dal sistema operativo, 
//non mostra anche l'ora? Perché DateTime.Today restituisce solo la data senza l'ora. Se vuoi includere anche l'ora, puoi usare DateTime.Now invece di DateTime.Today.
Console.WriteLine($"Oggi è {today.ToShortDateString()}");// stampa la data in formato breve gg/MM/yyyy
Console.WriteLine($"Oggi è {today.ToLongDateString()}");// stampa la data in formato lungo "giorno della settimana, numero del giorno, nome del mese, anno in numero"
Console.WriteLine($"Oggi è {today.ToString("dd/MM/yyyy")}");// stampa la data in formato personalizzato, in questo caso "gg/MM/yyyy"
Console.WriteLine($"oggi è {today.ToString("MM/dd/yyyy")}");//ulteriore esempio, stavolta ispirato alle date inglesi.
Console.WriteLine($"oggi è {today.ToString("dddd, dd MM yyyy")}");// ulteriore esempio, stavolta con giorno della settimana incluso.

//oppure
DateTime oggieadesso = DateTime.Now; // Oggi con ora esatta
Console.WriteLine($"Adesso è il {oggieadesso}"); // mostra data e ora
Console.WriteLine($"Adesso è {oggieadesso.ToLongDateString()}");// mostra solo la data in formato lungo
//se volessi mostrare anche l'ora, dovrei usare oggieadesso.ToString("dddd, dd MMM yyyy HH:mm:ss") per includere anche l'ora, i minuti e i secondi.
Console.WriteLine($"Adesso è {oggieadesso.ToString("dddd, dd MMM yyyy HH:mm:ss")}");

DateTime domani = today.AddDays(1);
Console.WriteLine($"Domani è: {domani}");
DateTime ieri = today.AddDays(-1);
Console.WriteLine($"Ieri era: {ieri:dddd}");
//oppure
DateTime domaniPreciso = oggieadesso.AddDays(1);
Console.WriteLine($"Domani è: {domaniPreciso}");
DateTime ieriPreciso = oggieadesso.AddDays(-1);
Console.WriteLine($"Ieri era: {ieriPreciso:dddd}");//non cambia nulla rispetto a ieri standard, perché in questo caso viene stampato a schermo solo il giorno della settimana.
Console.WriteLine($"Ieri precisamente era {ieriPreciso}");

Console.WriteLine(today.GetType()); // output: System.DateTime (stampa il tipo di dato di today, che è DateTime)

Console.WriteLine("Inserire data di nascita (formato: gg/MM/yyyy):");
string dateString = Console.ReadLine(); // chiede all'utente di inserire una data come stringa 
DateTime date = DateTime.Parse(dateString); // Converte la stringa in un oggetto DateTime
Console.WriteLine($"La data inserita è: {date.ToShortDateString()}");