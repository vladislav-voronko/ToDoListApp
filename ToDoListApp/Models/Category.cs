namespace ToDoListApp.Models;
public class Category{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
}
