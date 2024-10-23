using ToDoApp.Entities;

namespace ToDoApp;

public interface IToDoService
{
    ToDo Get(int id);
    List<ToDo> GetAll();
    void Add(ToDo toDo);
    void Update(ToDo toDo);
    void Delete(int id);    
    

}

public class ToDoService : IToDoService
{
    private readonly Dictionary<int, ToDo> _tasks = new();
    
    
    public ToDo Get(int id)
    {
        return _tasks.GetValueOrDefault(id);
    }

    public List<ToDo> GetAll()
    {
        return _tasks.Values.ToList();
    }

    public void Add(ToDo toDo)
    {
        _tasks[toDo.Id] = toDo;
    }

    public void Update(ToDo toDo)
    {
        if (_tasks.ContainsKey(toDo.Id))
        {
            _tasks[toDo.Id] = toDo;
        }
    }

    public void Delete(int id)
    {
        var toDo = Get(id);
        if (toDo is null)
        {
            return;
        }
        _tasks.Remove(id);
    }
}