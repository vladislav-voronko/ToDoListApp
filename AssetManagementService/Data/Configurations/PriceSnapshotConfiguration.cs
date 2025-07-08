using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AssetManagementService.Models;

namespace AssetManagementService.Data.Configurations;
public class PriceSnapshotConfiguration : IEntityTypeConfiguration<PriceSnapshot>
{
    public void Configure(EntityTypeBuilder<PriceSnapshot> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Date).IsRequired();

        builder.HasOne(x => x.Asset)
            .WithMany(x => x.PriceSnapshots)
            .HasForeignKey(x => x.AssetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}