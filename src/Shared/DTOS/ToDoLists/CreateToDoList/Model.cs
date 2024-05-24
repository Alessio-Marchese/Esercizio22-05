namespace Shared.DTOS.ToDoLists.CreateToDoList;
public record Request(string title);
public record Response(Guid id);
