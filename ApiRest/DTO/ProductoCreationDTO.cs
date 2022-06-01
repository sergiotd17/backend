namespace ApiRest.DTO;

public class ProductoCreationDTO
{
    public long Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public long IdCat { get; set; }
}