namespace AssetManagementService.Models;

public class PortfolioSnapshot
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public ICollection<PortfolioSnapshotAsset> PortfolioSnapshotAssets { get; set; } = new List<PortfolioSnapshotAsset>();
    public ICollection<GeneratedReport> GeneratedReports { get; set; } = new List<GeneratedReport>();
}