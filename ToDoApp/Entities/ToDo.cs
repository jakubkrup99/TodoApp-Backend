namespace ToDoApp.Entities;

public class ToDo
{
    public int Id { get; set; } = new();

    public DateOnly DateWhenAdded { get; set; }

    public TimeOnly TimeWhenAdded { get; set; }

    public string Description { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? WhenFinished { get; set; }


}