var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// beween app creation and app.run() we can create endpoints.

// Don't need to use a / prefix for the endpoint name
// it will be implicitly added if needed
// Lambda handler is used to return the response.
app.MapGet("get-example", () => "Hello from GET");

// Same works for POST
app.MapPost("post-example", () => "Hello from POST");

// This example uses a lambda expression to define a GET endpoint at the route "/ok-result".
// Results.Ok() creates a 200 OK HTTP response using the built-in IResult interface.
app.MapGet("ok-result", () => Results.Ok());


// This endpoint shows how to return data as part of the response.
// We're still using Results.Ok(), but this time we're passing in an anonymous object.
// The response will include a JSON representation of the object: { "Name": "Kerpackie" }
app.MapGet("ok-object", () => Results.Ok(new
{
    Name = "Kerpackie"
}));

// There are loads of other built-in results you can use.
// For example, you can return a 404 Not Found response using Results.NotFound().
app.MapGet("not-found", () => Results.NotFound());

// By default these endpoints run synchronously.
// If you want to run them asynchronously, you can use the async keyword.
// This example shows how to return a 200 OK response with a delay of 2 seconds.
app.MapGet("slow-request", async () =>
{
    await Task.Delay(2000);
    return Results.Ok(new
    {
        Name = "Kerpackie"
    });
});

app.Run();