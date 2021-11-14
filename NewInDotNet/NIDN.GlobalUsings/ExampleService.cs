namespace NIDN.GlobalUsings;

public interface IExampleService
{
    void DoWork();
}

public class ExampleService : IExampleService
{
    // The Microsoft.Extensions.Logging namespace is available because of GlobalUsings.cs
    private readonly ILogger<ExampleService> _logger;

    public ExampleService(ILogger<ExampleService> logger)
    {
        _logger = logger;
    }

    public void DoWork()
    {
        _logger.LogInformation("Doing work at {WorkTime:O}", DateTime.Now);
    }
}
