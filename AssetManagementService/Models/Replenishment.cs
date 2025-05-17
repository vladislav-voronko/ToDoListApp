namespace AssetManagementService.Models;
public class Replenishment
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public string Note { get; set; }
}