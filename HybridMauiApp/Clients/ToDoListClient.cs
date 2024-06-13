using HybridMauiApp.DTOS.ToDoLists.AddItem;
using HybridMauiApp.DTOS.ToDoLists.CreateToDoList;
using HybridMauiApp.DTOS.ToDoLists.GetAll;
using HybridMauiApp.DTOS.ToDoLists.GetById;
using HybridMauiApp.DTOS.ToDoLists.GetItemsByListId;
using HybridMauiApp.DTOS.ToDoLists.Update;
using System.Net.Http.Json;

namespace HybridMauiApp.Clients;

public class ToDoListClient
{
    public static string ip { get; set; } = "localhost:5084";
    public async Task<GetAllToDoListResponse?> GetAllAsync(HttpClient httpClient)
    {
        var response = await httpClient.GetFromJsonAsync<GetAllToDoListResponse>($"http://{ip}/api/todo-list");
        if(response is not null && response.ToDoLists is not null )
        {
            response.ToDoLists = response.ToDoLists.OrderByDescending(x => x.Created).ToList();
        }
        return response;
    }

    public async Task<GetItemsByListIdResponse?> GetItemsByListIdAsync(HttpClient httpClient, Guid id)
    {
        var response = await httpClient.GetFromJsonAsync<GetItemsByListIdResponse>($"http://{ip}/api/todo-list/{id}/todo-item");
        if(response is not null && response.ToDoItems is not null)
        {
            response.ToDoItems = response.ToDoItems.OrderByDescending(x => x.Created).ToList();
        }
        return response;
    } 

    public async Task DeleteToDoListAsync(HttpClient httpClient, Guid id)
        => await httpClient.DeleteAsync($"http://{ip}/api/todo-list/{id}");

    public async Task AddToDoListAsync(HttpClient httpClient, CreateToDoListRequest request)
        => await httpClient.PostAsJsonAsync($"http://{ip}/api/todo-list", request);

    public async Task<GetToDoListByIdResponse?> GetToDoListByIdAsync(HttpClient httpClient, Guid id)
        => await httpClient.GetFromJsonAsync<GetToDoListByIdResponse>($"http://{ip}/api/todo-list/{id}");

    public async Task UpdateToDoListAsync(HttpClient httpClient, Guid id, string listTitle)
    {
        UpdateToDoListRequest request = new(id, listTitle);
        await httpClient.PutAsJsonAsync($"http://{ip}/api/todo-list/{id}", request);
    }

    public async Task AddToDoItemAsync(HttpClient httpClient, AddToDoItemRequest request)
        => await httpClient.PostAsJsonAsync($"http://{ip}/api/todo-list/{request.Id}", request);
}
