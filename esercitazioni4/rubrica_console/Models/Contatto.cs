using Newtonsoft.Json;
public class Contatto
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Cognome { get; set; } = "";
    public string Email { get; set; } = "";
    public string Telefono { get; set; } = "";
    public bool Presente { get; set; }
    public List<string> Interessi { get; set; } = new();
}
