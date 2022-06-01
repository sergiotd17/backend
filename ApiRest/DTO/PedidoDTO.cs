namespace ApiRest.DTO;

public class PedidoDTO
{
    public long Id { get; set; }
    public DateTime? Fecha { get; set; }
    public decimal PrecioTotal { get; set; }
    public string? Estado { get; set; }
    public long IdMesa { get; set; }
    public virtual MesaCreationDTO IdMesaNavigation { get; set; } = null!;
    public virtual ICollection<ComandaInPedidoCamareroDTO> Comanda { get; set; }
}