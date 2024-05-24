using FastEndpoints;
using Shared.DTOS.ToDoItems.DeleteById;
using webapi.Infastructure.Data;

namespace webapi.Features.ToDoItems.DeleteById
{
    internal sealed class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyResponse>
    {
        public override void Configure()
        {
            Delete("/api/todo-item/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var toDoItem = await context.ToDoItems.FindAsync(r.Id);
            if(toDoItem is null)
            {
                await SendNotFoundAsync();
                return;
            }
            context.ToDoItems.Remove(toDoItem);
            await context.SaveChangesAsync();
            await SendNoContentAsync();
        }
    }
}