using Microsoft.Extensions.DependencyInjection;
using Shared.Components.Clients;

namespace Shared.Components;
public static class SharedServices
{
	public static void AddMyRclServices(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddSingleton<ToDoItemClient>();
		serviceCollection.AddSingleton<ToDoListClient>();
	}
}
