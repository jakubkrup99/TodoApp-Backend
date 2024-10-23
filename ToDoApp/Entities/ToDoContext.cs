using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Entities;

public class ToDoContext(DbContextOptions<ToDoContext> options) : DbContext(options)
{
    public DbSet<ToDo> ToDoItems { get; set; }
    
}