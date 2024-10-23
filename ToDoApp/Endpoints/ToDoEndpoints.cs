using Microsoft.EntityFrameworkCore;
using ToDoApp.Dtos;
using ToDoApp.Entities;
using ToDoApp.Mapping;

namespace ToDoApp.Endpoints;

public static class ToDoEndpoints
{


    public static RouteGroupBuilder RegisterEndpoints(this WebApplication app)
    {
        var toDoGroup = app.MapGroup("todos");

        toDoGroup.MapGet("/{id:int}", ToDoEndpoints.GetAsync).WithName("GetToDoEndpoint");
        toDoGroup.MapGet("/", ToDoEndpoints.GetAllAsync);
        toDoGroup.MapPost("/", ToDoEndpoints.AddAsync);
        toDoGroup.MapPut("/{id:int}", ToDoEndpoints.UpdateAsync);
        toDoGroup.MapDelete("/{id}", ToDoEndpoints.DeleteAsync);
    
        return toDoGroup;
    }


    private static async Task<IResult> GetAsync(ToDoContext dbContext, int id)
    {
        var todo = await dbContext.ToDoItems.FindAsync(id);
        return todo is null ? Results.NotFound() : Results.Ok(todo);
    }

    private static async Task<IResult> GetAllAsync(ToDoContext dbContext)
    {
        var results = await dbContext.ToDoItems.Select(x => x).ToListAsync();
        return Results.Ok(results);
    }

    private static async Task<IResult> AddAsync(ToDoContext dbContext, AddItemDto dto)
    {
        ToDo todo = dto.ToEntity(); 
        await dbContext.ToDoItems.AddAsync(todo);
        await dbContext.SaveChangesAsync();
        return Results.CreatedAtRoute("GetToDoEndpoint", new {id = todo.Id}, dto);

    }

    private static async Task<IResult> UpdateAsync(ToDoContext dbContext, ToDo toDo)
    {

        var existingTodo = await dbContext.ToDoItems.FindAsync(toDo.Id);
        if (existingTodo is null)
        {
            return Results.NotFound();
        }
        
        dbContext.Entry(existingTodo).CurrentValues.SetValues(toDo);

        await dbContext.SaveChangesAsync(); 
        
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteAsync(ToDoContext dbContext, int id)
    {

        await dbContext.ToDoItems.Where(todo => todo.Id == id).ExecuteDeleteAsync();
        return Results.NoContent();
    }

}