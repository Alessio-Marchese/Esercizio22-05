using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Reflection;
using webapi.Infastructure.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMyLibraryServices();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
/*
    builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseInMemoryDatabase(nameof(ToDoList));
});
*/

builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.UseFastEndpoints().UseSwaggerGen();

app.MapGet("/", () => "Hello, World!");
    

app.Run();
