var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:7777");
app.Urls.Add("https://localhost:8080");

app.Run();
