namespace ApiRest.DTO
{
    public class ProductoInComandaCocinero
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public virtual CategoriaCreationDTO IdCatNavigation { get; set; }
    }
}
