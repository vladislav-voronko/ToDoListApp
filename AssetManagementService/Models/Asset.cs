namespace AssetManagementService.Models;

public class Asset
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public ICollection<Trade> Trades { get; set; } = new List<Trade>();
    public ICollection<Replenishment> Replenishments { get; set; } = new List<Replenishment>();
    public ICollection<PriceSnapshot> PriceSnapshots { get; set; } = new List<PriceSnapshot>();
    public ICollection<PortfolioSnapshotAsset> PortfolioSnapshotAssets { get; set; } = new List<PortfolioSnapshotAsset>();
}