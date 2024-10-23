using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Entities;

public class ToDoContext : DbContext
{
    public DbSet<ToDo> ToDoItems { get; set; }

    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {

    }



}