using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AssetManagementService.Models;

namespace AssetManagementService.Data.Configurations;
public class PortfolioSnapshotConfiguration : IEntityTypeConfiguration<PortfolioSnapshot>
{
    public void Configure(EntityTypeBuilder<PortfolioSnapshot> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Date).IsRequired();

        builder.HasMany(x => x.PortfolioSnapshotAssets)
            .WithOne(x => x.PortfolioSnapshot)
            .HasForeignKey(x => x.PortfolioSnapshotId);

        builder.HasMany(x => x.GeneratedReports)
            .WithOne(x => x.PortfolioSnapshot)
            .HasForeignKey(x => x.PortfolioSnapshotId);
    }
}