namespace AssetManagementService.Models;

public class PriceSnapshot
{
    public Guid Id { get; set; }
    public Guid AssetId { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public Asset? Asset { get; set; }
}