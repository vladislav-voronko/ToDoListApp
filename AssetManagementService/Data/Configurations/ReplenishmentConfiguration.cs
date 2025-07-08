using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AssetManagementService.Models;

namespace AssetManagementService.Data.Configurations;
public class ReplenishmentConfiguration : IEntityTypeConfiguration<Replenishment>
{
    public void Configure(EntityTypeBuilder<Replenishment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Amount).IsRequired();
        builder.Property(x => x.Date).IsRequired();

        builder.HasOne(x => x.Asset)
            .WithMany(x => x.Replenishments)
            .HasForeignKey(x => x.AssetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}