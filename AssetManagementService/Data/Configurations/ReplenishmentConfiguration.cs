using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AssetManagementService.Models;

namespace AssetManagementService.Data.Configurations;
public class ReplenishmentConfiguration : IEntityTypeConfiguration<Replenishment>
{
    public void Configure(EntityTypeBuilder<Replenishment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Note).IsRequired().HasMaxLength(200);
    }
}