namespace AssetManagementService.Models;

public class PortfolioSnapshotAsset
{
    public Guid PortfolioSnapshotId { get; set; }
    public PortfolioSnapshot PortfolioSnapshot { get; set; }
    public Guid AssetId { get; set; }
    public Asset Asset { get; set; }
}