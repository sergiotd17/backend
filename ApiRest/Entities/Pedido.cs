using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("pedido")]
    [Index("IdMesa", Name = "fk_idmesa")]
    public partial class Pedido
    {
        public Pedido()
        {
            Comanda = new HashSet<Comanda>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("fecha", TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        [Column("precio_total")]
        [Precision(5, 2)]
        public decimal PrecioTotal { get; set; }
        [Column("estado")]
        public EstadosPedido Estado { get; set; }
        [Column("id_mesa")]
        public long IdMesa { get; set; }
        [Column("id_camarero")]
        public long? IdCamarero { get; set; }

        [ForeignKey("IdCamarero")]
        [InverseProperty("Pedidos")]
        public virtual Camarero? IdCamareroNavigation { get; set; }
        [ForeignKey("IdMesa")]
        [InverseProperty("Pedidos")]
        public virtual Mesa IdMesaNavigation { get; set; } = null!;
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<Comanda> Comanda { get; set; }
        public enum EstadosPedido
        {
            Pendiente,
            Pagado
        }
    }
}
