using webapi.Entities;

namespace webapi.Features.ToDoLists.Update
{
public record class Request(Guid id, string Title, bool IsDone, List<ToDoItem> ToDoItems);
public record class Response;
}
