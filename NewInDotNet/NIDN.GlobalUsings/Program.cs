using NIDN.GlobalUsings;

// The System namespace is available because of the ImplicitUsings for the Console/Library project types
Console.WriteLine("Application starting...");

// Microsoft.Extensions.Hosting namespace and the Microsoft.Extension.DependencyInjection namespace's
// extension methods `AddScoped()` and `AddHostedService()` are all available because of the GlobalUsings.cs file
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<IExampleService, ExampleService>();
        services.AddHostedService<WorkerService>();
    })
    .Build();

await host.RunAsync();
