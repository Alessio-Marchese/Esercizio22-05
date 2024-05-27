namespace Shared.DTOS.ToDoItems.Update;

public record class Request(Guid id, bool IsDone);
public record class Response();
