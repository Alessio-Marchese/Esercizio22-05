using FastEndpoints;
using Shared.DTOS.ToDoLists.CreateToDoList;
using Shared.Entities;
using webapi.Infastructure.Data;


namespace webapi.Features.ToDoLists.CreateToDoList;

public class Endpoint(ApplicationDbContext context) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/todo-list");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var toDoList = ToDoList.Create(req.title);
        toDoList.CreatedBy = "Alessio";
        toDoList.Created = DateTime.Now;
        await context.ToDoLists.AddAsync(toDoList);
        await context.SaveChangesAsync();
        await SendAsync(new Response(toDoList.Id), cancellation: ct);
    }
}
