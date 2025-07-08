namespace AssetManagementService.Models;
public class GeneratedReport
{
    public Guid Id { get; set; }
    public Guid PortfolioSnapshotId { get; set; }
    public PortfolioSnapshot PortfolioSnapshot { get; set; }
    public DateTime Created { get; set; }
    public string FilePath { get; set; }
}