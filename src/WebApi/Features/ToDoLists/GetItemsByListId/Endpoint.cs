using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using webapi.Entities;
using webapi.Infastructure.Data;

namespace webapi.Features.ToDoLists.GetItemsByListId;

internal sealed class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/api/todo-list/{id}/todo-item");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var toDoList = await context.ToDoLists.Include(x => x.ToDoItems).FirstOrDefaultAsync(x => x.Id == r.Id);
        if (toDoList == null)
        {
            await SendNotFoundAsync(c);
            return;
        }
        await SendAsync(new Response(toDoList.ToDoItems), cancellation: c);
    }
}