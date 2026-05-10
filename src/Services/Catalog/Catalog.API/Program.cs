using Catalog.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCqrsHandlers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
