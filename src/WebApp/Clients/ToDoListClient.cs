using Shared.DTOS.ToDoLists.GetItemsByListId;
using Shared.Entities;
using System.Net.Http.Json;

namespace webapp.Clients;

public class ToDoListClient
{
    public async Task<List<ToDoList>> GetAllAsync(HttpClient httpClient)
        => await httpClient.GetFromJsonAsync<List<ToDoList>>("http://localhost:5084/api/todo-list") ?? [];

    public async Task<Response?> GetItemsByListIdAsync(HttpClient httpClient, Guid id)
        => await httpClient.GetFromJsonAsync<Response>($"http://localhost:5084/api/todo-list/{id}/todo-item"); 
}
