namespace NIDN.GlobalUsings;

// The Microsoft.Extensions.Hosting.IHostedService namespace is available because of the GlobalUsings.cs file
public class WorkerService : IHostedService
{
    // The Microsoft.Extensions.Logging namespace is available because of the GlobalUsings.cs file
    private readonly ILogger<WorkerService> _logger;
    private readonly IExampleService _exampleService;

    public WorkerService(ILogger<WorkerService> logger, IExampleService exampleService)
    {
        _logger = logger;
        _exampleService = exampleService;
    }

    // The System.Threading and System.Threading.Tasks namespaces are available because of the ImplicitUsings
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            _exampleService.DoWork();
            // ReSharper disable once MethodSupportsCancellation because cancellation should happen after work is done
            await Task.Delay(1000);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping work");

        return Task.CompletedTask;
    }
}
