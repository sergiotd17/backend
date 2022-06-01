namespace ApiRest.DTO;

public class PedidoCreationDTO
{
    public long Id { get; set; }
    public DateTime? Fecha { get; set; }
    public decimal PrecioTotal { get; set; }
    public string? Estado { get; set; }
    public long IdCamarero { get; set; }
    public long IdMesa { get; set; }
}