//Lezione 08 - Stringhe: Split e Join
string nomi = "Simeone, Timone, Branca, Sana, Calipari Lucia";
string[] nomiArray = nomi.Split(", ");//divide una stringa in base a 
//un separatore e restituisce un array di stringhe

foreach (string n in nomiArray) // n è un alias per ogni elemento dell array
{
    Console.WriteLine(n);
}



string nomiUniti = string.Join(". ", nomiArray);
Console.WriteLine(nomiUniti); // output: Simeone. Timone. Branca. Sana. Calipari Lucia (unisce gli elementi dell'array in una stringa separata da ". ")


