namespace ApiRest.DTO;

public class ComandaDTO
{
    public long Id { get; set; }
    public string? Descripcion { get; set; }
    public string? Estado { get; set; }
    public virtual CamareroCreationDTO IdCamareroNavigation { get; set; } = null!;
    public virtual CocineroCreationDTO? IdCocineroNavigation { get; set; }
    public virtual PedidoCreationDTO IdPedidoNavigation { get; set; } = null!;
    public virtual ProductoCreationDTO IdProductoNavigation { get; set; } = null!;
}