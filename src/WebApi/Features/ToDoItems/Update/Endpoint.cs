using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Shared.DTOS.ToDoItems.Update;
using Shared.Entities;
using webapi.Infastructure.Data;

namespace webapi.Features.ToDoItems.Update
{
    internal sealed class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyResponse>
    {
        public override void Configure()
        {
            Put("/api/todo-item/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            ToDoList? toDoList = null;
            var toDoItem = await context.ToDoItems.Include(x => x.ToDoList).FirstOrDefaultAsync(x => x.Id == r.id);
            if (toDoItem is null)
            {
                await SendNotFoundAsync();
                return;
            }
            if (r.TodoListId is not null)
            {
                toDoList = await context.ToDoLists.FindAsync(r.TodoListId);
                if (toDoList is null)
                {
                    await SendNotFoundAsync();
                    return;
                }
            }
            toDoItem = ToDoItem.Update(toDoItem, r, toDoList);
            toDoItem.ToDoList.CheckDone();
            await context.SaveChangesAsync();
            await SendNoContentAsync();
        }
    }
}