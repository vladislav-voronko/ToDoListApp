namespace AssetManagementService.Models;
public class Trade
{
    public Guid Id { get; set; }
    public Guid AssetId { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public double Amount { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }
    public bool IsReinvested { get; set; }
    public Asset? Asset { get; set; }
}