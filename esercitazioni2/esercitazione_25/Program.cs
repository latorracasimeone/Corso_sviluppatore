bool a = false;
bool b = true;
bool andResult = a && b;
bool orResult = a || b;
bool notAv = !a;
Console.Write($"Date A falsa e B vera, sono entrambe vere? {andResult}. ");
Console.WriteLine($"Sono almeno una vera? {orResult}.");
Console.WriteLine($"A al contrario è {notAv}.");