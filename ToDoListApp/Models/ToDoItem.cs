namespace ToDoListApp.Models;
public class ToDoItem{
    public Guid Id {get; set;}
    public string? Title { get; set; }
    public bool IsCompleted { get; set; }

    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }
}