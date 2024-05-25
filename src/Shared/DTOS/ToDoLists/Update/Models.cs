using Shared.Entities;

namespace Shared.DTOS.ToDoLists.Update
{
    public record class Request(Guid id, string Title);
    public record class Response;
}
