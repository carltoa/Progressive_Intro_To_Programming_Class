namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string message = "Welcome to Class";

        DateTime now = DateTime.Now;

        string finalMessage = $"The message {message} and it is now {now:t}";


        var app = builder.Build();

        app.MapGet("/message", () =>
        {
            var response = new MessageResponseModel("this is an API! Wow!", DateTime.Now);
            return Results.Ok(finalMessage);
        });

        app.Run();
    }
}

public record MessageResponseModel(string Message, DateTime When);