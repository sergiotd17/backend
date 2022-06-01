namespace ApiRest.DTO;

public class ReservaCreationDTO
{
    public long Id { get; set; }
    public string NombreCliente { get; set; } = null!;
    public int Telefono { get; set; }
    public int CantidadPersonas { get; set; }
    public DateTime HoraFecha { get; set; }
}