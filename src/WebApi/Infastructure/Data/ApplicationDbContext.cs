using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace webapi.Infastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
        public DbSet<ToDoList> ToDoLists => Set<ToDoList>();
    }
}
