using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AssetManagementService.Models;

namespace AssetManagementService.Data.Configurations;
public class PortfolioSnapshotAssetConfiguration : IEntityTypeConfiguration<PortfolioSnapshotAsset>
{
    public void Configure(EntityTypeBuilder<PortfolioSnapshotAsset> builder)
    {
        builder.HasKey(x => new { x.PortfolioSnapshotId, x.AssetId });

        builder.HasOne(x => x.PortfolioSnapshot)
            .WithMany(x => x.PortfolioSnapshotAssets)
            .HasForeignKey(x => x.PortfolioSnapshotId);

        builder.HasOne(x => x.Asset)
            .WithMany(x => x.PortfolioSnapshotAssets)
            .HasForeignKey(x => x.AssetId);
    }
}