using Microsoft.EntityFrameworkCore;

namespace HNomi.Entities
{
    public class HNomiContext : DbContext
    {

        public HNomiContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<TipoNominaEntity> TiposNomina { get; set; }
        public DbSet<DetallesTipoNominaEntity> DetallesTipoNomina { get; set; }
        public DbSet<ImpuestosEntity> Impuestos { get; set; }
        public DbSet<TurnosTrabajoEntity> TurnosTrabajo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TipoNominaEntity>().HasKey(n => n.Id);

            modelBuilder.Entity<TipoNominaEntity>().Property(n => n.Id).IsRequired();
            modelBuilder.Entity<TipoNominaEntity>().Property(n => n.Nombre).IsRequired();
            modelBuilder.Entity<TipoNominaEntity>().Property(n => n.Nocturnidad).IsRequired();

            modelBuilder.Entity<TipoNominaEntity>().HasMany<DetallesTipoNominaEntity>("Detalles");


            modelBuilder.Entity<DetallesTipoNominaEntity>().HasKey(d => d.Id);

            modelBuilder.Entity<DetallesTipoNominaEntity>().Property(d => d.Id).IsRequired();
            modelBuilder.Entity<DetallesTipoNominaEntity>().Property(d => d.Nombre).IsRequired();
            modelBuilder.Entity<DetallesTipoNominaEntity>().Property(d => d.TieneRetencion).IsRequired();
            modelBuilder.Entity<DetallesTipoNominaEntity>().Property(d => d.EsPorUnidad).IsRequired();
            modelBuilder.Entity<DetallesTipoNominaEntity>().Property(d => d.TieneRetencion).HasDefaultValue(false);
            modelBuilder.Entity<DetallesTipoNominaEntity>().Property(d => d.EsPorUnidad).HasDefaultValue(true);
            modelBuilder.Entity<DetallesTipoNominaEntity>().Property(d => d.Precio).IsRequired();

            modelBuilder.Entity<DetallesTipoNominaEntity>().HasOne<TipoNominaEntity>(d=>d.Nomina).WithMany(n=>n.Detalles).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ImpuestosEntity>().HasKey(i => i.Id);

            modelBuilder.Entity<ImpuestosEntity>().Property(i => i.Id).IsRequired();
            modelBuilder.Entity<ImpuestosEntity>().Property(i => i.Nombre).IsRequired();
            modelBuilder.Entity<ImpuestosEntity>().Property(i => i.Porcentaje).IsRequired();
            modelBuilder.Entity<ImpuestosEntity>().Property(i => i.Porcentaje).HasDefaultValue(0);

            modelBuilder.Entity<ImpuestosEntity>().HasOne<TipoNominaEntity>(d=>d.Nomina).WithMany(n=>n.Impuestos).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<TurnosTrabajoEntity>().Property(tt => tt.EsTurnoPartido).HasDefaultValue(false);

        }

    }
}
