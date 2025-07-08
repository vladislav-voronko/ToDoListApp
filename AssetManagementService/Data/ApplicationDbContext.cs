using Microsoft.EntityFrameworkCore;
using AssetManagementService.Models;
using AssetManagementService.Data.Configurations;

namespace AssetManagementService.Data;
public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Trade> Trades { get; set; }
    public DbSet<Replenishment> Replenishments { get; set; }
    public DbSet<PriceSnapshot> PriceSnapshots { get; set; }
    public DbSet<PortfolioSnapshotAsset> PortfolioSnapshotAssets { get; set; }
    public DbSet<PortfolioSnapshot> PortfolioSnapshots { get; set; }
    public DbSet<GeneratedReport> GeneratedReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchemas.Asset);

        modelBuilder.ApplyConfiguration(new AssetConfiguration());
        modelBuilder.ApplyConfiguration(new TradeConfiguration());
        modelBuilder.ApplyConfiguration(new ReplenishmentConfiguration());
        modelBuilder.ApplyConfiguration(new PriceSnapshotConfiguration());
        modelBuilder.ApplyConfiguration(new PortfolioSnapshotAssetConfiguration());
        modelBuilder.ApplyConfiguration(new PortfolioSnapshotConfiguration());
        modelBuilder.ApplyConfiguration(new GeneratedReportConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}