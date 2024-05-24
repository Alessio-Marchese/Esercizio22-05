namespace Shared.DTOS.ToDoLists.AddItem
{
    public record class Request(Guid Id, string Text);
    public record class Response(Guid Id);
}
