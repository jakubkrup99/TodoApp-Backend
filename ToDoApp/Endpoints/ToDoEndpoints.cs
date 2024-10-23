using ToDoApp.Dtos;
using ToDoApp.Entities;
using ToDoApp.Mapping;

namespace ToDoApp.Endpoints;

public static class ToDoEndpoints
{


    public static RouteGroupBuilder RegisterEndpoints(this WebApplication app)
    {
        var toDoGroup = app.MapGroup("todos");

        toDoGroup.MapGet("/{id:int}", ToDoEndpoints.Get).WithName("GetToDoEndpoint");
        toDoGroup.MapGet("/", ToDoEndpoints.GetAll);
        toDoGroup.MapPost("/", ToDoEndpoints.Add);
        toDoGroup.MapPut("/{id:int}", ToDoEndpoints.Update);
        toDoGroup.MapDelete("/{id}", ToDoEndpoints.Delete);
    
        return toDoGroup;
    }


    public static IResult Get(ToDoContext dbContext, int id)
    {
        var todo = dbContext.ToDoItems.Find(id);
        return todo is null ? Results.NotFound() : Results.Ok(todo);
    }

    public static IResult GetAll(ToDoContext dbContext)
    {
        var results = dbContext.ToDoItems.Select(x => x).ToList();
        return Results.Ok(results);
    }

    public static IResult Add(ToDoContext dbContext, AddItemDto dto)
    {
        ToDo todo = dto.ToEntity();
        dbContext.ToDoItems.Add(todo);
        dbContext.SaveChanges();
        return Results.CreatedAtRoute("GetToDoEndpoint", dto);

    }

    public static IResult Update(IToDoService service, ToDo toDo)
    {

        service.Update(toDo);
        return Results.NoContent();
    }

    public static IResult Delete(IToDoService service, int id)
    {

        service.Delete(id);
        return Results.NoContent();
    }

}