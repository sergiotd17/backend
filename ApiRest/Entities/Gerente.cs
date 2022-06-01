using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("gerente")]
    public partial class Gerente : Usuario
    {
        private static String Rol = "gerente";
        public Gerente(String nombre,String apellidos,String nss,string? username,String password)
            :base(nombre, apellidos, nss, username, password,Rol)
        {

        }
        
    }
}
