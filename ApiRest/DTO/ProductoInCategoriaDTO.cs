namespace ApiRest.DTO;

public class ProductoInCategoriaDTO
{
    public long Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
}