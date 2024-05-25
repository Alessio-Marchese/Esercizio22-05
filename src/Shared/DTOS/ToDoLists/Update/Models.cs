using Shared.Entities;

namespace Shared.DTOS.ToDoLists.Update
{
    public record class Request(Guid id, string Title, bool IsDone, List<ToDoItem> ToDoItems);
    public record class Response;
}
