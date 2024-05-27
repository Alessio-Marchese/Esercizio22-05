using System.Net.Http.Json;

namespace webapp.Clients;

public class ToDoItemClient
{
    public async Task UpdateToDoItemAsync(HttpClient httpClient, Shared.DTOS.ToDoItems.Update.Request request)
        => await httpClient.PutAsJsonAsync($"http://localhost:5084/api/todo-item/{request.id}", request);

    public async Task DeleteToDoItemAsync(HttpClient httpClient, Guid id)
        => await httpClient.DeleteAsync($"http://localhost:5084/api/todo-item/{id}");
}
