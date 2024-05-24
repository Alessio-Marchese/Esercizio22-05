namespace webapi.Features.ToDoItems.Update;

public record class Request(Guid id, string Text, Guid? TodoListId, bool IsDone);
public record class Response();
