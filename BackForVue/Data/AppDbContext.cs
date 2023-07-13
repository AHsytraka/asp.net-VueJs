using Microsoft.EntityFrameworkCore;
using BackForVue.Models;

namespace BackForVue.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
    {
        
    }

    public DbSet<Employe> Employes => Set<Employe>();
}