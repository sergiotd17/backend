namespace ApiRest.DTO;

public class MesaDTO
{
    public long Id { get; set; }
    public string Estado { get; set; } = null!;
    public string Location { get; set; } = null!;
    public virtual ICollection<PedidoCreationDTO> Pedidos { get; set; }
    public virtual ICollection<ReservaCreationDTO> IdReservas { get; set; }
}