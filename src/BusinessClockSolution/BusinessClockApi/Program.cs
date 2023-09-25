using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ISystemTime, SystemTime>();
builder.Services.AddScoped<IProvideTheBusinessClock, StandardBusinessClock>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/clock", ([FromServices] IProvideTheBusinessClock businessClock) =>
{
    ClockResponse response = businessClock.GetClock();

    return Results.Ok(response);
});

app.Run();

public partial class Program { }


