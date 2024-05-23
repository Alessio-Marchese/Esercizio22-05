namespace webapi.Features.ToDoLists.GetById;
   public record Request(Guid Id);
   public record Response(string ListTitle);
