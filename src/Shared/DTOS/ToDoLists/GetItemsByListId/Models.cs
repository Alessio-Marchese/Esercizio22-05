using Shared.Entities;

namespace Shared.DTOS.ToDoLists.GetItemsByListId;

public record Request(Guid Id);
public record Response(List<ToDoItemDto> ToDoItems);

public record ToDoItemDto(Guid Id, string Text, bool IsDone, string CreatedBy, DateTimeOffset Created);
