using FastEndpoints;
using webapi.Entities;
using webapi.Infastructure.Data;

namespace webapi.Features.ToDoLists.AddItem
{
    internal sealed class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("/api/todo-list/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var toDoList = await context.ToDoLists.FindAsync(r.Id);
            if (toDoList ==  null)
            {
                await SendNotFoundAsync(c);
                return;
            }
            var toDoItem = toDoList.AddToDoItem(r.Text);
            await context.SaveChangesAsync();
            await SendAsync(new Response(toDoItem.Id), cancellation: c);
        }
    }
}