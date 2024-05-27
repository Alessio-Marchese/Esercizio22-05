using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Shared.DTOS.ToDoLists.AddItem;
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
            var toDoList = context.ToDoLists.Include(x => x.ToDoItems).FirstOrDefault(x => x.Id == r.Id);
            if (toDoList ==  null)
            {
                await SendNotFoundAsync(c);
                return;
            }
            var toDoItem = toDoList.AddToDoItem(r.Text);
            toDoList.CheckDone();
            await context.SaveChangesAsync();
            await SendAsync(new Response(toDoItem.Id), cancellation: c);
        }
    }
}