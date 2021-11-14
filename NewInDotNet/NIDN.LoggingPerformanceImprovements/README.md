# Description

Many performance improvements have been made possible by using [Source Generators](https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/source-generators-overview) from .NET 5. One such example is with the ILogger interface and Logger Message generators.

Source Generation is used on methods matching the following format:

```csharp
[LoggerMessage(EventId = 0, Level = LogLevel.Critical, Message = "Could not open socket to `{hostName}`")]
    public static partial void CouldNotOpenSocket(ILogger logger, string hostName);
```

These can be fairly concise by using extension methods and one of the attribute's constructors:

 ```csharp
[LoggerMessage(0, LogLevel.Critical, "Could not open socket to `{hostName}`")]
    public static partial void CouldNotOpenSocket(this ILogger logger, string hostName);
```

This can be a great way to get a performance increase if you are using this type of strong logging.

# Key details

- Introduced in .NET 6
- Recommended documentation
  - https://docs.microsoft.com/en-us/dotnet/core/extensions/logger-message-generator