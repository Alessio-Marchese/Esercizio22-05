using AutoMapper;
using webapi.Entities;

namespace webapi.Features.ToDoLists.GetAll;
public record Request();
public record Response(Guid id, string title, bool IsDone);

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<ToDoList, Response>();
    }
}

