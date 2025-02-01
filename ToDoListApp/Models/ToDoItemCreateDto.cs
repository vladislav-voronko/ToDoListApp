namespace ToDoListApp.Models;
public class ToDoItemCreateDto{
    public string? Title { get; set; }
    public bool IsCompleted { get; set; }
    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; }
}