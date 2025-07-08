using AssetManagementService.Models;

namespace AssetManagementService.Interfaces;

public interface IAssetService
{
    Task<List<Asset>> GetAllAsync();
    Task<Asset?> GetByIdAsync(Guid id);
    Task<Asset> CreateAsync(Asset asset);
    Task<bool> UpdateAsync(Guid id, Asset asset);
    Task<bool> DeleteAsync(Guid id);
}