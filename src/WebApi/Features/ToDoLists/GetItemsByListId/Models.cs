using webapi.Entities;

namespace webapi.Features.ToDoLists.GetItemsByListId;

public record class Request(Guid Id);
public record class Response(List<ToDoItem> ToDoItems);
