namespace Shared.Components.DTOS.ToDoItems.Update;

public record UpdateToDoItemRequest(Guid? id, bool? IsDone, string? Text);
