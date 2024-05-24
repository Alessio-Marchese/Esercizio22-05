using Shared.Entities;

namespace Shared.DTOS.ToDoLists.GetItemsByListId;

public record class Request(Guid Id);
public record class Response(List<ToDoItem> ToDoItems);
