using Microsoft.Extensions.Logging;

namespace NIDN.LoggingPerformanceImprovements;

public static partial class LogMessages
{
    [LoggerMessage(EventId = 10, Message = "The user `{userName}` could not be found")]
    public static partial void UserNotFound(this ILogger logger, LogLevel logLevel, string userName);

    [LoggerMessage(11, LogLevel.Information, "The user `{userName}` could not be logged in because they are disabled")]
    public static partial void DisabledUserLoggingIn(this ILogger logger, string userName);
}