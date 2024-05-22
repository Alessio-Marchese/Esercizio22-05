using System.Runtime.CompilerServices;

namespace webapi.Entities;

public class ToDoList : AuditableBaseEntity<Guid>
{ 
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public List<ToDoItem> ToDoItems { get; set; }

    protected ToDoList()
    {

    }

    private ToDoList(Guid id, string title) : base(id)
    {
        Title = title;
        ToDoItems = new();
    }

    public static ToDoList Create(string title)
    {
        return new ToDoList(Guid.NewGuid(), title);
    }

    public void AddToDoItem(string text)
    {
        ToDoItems.Add(ToDoItem.Create(text, this.Id));
    }
}
