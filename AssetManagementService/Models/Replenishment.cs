namespace AssetManagementService.Models;
public class Replenishment
{
    public Guid Id { get; set; }
    public Guid AssetId { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public Asset Asset { get; set; }
    public string Note { get; set; }
}