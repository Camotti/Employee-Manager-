
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //"Recibo toda la configuración necesaria para conectarme a la base de datos."
    {
            
    }

    public DbSet<Employee> Employees {get; set;}
}

