using FastEndpoints;
using webapi.Infastructure.Data;
using Shared.DTOS.ToDoLists.GetById;

namespace webapi.Features.ToDoLists.GetById;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/api/todo-list/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var toDoList = await context.ToDoLists.FindAsync(req.Id);
        if (toDoList == null)
        {
            await SendNotFoundAsync(ct);
        }
        else
        {
            await SendAsync(new Response(toDoList.Title));
        }
    }
}
