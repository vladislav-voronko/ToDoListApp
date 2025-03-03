using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Models;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll(){
        try{
            var categories = await _context.Categories.Include(item => item.ToDoItems).ToListAsync();
            return Ok(categories);
        }
        catch (Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id){
        
        var category = await _context.Categories.Include(item => item.ToDoItems).Where(item => item.Id == id).FirstOrDefaultAsync();
        if(category == null)
            return NotFound();
        return Ok(category);
    }

    [HttpGet]
    [Route("search")]
    public async Task<ActionResult> GetAllByTitlePaginated([FromQuery] string name, int page = 1, int pageSize = 10){

        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Title parameter is required.");

        var totalItems = await _context.Categories
            .Where(x => EF.Functions.Like(x.Name, $"%{name}%"))
            .CountAsync();

        if (totalItems == 0)
            return NotFound("No tasks found matching the specified name.");

        var items = await _context.Categories
            .Include(item => item.ToDoItems)
            .Where(x => EF.Functions.Like(x.Name, $"%{name}%"))
            .OrderBy(b => b.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if(!items.Any())
            return NotFound("No tasks found matching the specified name.");

        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        
        return Ok(new{
            items,
            totalItems,
            totalPages,
            currentPage = page
        });
    }


    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] CategoryCreateDto categoryCreateDto){
        var category = new Category
        {
            Name = categoryCreateDto.Name,
            Description = categoryCreateDto.Description
        };
        _context.Add(category);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = category.Id}, category);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] CategoryUpdateDto categoryUpdateDto){
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        category.Name = categoryUpdateDto.Name;
        category.Description = categoryUpdateDto.Description;

        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id){
        var category = await _context.Categories.FindAsync(id);
        if(category == null)
            return NotFound();
        
        var itemsToUpdate = _context.ToDoItems.Where(item => item.CategoryId == category.Id).ToList();
        foreach (var item in itemsToUpdate)
        {
            item.CategoryId = Guid.Empty;
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}