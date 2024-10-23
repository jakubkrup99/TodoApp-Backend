namespace ToDoApp.Entities;

public class ToDo
{
    public int Id { get; set; } = new();

    public string Description { get; set; }

    public bool IsCompleted { get; set; }

}