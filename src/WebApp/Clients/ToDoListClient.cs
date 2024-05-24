using Shared.Entities;
using System.Net.Http.Json;

namespace webapp.Clients;

public class ToDoListClient
{
    public async Task<List<ToDoList>> GetAllAsync(HttpClient httpClient)
        => await httpClient.GetFromJsonAsync<List<ToDoList>>("http://localhost:5084/api/todo-list") ?? [];
}
