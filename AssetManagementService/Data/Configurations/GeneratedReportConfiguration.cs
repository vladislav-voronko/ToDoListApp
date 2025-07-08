using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AssetManagementService.Models;

namespace AssetManagementService.Data.Configurations;
public class GeneratedReportConfiguration : IEntityTypeConfiguration<GeneratedReport>
{
    public void Configure(EntityTypeBuilder<GeneratedReport> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Created).IsRequired();
        builder.Property(x => x.FilePath).IsRequired().HasMaxLength(500);

        builder.HasOne(x => x.PortfolioSnapshot)
            .WithMany(x => x.GeneratedReports)
            .HasForeignKey(x => x.PortfolioSnapshotId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}