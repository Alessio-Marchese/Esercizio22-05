using AutoMapper.QueryableExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using webapi.Infastructure.Data;
using Shared.DTOS.ToDoLists.GetAll;

namespace webapi.Features.ToDoLists.GetAll;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<EmptyRequest, List<Response>>
{
    public override void Configure()
    {
        Get("/api/todo-list");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        await SendAsync(await context.ToDoLists.ProjectTo<Response>(mapper.ConfigurationProvider).ToListAsync(), cancellation: ct);
    }
}
