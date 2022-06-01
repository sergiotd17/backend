using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("producto")]
    [Index("IdCat", Name = "fk_catProd")]
    public partial class Producto
    {
        public Producto()
        {
            Comanda = new HashSet<Comanda>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Column("precio")]
        [Precision(4, 2)]
        public decimal Precio { get; set; }
        [Column("id_cat")]
        public long IdCat { get; set; }

        [ForeignKey("IdCat")]
        [InverseProperty("Productos")]
        public virtual Categoria IdCatNavigation { get; set; } = null!;
        [InverseProperty("IdProductoNavigation")]
        public virtual ICollection<Comanda> Comanda { get; set; }
    }
}
