namespace AssetManagementService.Models;
public class Asset
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public ICollection<Trade> Trades { get; set; } = new List<Trade>();
}