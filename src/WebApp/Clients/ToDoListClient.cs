using System.Net.Http.Json;

namespace webapp.Clients;

public class ToDoListClient
{
    public async Task<List<Shared.DTOS.ToDoLists.GetAll.Response>> GetAllAsync(HttpClient httpClient)
        => await httpClient.GetFromJsonAsync<List<Shared.DTOS.ToDoLists.GetAll.Response>>("http://localhost:5084/api/todo-list") ?? [];

    public async Task<Shared.DTOS.ToDoLists.GetItemsByListId.Response?> GetItemsByListIdAsync(HttpClient httpClient, Guid id)
        => await httpClient.GetFromJsonAsync<Shared.DTOS.ToDoLists.GetItemsByListId.Response>($"http://localhost:5084/api/todo-list/{id}/todo-item");

    public async Task DeleteToDoListAsync(HttpClient httpClient, Guid id)
        => await httpClient.DeleteAsync($"http://localhost:5084/api/todo-list/{id}");

    public async Task AddToDoListAsync(HttpClient httpClient, Shared.DTOS.ToDoLists.CreateToDoList.Request request)
        => await httpClient.PostAsJsonAsync("http://localhost:5084/api/todo-list", request);

    public async Task<Shared.DTOS.ToDoLists.GetById.Response?> GetToDoListByIdAsync(HttpClient httpClient, Guid id)
        => await httpClient.GetFromJsonAsync<Shared.DTOS.ToDoLists.GetById.Response>($"http://localhost:5084/api/todo-list/{id}");

    public async Task UpdateToDoListAsync(HttpClient httpClient, Guid id, string listTitle)
    {
        Shared.DTOS.ToDoLists.Update.Request request = new(id, listTitle);
        await httpClient.PutAsJsonAsync($"http://localhost:5084/api/todo-list/{id}", request);
    }

    public async Task AddToDoItemAsync(HttpClient httpClient, Shared.DTOS.ToDoLists.AddItem.Request request)
        => await httpClient.PostAsJsonAsync($"http://localhost:5084/api/todo-list/{request.Id}", request);
}
