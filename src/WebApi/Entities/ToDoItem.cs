using System.Text.Json.Serialization;

namespace webapi.Entities;

public class ToDoItem : AuditableBaseEntity<Guid>
{
    public string Text { get; set; }
    public Guid ToDoListId { get; set; }
    [JsonIgnore]
    public ToDoList ToDoList { get; set; }
    public bool IsDone { get; set; } = false;

    private ToDoItem(string text, Guid toDoListId) : base()
    {
        Text = text;
        ToDoListId = toDoListId;
    }

    public static ToDoItem Create(string text, Guid toDoListId)
    {
        return new ToDoItem(text, toDoListId);
    }
}
