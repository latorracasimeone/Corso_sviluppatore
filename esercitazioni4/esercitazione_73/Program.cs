//LEZIONE 17 CLASSI CONTATTO
using Newtonsoft.Json


public class Contatto
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Cognome { get; set; } = "";
    public string Telefono { get; set; } = "";
    // proprieta lista di interessi
    public List<string> Interessi { get; set; } = new();
}

public class ContattiController
