namespace AssetManagementService.Models;
public class Trade
{
    public Guid Id { get; set; }
    public Asset AssetId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime TradeDate { get; set; }
}