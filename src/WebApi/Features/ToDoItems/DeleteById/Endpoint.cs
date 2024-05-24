using FastEndpoints;
using Microsoft.EntityFrameworkCore;
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
            var toDoItem = await context.ToDoItems.Include(x => x.ToDoList).FirstOrDefaultAsync(x => x.Id == r.id);
            if (toDoItem is null)
            {
                await SendNotFoundAsync();
                return;
            }
            toDoItem.ToDoList.ToDoItems.Remove(toDoItem);
            context.ToDoItems.Remove(toDoItem);
            toDoItem.ToDoList.CheckDone();
            await context.SaveChangesAsync();
            await SendNoContentAsync();
        }
    }
}