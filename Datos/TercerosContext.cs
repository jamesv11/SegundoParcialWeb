using System;
using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class TercerosContext : DbContext
    {
        public TercerosContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Tercero> Terceros { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pago>()
            .HasOne<Tercero>(c => c.Tercero)
            .WithMany( c => c.ListaPagos)
            .HasForeignKey(c => c.TerceroIdentificacion);

            modelBuilder.Entity<Tercero>()
            .HasKey(t => t.TerceroIdentificacion);
            
        }
    }
}
