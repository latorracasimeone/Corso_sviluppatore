public class Contatto
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Telefono { get; set; }
    public List<string> Competenze { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}