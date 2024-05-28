using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using webapi.Consts;
using webapi.Infastructure.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    
    var origins = builder.Configuration.GetValue<string>("Cors:WithOrigins")?.Split(";")?? Array.Empty<string>();
    options.AddPolicy(name: Constants.MY_ALLOW_SPECIFIC_ORIGINS,
                      policy =>
                      {
                          policy.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod();
                      });
});
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

app.UseCors(Constants.MY_ALLOW_SPECIFIC_ORIGINS);

app.UseFastEndpoints().UseSwaggerGen();

app.MapGet("/", () => "Hello, World!");
    

app.Run();
