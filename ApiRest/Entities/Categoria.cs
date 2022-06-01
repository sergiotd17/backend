using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("categoria")]
    public partial class Categoria
    {
        public Categoria(string nombre)
        {
            Nombre = nombre;
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("IdCatNavigation")]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
