using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("mesa")]
    public partial class Mesa
    {
        public Mesa()
        {
            Pedidos = new HashSet<Pedido>();
            IdReservas = new HashSet<Reserva>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("estado")]
        public EstadosMesa Estado { get; set; }
        [Column("location")]
        public string Location { get; set; }

        [InverseProperty("IdMesaNavigation")]
        public virtual ICollection<Pedido> Pedidos { get; set; }

        [ForeignKey("IdMesa")]
        [InverseProperty("IdMesas")]
        public virtual ICollection<Reserva> IdReservas { get; set; }
        public enum EstadosMesa
        {
            Libre,
            Reservada,
            Ocupada
        }
    }
}
