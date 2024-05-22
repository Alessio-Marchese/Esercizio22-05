using FastEndpoints;
using webapi.Infastructure.Data;

namespace webapi.Features.ToDoLists.GetById;

public class Endpoint(ApplicationDbContext context) : Endpoint<EmptyRequest, Response>
{
    public override void Configure()
    {
        Get("/api/todo-list/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var toDoList = await context.ToDoLists.FindAsync(id);
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
