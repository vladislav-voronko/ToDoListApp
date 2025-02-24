namespace ToDoListApp.Models;
public class ToDoItemUpdateDto
{
    public string? Title { get; set; }
    public bool? IsCompleted { get; set; }
    public Guid? CategoryId { get; set; }
}