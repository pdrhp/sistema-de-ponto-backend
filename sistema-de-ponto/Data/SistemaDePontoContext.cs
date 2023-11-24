using Microsoft.EntityFrameworkCore;
using sistema_de_ponto.Models;

namespace sistema_de_ponto.Data;

public class SistemaDePontoContext : DbContext
{
    public SistemaDePontoContext(DbContextOptions<SistemaDePontoContext> options) : base(options)
    {
        
    }
    
    public DbSet<Employee> Employee { get; set; }
    public DbSet<TimeRecord> TimeRecord { get; set; }
}