using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("comanda")]
    [Index("IdCamarero", Name = "fk_camarerocomanda")]
    [Index("IdCocinero", Name = "fk_cocinerocomanda")]
    [Index("IdPedido", Name = "fk_pedidocomanda")]
    [Index("IdProducto", Name = "fk_productocomanda")]
    public partial class Comanda
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("id_camarero")]
        public long IdCamarero { get; set; }
        [Column("id_cocinero")]
        public long? IdCocinero { get; set; }
        [Column("id_producto")]
        public long IdProducto { get; set; }
        [Column("id_pedido")]
        public long IdPedido { get; set; }
        [Column("descripcion")]
        [StringLength(50)]
        public string? Descripcion { get; set; }
        [Column("estado")]
        public EstadosComanda Estado { get; set; }

        [ForeignKey("IdCamarero")]
        [InverseProperty("Comanda")]
        public virtual Camarero IdCamareroNavigation { get; set; } = null!;
        [ForeignKey("IdCocinero")]
        [InverseProperty("Comanda")]
        public virtual Cocinero? IdCocineroNavigation { get; set; }
        [ForeignKey("IdPedido")]
        [InverseProperty("Comanda")]
        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
        [ForeignKey("IdProducto")]
        [InverseProperty("Comanda")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }

    public enum EstadosComanda
    {
        Pendiente,
        Preparando,
        Preparado,
        Entregado
    }
}
