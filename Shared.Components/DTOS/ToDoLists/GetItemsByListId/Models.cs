namespace Shared.Components.DTOS.ToDoLists.GetItemsByListId;

public record GetItemsByListIdRequest(Guid Id);
public record GetItemsByListIdResponse
{
    public List<ToDoItemDto>? ToDoItems { get; set; }
    public GetItemsByListIdResponse() { }
}

public record ToDoItemDto(Guid Id, string Text, bool IsDone, string CreatedBy, DateTimeOffset Created);
