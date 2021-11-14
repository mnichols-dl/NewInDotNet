using NIDN.MinimalApi;
using NIDN.MinimalApi.Endpoints;

// ======================================= Minimal Startup Model =================================== //

// One key difference in new .NET 6 project templates for ASP.NET is the unification of the host configuration (`Program.cs`)
// and app configuration (`Startup.cs`) concerns into a single sequence in `Program.cs`. Instead of having the builder
// chain a call to .UseStartup<Startup>(), then implementing some "magic-string" type methods named
// ConfigureServices() and Configure(), this has been greatly simplified.

// WebApplication.CreateBuilder() is the new approach for .NET 6. The builder handles
// configuration, service registration, and logging.
var builder = WebApplication.CreateBuilder(args);

// Can hook in a custom IoC container here as well (note: this is only for example -- Autofac is not referenced.):
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.
builder.Services.AddScoped<HealthService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// The app (WebApplication) handles web-specific concerns like
// routing, authorization, the ASP.NET Pipeline, and much more.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// Endpoint definitions do not have to be in this single file
app.AddHealthCheckEndpoint();

app.Run();