List<string> UnisciListe(List<string> lista1, List<string> lista2)
{
    List<string> listaUnita = new List<string>(); // creo una nuova lista per contenere gli elementi uniti
    listaUnita.AddRange(lista1); // aggiungo tutti gli elementi della prima lista
    listaUnita.AddRange(lista2); // aggiungo tutti gli elementi della seconda lista
    return listaUnita; // restituisco la lista unita
}
void StampaLista(List<string> lista)
{
    foreach (string elemento in lista) // ciclo attraverso ogni elemento nella lista
    {
        Console.WriteLine(elemento); // stampo l'elemento corrente
    }
}
List<string> elenco1 = new List<string> { "Non ho", "Capito" }; // prima lista di stringhe
List<string> elenco2 = new List<string> { "ste", "maledette", "Funzioni" }; // seconda lista di stringhe
List<string> listaUnita = UnisciListe(elenco1, elenco2); // unisco le due liste
StampaLista(listaUnita); // stampo la lista unita



