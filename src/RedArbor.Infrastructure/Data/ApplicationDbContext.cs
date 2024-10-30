using Microsoft.EntityFrameworkCore;
using RedArbor.Domain.Models;

namespace RedArbor.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
}
