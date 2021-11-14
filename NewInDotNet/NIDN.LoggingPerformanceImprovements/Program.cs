using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NIDN.LoggingPerformanceImprovements;

var host = Host.CreateDefaultBuilder().Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();

NIDN.LoggingPerformanceImprovements.LogMessages.DisabledUserLoggingIn(logger, "shaq");

logger.UserNotFound(LogLevel.Error, "shaq");