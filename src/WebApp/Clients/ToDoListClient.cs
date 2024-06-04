using Shared.DTOS.ToDoLists.AddItem;
using Shared.DTOS.ToDoLists.CreateToDoList;
using Shared.DTOS.ToDoLists.GetAll;
using Shared.DTOS.ToDoLists.GetById;
using Shared.DTOS.ToDoLists.GetItemsByListId;
using Shared.DTOS.ToDoLists.Update;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace webapp.Clients;

public class ToDoListClient
{
    public async Task<GetAllToDoListResponse?> GetAllAsync(HttpClient httpClient)
    {
        var response = await httpClient.GetFromJsonAsync<GetAllToDoListResponse>("http://localhost:5084/api/todo-list");
        if(response is not null && response.ToDoLists is not null )
        {
            response.ToDoLists = response.ToDoLists.OrderByDescending(x => x.Created).ToList();
        }
        return response;
    }

    public async Task<GetItemsByListIdResponse?> GetItemsByListIdAsync(HttpClient httpClient, Guid id)
    {
        var response = await httpClient.GetFromJsonAsync<GetItemsByListIdResponse>($"http://localhost:5084/api/todo-list/{id}/todo-item");
        if(response is not null && response.ToDoItems is not null)
        {
            response.ToDoItems = response.ToDoItems.OrderByDescending(x => x.Created).ToList();
        }
        return response;
    } 

    public async Task DeleteToDoListAsync(HttpClient httpClient, Guid id)
        => await httpClient.DeleteAsync($"http://localhost:5084/api/todo-list/{id}");

    public async Task AddToDoListAsync(HttpClient httpClient, CreateToDoListRequest request)
        => await httpClient.PostAsJsonAsync("http://localhost:5084/api/todo-list", request);

    public async Task<GetToDoListByIdResponse?> GetToDoListByIdAsync(HttpClient httpClient, Guid id)
        => await httpClient.GetFromJsonAsync<GetToDoListByIdResponse>($"http://localhost:5084/api/todo-list/{id}");

    public async Task UpdateToDoListAsync(HttpClient httpClient, Guid id, string listTitle)
    {
        UpdateToDoListRequest request = new(id, listTitle);
        await httpClient.PutAsJsonAsync($"http://localhost:5084/api/todo-list/{id}", request);
    }

    public async Task AddToDoItemAsync(HttpClient httpClient, AddToDoItemRequest request)
        => await httpClient.PostAsJsonAsync($"http://localhost:5084/api/todo-list/{request.Id}", request);
}
