using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("catalog") ?? throw new Exception("No Connection String");

builder.Services.AddMarten(cfg =>

{

    cfg.Connection(connectionString);

}).UseLightweightSessions();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

//app.MapGet("/employees/{id}", (int id) =>

//{

//    return Results.Ok(new { id, name = "Bob Smith" });

//});

//app.MapPost("/catalog", () =>
//{
//    return Results.Ok();
//});

app.Run();

public partial class Program;