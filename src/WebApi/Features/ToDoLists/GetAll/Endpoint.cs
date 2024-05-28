using AutoMapper.QueryableExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Shared.DTOS.ToDoLists.GetAll;
using webapi.Infastructure.Data;

namespace webapi.Features.ToDoLists.GetAll;

public class Endpoint(ApplicationDbContext context, AutoMapper.IMapper mapper) : Endpoint<EmptyRequest, List<GetAllToDoListResponse>>
{
    public override void Configure()
    {
        Get("/api/todo-list");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var toDoLists = await context.ToDoLists.ToListAsync();
        List<GetAllToDoListResponse> toDoListsDto = new();
        foreach(var toDoList in toDoLists)
        {
            var toDoListDto = mapper.Map<GetAllToDoListResponse>(toDoList);
            toDoListsDto.Add(toDoListDto);
        }
        await SendAsync(toDoListsDto, cancellation: ct);
    }
}
