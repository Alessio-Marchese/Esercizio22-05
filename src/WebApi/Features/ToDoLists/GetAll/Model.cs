using AutoMapper;
using webapi.Entities;

namespace webapi.Features.ToDoLists.GetAll;
public record Request();
public record Response(Guid Id, string Title, bool IsDone);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<ToDoList, Response>();
    }
}

