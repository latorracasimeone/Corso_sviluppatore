using System.ComponentModel.DataAnnotations;
public class LastId
{
    [Range(0, int.MaxValue, ErrorMessage = "L'ID deve essere un numero intero positivo.")]
    public int Id { get; set; }
}