using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("camarero")]
    public partial class Camarero : Usuario
    {
        private static String Rol = "camarero";
        public Camarero(String nombre, String apellidos, String nss, string? username, String password)
            : base(nombre, apellidos, nss, username, password,Rol)
        {
            Comanda = new HashSet<Comanda>();
        }
        
        [InverseProperty("IdCamareroNavigation")]
        public virtual ICollection<Comanda> Comanda { get; set; }

        [InverseProperty("IdCamareroNavigation")]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
