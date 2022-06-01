using ApiRest.Entities;

namespace ApiRest.DTO;

public class CategoriaDTO
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public ICollection<ProductoInCategoriaDTO>? Productos { get; set; }

}