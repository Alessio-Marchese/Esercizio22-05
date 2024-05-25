namespace Shared.DTOS.ToDoLists.GetById;
   public record Request(Guid Id);
public record Response
{
    public string ListTitle { get; set; }
}

