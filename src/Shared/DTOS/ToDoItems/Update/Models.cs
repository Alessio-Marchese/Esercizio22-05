namespace Shared.DTOS.ToDoItems.Update;

public record class Request(Guid id, string Text, bool IsDone);
public record class Response();
