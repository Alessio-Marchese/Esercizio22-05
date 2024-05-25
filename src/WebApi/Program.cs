using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Entities;
using System.Reflection;
using webapi.Infastructure.Data;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7124").AllowAnyHeader().AllowAnyMethod();
                      });
});
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

app.UseCors(MyAllowSpecificOrigins);

app.UseFastEndpoints().UseSwaggerGen();

app.MapGet("/", () => "Hello, World!");
    

app.Run();
