// PruebaTecnica.Services/Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Tiempo> Tiempos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");  // Ajusta "Usuarios" al nombre real de tu tabla
            modelBuilder.Entity<Actividad>().ToTable("Actividades");  // Ajusta "Actividades" al nombre real de tu tabla
            modelBuilder.Entity<Tiempo>().ToTable("Tiempos");  // Ajusta "Tiempos" al nombre real de tu tabla

            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Actividades)
                .HasForeignKey(a => a.UsuarioId);

            modelBuilder.Entity<Tiempo>()
                .HasOne(t => t.Actividad)
                .WithMany(a => a.Tiempos)
                .HasForeignKey(t => t.ActividadId);
        }

    }
}
