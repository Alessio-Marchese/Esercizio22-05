namespace webapi.Entities;

public class ToDoItem : AuditableBaseEntity<Guid>
{
    public string Text { get; set; }
    public Guid ToDoListId { get; set; }
    public bool IsDone { get; set; } = false;

    private ToDoItem(Guid id, string text, Guid toDoListId) : base(id)
    {
        Text = text;
        ToDoListId = toDoListId;
    }

    public static ToDoItem Create(string text, Guid toDoListId)
    {
        return new ToDoItem(Guid.NewGuid(), text, toDoListId);
    }
}
