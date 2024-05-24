namespace Shared.DTOS.ToDoLists.GetById;
   public record Request(Guid Id);
   public record Response(string ListTitle);
