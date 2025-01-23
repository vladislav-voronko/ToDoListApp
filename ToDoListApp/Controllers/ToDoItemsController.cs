using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Models;

[Route("api/[controller]")]
[ApiController]
public class ToDoItemsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ToDoItemsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll(){
        try{
            var items = await _context.ToDoItems.ToListAsync();
            return Ok(items);
        }
        catch (Exception e){
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id){
        
        var item = await _context.ToDoItems.FindAsync(id);
        if(item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpGet]
    [Route("search")]
    public async Task<ActionResult> GetAllByTitlePaginated([FromQuery] string title, int page = 1, int pageSize = 10){

        if (string.IsNullOrWhiteSpace(title))
            return BadRequest("Title parameter is required.");

        var totalItems = await _context.ToDoItems
            .Where(x => EF.Functions.Like(x.Title, $"%{title}%"))
            .CountAsync();

        if (totalItems == 0)
            return NotFound("No tasks found matching the specified title.");

        var items = await _context.ToDoItems
            .Where(x => EF.Functions.Like(x.Title, $"%{title}%"))
            .OrderBy(b => b.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if(!items.Any())
            return NotFound("No tasks found matching the specified title.");

        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        
        return Ok(new{
            items,
            totalItems,
            totalPages,
            currentPage = page
        });
    }


    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] ToDoItemCreateDto toDoItemCreateDto){
        var toDoItem = new ToDoItem
        {
            Title = toDoItemCreateDto.Title,
            IsCompleted = toDoItemCreateDto.IsCompleted
        };
        _context.Add(toDoItem);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = toDoItem.Id}, toDoItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(int id, [FromBody] ToDoItemUpdateDto toDoItemUpdateDto){
        var toDoItem = await _context.ToDoItems.FindAsync(id);

        if (toDoItem == null)
        {
            return NotFound();
        }

        toDoItem.Title = toDoItemUpdateDto.Title;
        toDoItem.IsCompleted = toDoItemUpdateDto.IsCompleted;

        _context.ToDoItems.Update(toDoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id){
        var item = await _context.ToDoItems.FindAsync(id);
        if(item == null)
            return NotFound();
        _context.ToDoItems.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}