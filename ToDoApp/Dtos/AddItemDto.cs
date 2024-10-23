namespace ToDoApp.Dtos;

public record AddItemDto(
    int Id,
    DateOnly DateWhenAdded,
    TimeOnly TimeWhenAdded,
    string Description
    );


