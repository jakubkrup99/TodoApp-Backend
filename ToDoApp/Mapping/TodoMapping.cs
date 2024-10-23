using ToDoApp.Dtos;
using ToDoApp.Entities;

namespace ToDoApp.Mapping;

public static class TodoMapping
{

    public static ToDo ToEntity(this AddItemDto dto)
    {
        return new ToDo()
        {
            Description = dto.Description,
            IsCompleted = dto.IsCompleted
        };
    }

}