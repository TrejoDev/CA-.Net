using InterfaceAdpater_Model;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapter_Data;
// ! Implementacion de ORM adapter
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<BeerModel> Beers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BeerModel>().ToTable("Beer");
    }
}
