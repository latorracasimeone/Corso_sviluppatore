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



// funzione che stampa un messaggio
void StampaMessaggio(string messaggio)
{
    Console.WriteLine(messaggio); // stampo il messaggio passato come parametro
}

// funzione che richiama la funzione StampaMessaggio
void StampaMessaggioConPrefisso(string messaggio)
{
    string prefisso = "Prefisso: "; // definisco un prefisso da aggiungere al messaggio
    StampaMessaggio($"{prefisso}{messaggio}");
}

// chiamata della funzione StampaMessaggioConPrefisso
StampaMessaggioConPrefisso("Questo è un messaggio con prefisso");



// funzione che calcola il doppio di un numero
int Doppio(int numero)
{
    return numero * 2; // restituisco il doppio del numero
}
// funzione che raddoppia il risultato della funzione Doppio
int Quadruplo(int numero)
{
    int doppio = Doppio(numero); // chiamo la funzione Doppio per ottenere il doppio del numero
    return doppio * 2; // restituisco il raddoppio del doppio
}
// funzione che stampa il risultato della funzione Quadruplo
void StampaQuadruplo(int numero)
{
    int quadruplo = Quadruplo(numero); // chiamo la funzione Quadruplo per ottenere il quadruplo del numero
    Console.WriteLine($"Il quadruplo di {numero} è: {quadruplo}"); // stampo il risultato
}
// chiamata della funzione StampaQuadruplo
Console.WriteLine("Inserisci un numero:"); // chiedo all'utente di inserire un numero
string input = Console.ReadLine(); // leggo un numero da input
int numero = int.Parse(input); // converto l'input in un intero
StampaQuadruplo(numero); // passo il numero letto all'utente alla funzione StampaQuadruplo

