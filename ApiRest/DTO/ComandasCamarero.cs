namespace ApiRest.DTO
{
    public class ComandasCamarero
    {
        public long Id { get; set; }
        public virtual ProductoInComandaCamareroDTO IdProductoNavigation { get; set; }
        public PedidoyMesaDTO IdPedidoNavigation { get; set; }
        public string? Estado { get; set; }
    }
}
