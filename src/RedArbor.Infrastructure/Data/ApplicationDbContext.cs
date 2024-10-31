using Microsoft.EntityFrameworkCore;
using RedArbor.Domain.Models;

namespace RedArbor.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    // DbSet para la entidad Employee
    public DbSet<Employee> Employees { get; set; }

    // Configuración adicional del modelo (si es necesario)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ejemplo de configuración específica de la entidad Employee
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            // Añade más configuraciones según tus necesidades
        });
    }
}
