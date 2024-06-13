using Shared.DTOS.ToDoItems.Update;
using System.Net.Http.Json;

namespace HybridMauiApp.Clients;

public class ToDoItemClient
{
    public static string ip { get; set; } = "localhost:5084";
    public async Task UpdateToDoItemAsync(HttpClient httpClient, UpdateToDoItemRequest request)
        => await httpClient.PutAsJsonAsync($"http://{ip}/api/todo-item/{request.id}", request);

    public async Task DeleteToDoItemAsync(HttpClient httpClient, Guid id)
        => await httpClient.DeleteAsync($"http://{ip}/api/todo-item/{id}");
}
