using AutoMapper;
using webapi.Entities;

namespace webapi.Features.ToDoLists.GetAll;
   public record Request();
   public record Response(List<ToDoListDto> ToDoList);

public record ToDoListDto(string Title, bool IsDone, List<ToDoItem> ToDoItems);


public class ToDoListDtoProfile : Profile
{
    public ToDoListDtoProfile()
    {
        CreateMap<ToDoList, ToDoListDto>();
    }
}

