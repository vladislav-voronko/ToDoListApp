using AssetManagementService.Interfaces;
using AssetManagementService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AssetsController : ControllerBase
{
    private readonly IAssetService _assetService;
    public AssetsController(IAssetService assetService)
    {
        _assetService = assetService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Asset>>> GetAll()
    {
        var assets = await _assetService.GetAllAsync();
        return Ok(assets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Asset>> GetById(Guid id)
    {
        var asset = await _assetService.GetByIdAsync(id);
        if (asset == null)
            return NotFound();
        return Ok(asset);
    }

    [HttpPost]
    public async Task<ActionResult<Asset>> Create([FromBody] Asset asset)
    {
        var created = await _assetService.CreateAsync(asset);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Asset asset)
    {
        var result = await _assetService.UpdateAsync(id, asset);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _assetService.DeleteAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}