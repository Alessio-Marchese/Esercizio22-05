using FastEndpoints;
using Shared.DTOS.ToDoItems.DeleteById;
using webapi.Infastructure.Data;

namespace webapi.Features.ToDoLists
{
    internal sealed class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyResponse>
    {
        public override void Configure()
        {
            Delete("api/todo-list/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var toDoList = await context.ToDoLists.FindAsync(r.id);
            if (toDoList == null) 
            {
                await SendNotFoundAsync(c);
            }
            else
            {
                context.ToDoLists.Remove(toDoList);
                await context.SaveChangesAsync();
                await SendNoContentAsync(c);
            }
        }
    }
}