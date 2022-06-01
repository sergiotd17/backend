using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiRest.Entities;

namespace ApiRest.Context
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camarero> Camareros { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Cocinero> Cocineros { get; set; } = null!;
        public virtual DbSet<Comanda> Comanda { get; set; } = null!;
        public virtual DbSet<Gerente> Gerentes { get; set; } = null!;
        public virtual DbSet<Mesa> Mesas { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            var users = modelBuilder.Entity<Usuario>();
            users.ToTable("Usuario");
            users.HasKey(u => u.Id);
            users.HasAlternateKey(u => u.Username);

            var camarero = modelBuilder.Entity<Camarero>();
            camarero.ToTable("Camarero");

            var cocinero = modelBuilder.Entity<Cocinero>();
            cocinero.ToTable("Cocinero");

            var gerente = modelBuilder.Entity<Gerente>();
            gerente.ToTable("Gerente");

            var categoria = modelBuilder.Entity<Categoria>();
            categoria.ToTable("Categoria");
            categoria.HasKey(c => c.Id);

            var producto = modelBuilder.Entity<Producto>();
            producto.ToTable("Producto");
            producto.HasKey(c => c.Id);

            var reserva = modelBuilder.Entity<Reserva>();
            reserva.ToTable("Reserva");
            reserva.HasKey(c => c.Id);

            var comanda = modelBuilder.Entity<Comanda>();
            comanda.ToTable("Comanda");
            comanda.HasKey(c => c.Id);

            var pedido = modelBuilder.Entity<Pedido>();
            pedido.ToTable("Pedido");
            pedido.HasKey(c => c.Id);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
