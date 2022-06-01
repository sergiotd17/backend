namespace ApiRest.DTO
{
    public class ComandasCocinero
    {
        public long Id { get; set; }
        public long IdCamarero { get; set; }
        public long? IdCocinero { get; set; }
        public virtual ProductoInComandaCamareroDTO IdProductoNavigation { get; set; }
        public PedidoyMesaDTO IdPedidoNavigation { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }
}
