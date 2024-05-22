using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using webapi.Entities;
using webapi.Infastructure.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseInMemoryDatabase(nameof(ToDoList));
});
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.UseFastEndpoints().UseSwaggerGen();

app.MapGet("/", () => "Hello World!");
    

app.Run();
