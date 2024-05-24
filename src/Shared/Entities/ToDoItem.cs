using Shared.DTOS.ToDoItems.Update;
using Shared.Entities.Common;
using System.Text.Json.Serialization;

namespace Shared.Entities;

public class ToDoItem : AuditableBaseEntity<Guid>
{
    public string Text { get; set; }
    public Guid ToDoListId { get; set; }
    [JsonIgnore]
    public ToDoList ToDoList { get; set; }
    public bool IsDone { get; set; } = false;

    private ToDoItem(Guid id, string text, Guid toDoListId) : base(id)
    {
        Text = text;
        ToDoListId = toDoListId;
    }

    private ToDoItem(string text, Guid toDoListId) : base()
    {
        Text = text;
        ToDoListId = toDoListId;
    }

    public static ToDoItem Create(string text, Guid toDoListId)
    {
        return new ToDoItem(Guid.NewGuid(), text, toDoListId);
    }

    public static ToDoItem CreateNoGuid(string text, Guid toDoListId)
    {
        return new ToDoItem(text, toDoListId);
    }

    public static ToDoItem Update(ToDoItem toDoItem, Request r, ToDoList? toDoList)
    {
        if (!string.IsNullOrWhiteSpace(r.Text))
        {
            toDoItem.Text = r.Text;
        }
        if (toDoList is not null)
        {
            toDoItem.ToDoList = toDoList;
        }
        if (toDoItem.IsDone != r.IsDone)
        {
            toDoItem.IsDone = r.IsDone;
        }
        return toDoItem;
    }
}
