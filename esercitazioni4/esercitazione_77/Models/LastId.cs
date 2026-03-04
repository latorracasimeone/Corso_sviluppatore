public class LastId
{
    [Range(0, int.MaxValue, ErrorMessage = "L'Id deve essere un numero intero positivo")]
    public int Id { get; set; }
}
