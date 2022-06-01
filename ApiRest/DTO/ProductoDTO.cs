namespace ApiRest.DTO;

public class ProductoDTO
{
    public long Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public long IdCat { get; set; }
    public virtual CategoriaCreationDTO IdCatNavigation { get; set; }
    public virtual ICollection<ComandaInProductoDTO> Comanda { get; set; }
}