using GraphDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL();

app.MapGet("/", () => "Hello World!")
    .WithName("root")
    .WithOpenApi();

app.MapGet("/api/v1/health", () => new { Status = "Healthy" })
    .WithName("health")
    .WithOpenApi();

app.UseHttpsRedirection();

app.Run();