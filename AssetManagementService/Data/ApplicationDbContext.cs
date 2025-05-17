using Microsoft.EntityFrameworkCore;
using AssetManagementService.Models;
using AssetManagementService.Data.Configurations;

namespace AssetManagementService.Data;
public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Trade> Trades { get; set; }
    public DbSet<Replenishment> Replenishments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new AssetConfiguration());
        modelBuilder.ApplyConfiguration(new TradeConfiguration());
        modelBuilder.ApplyConfiguration(new ReplenishmentConfiguration());

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Asset>()
            .HasMany(e => e.Trades)
            .WithOne(e => e.Asset)
            .HasForeignKey(e => e.AssetId)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);
    }
}