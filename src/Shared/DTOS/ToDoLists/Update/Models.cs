using Shared.Entities;

namespace Shared.DTOS.ToDoLists.Update
{
    public record  Request(Guid id, string Title);
    public record  Response;
}
