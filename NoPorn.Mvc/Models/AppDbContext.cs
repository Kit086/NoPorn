
using Microsoft.EntityFrameworkCore;

namespace NoPorn.Mvc.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Girl> Girls { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Image>()
            .HasOne<Girl>(i => i.Girl)
            .WithMany(g => g.Images);
            //.HasForeignKey(i => i.GirlId);
    }
}
