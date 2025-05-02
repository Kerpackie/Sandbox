var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// beween app creation and app.run() we can create endpoints.

// Don't need to use a / prefix for the endpoint name
// it will be implicitly added if needed
// Lambda handler is used to return the response.
app.MapGet("get-example", () => "Hello from GET");

// Same works for POST
app.MapPost("post-example", () => "Hello from POST");

app.Run();
