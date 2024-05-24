using AutoMapper;
using Shared.Entities;

namespace Shared.DTOS.ToDoLists.GetAll;
public record Request();
public record Response(Guid Id, string Title, bool IsDone, DateTimeOffset Created, string CreatedBy);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<ToDoList, Response>();
    }
}

