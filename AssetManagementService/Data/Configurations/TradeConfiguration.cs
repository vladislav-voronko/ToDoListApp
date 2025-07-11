using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AssetManagementService.Models;

namespace AssetManagementService.Data.Configurations;
public class TradeConfiguration : IEntityTypeConfiguration<Trade>
{
    public void Configure(EntityTypeBuilder<Trade> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Amount).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Total).IsRequired();
        builder.Property(x => x.Date).IsRequired();

        builder.HasOne(x => x.Asset)
            .WithMany(x => x.Trades)
            .HasForeignKey(x => x.AssetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}