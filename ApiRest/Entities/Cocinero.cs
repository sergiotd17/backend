using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("cocinero")]
    public partial class Cocinero : Usuario
    {
        private static String Rol = "cocinero";
        public Cocinero(String nombre, String apellidos, String nss, string? username, String password)
            : base(nombre, apellidos, nss, username, password,Rol)
        {
            Comanda = new HashSet<Comanda>();
        }
        
        [InverseProperty("IdCocineroNavigation")]
        public virtual ICollection<Comanda> Comanda { get; set; }
    }
}
