using AutoMapper.QueryableExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using webapi.Infastructure.Data;

namespace webapi.Features.ToDoLists.GetAll;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<EmptyRequest, Response>
{
    public override void Configure()
    {
        Get("/api/todo-list");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var toDoListsDto = await context.ToDoLists
            .ProjectTo<ToDoListDto>(mapper.ConfigurationProvider)
            .ToListAsync(ct);
        await SendAsync(new Response(toDoListsDto), cancellation: ct);
    }
}
