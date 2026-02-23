//LEZIONE 13 Funzioni

// funzione void
void Stampa()
{
    // corpo della funzione
    Console.WriteLine("funzione void");
}

// funzione void con parametri
void NomeFunzione(string parametro1, int parametro2)
{
    // corpo della funzione
}

// chiamata della funzione
NomeFunzione("parametro1", 123);



// funzione con ritorno
int FunzioneInt()
{
    // corpo della funzione
    return 0; // valore di ritorno
}

string FunzioneString()
{
    // corpo della funzione
    return "Ciao"; // valore di ritorno
}

bool FunzioneBool()
{
    // corpo della funzione
    return true; // valore di ritorno
}



// funzione con ritorno e parametri
int Somma(int a, int b)
{
    return a + b; // restituisco la somma dei due numeri
}



// funzione che somma tutti i numeri in un array
int SommaArray(int[] numeri)
{
    int somma = 0; // variabile per tenere traccia della somma
    foreach (int numero in numeri) // ciclo attraverso ogni numero nell'array
    {
        somma += numero; // aggiungo il numero per il quale sto iterando alla somma
    }
    return somma; // restituisco la somma totale
}

int[] numeri = { 1, 2, 3, 4, 5 }; // array di numeri da sommare
int risultato = SommaArray(numeri); // passo l'array alla funzione SommaArray

Console.WriteLine($"La somma dei numeri nell'array è: {risultato}"); // stampo il risultato della somma



