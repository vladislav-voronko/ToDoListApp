using AssetManagementService.Models;
using AssetManagementService.Data;
using Microsoft.EntityFrameworkCore;
using AssetManagementService.Interfaces;

public class AssetService : IAssetService
{
    private readonly ApplicationDbContext _context;
    public AssetService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Asset>> GetAllAsync()
        => await _context.Assets
            .Include(a => a.Trades)
            .Include(a => a.Replenishments)
            .Include(a => a.PriceSnapshots)
            .ToListAsync();

    public async Task<Asset?> GetByIdAsync(Guid id)
        => await _context.Assets
            .Include(a => a.Trades)
            .Include(a => a.Replenishments)
            .Include(a => a.PriceSnapshots)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Asset> CreateAsync(Asset asset)
    {
        _context.Assets.Add(asset);
        await _context.SaveChangesAsync();
        return asset;
    }

    public async Task<bool> UpdateAsync(Guid id, Asset asset)
    {
        var existing = await _context.Assets.FindAsync(id);
        if (existing == null) return false;
        existing.Name = asset.Name;
        existing.Symbol = asset.Symbol;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null) return false;
        _context.Assets.Remove(asset);
        await _context.SaveChangesAsync();
        return true;
    }
}