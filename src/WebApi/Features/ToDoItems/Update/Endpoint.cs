using FastEndpoints;
using Shared.DTOS.ToDoItems.Update;
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
            var toDoItem = await context.ToDoItems.FindAsync(r.id);
            if (toDoItem is null)
            {
                await SendNotFoundAsync();
                return;
            }
            if(!string.IsNullOrWhiteSpace(r.Text))
            {
                toDoItem.Text = r.Text;
            }
            if(r.TodoListId is not null)
            {
                var toDoList = await context.ToDoLists.FindAsync(r.TodoListId);
                if(toDoList is null)
                {
                    await SendNotFoundAsync();
                    return;
                }
                toDoItem.ToDoList = toDoList;
            }
            if(toDoItem.IsDone != r.IsDone)
            {
                toDoItem.IsDone = r.IsDone;
            }
            await context.SaveChangesAsync();
            await SendNoContentAsync();
        }
    }
}