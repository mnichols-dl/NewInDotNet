# Description

Global using directives allow for namespaces to be brought into scope globally across a project. The main benefit of this is reducing boilerplate, but it should be used thoughtfully.

In the entrypoint at [Program.cs](Program.cs), the extension methods are available to use becuase of the inclusion of the following in the [GlobalUsings.cs](GlobalUsings.cs) file:

```csharp
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
```

A .NET addition called implicit usings adds several global using directives based on what the type of project is. This is an opt-in feature (enabled by default in .NET 6 project templates), and 
```xml
<ImplicitUsings>enable</ImplicitUsings>
```
is included in the project file [NIDN.GlobalUsings.csproj](NIDN.GlobalUsings.csproj) is enabled.

In [Program.cs](Program.cs), the ```System.Console``` class can be referenced as `Console` because the project has an implicit `using System;` statement based on its project type.

The project registers a background hosted service [WorkerService.cs](WorkerService.cs) that calls a 
```csharp
DoWork()
```
method in [ExampleService.cs](ExampleService.cs).

# Key details

- Introduced in C# 10 and .NET 6
- Recommended documentation
  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
  - https://www.hanselman.com/blog/implicit-usings-in-net-6
- Applies using directive to all files in the project
- May be in any file, but it is recommended to keep in one
  - Convention seen in many docs is to place these in `GlobalUsings.cs`
 
## Implicit usings by project type

- Console or Library
  - System
  - System.Collections.Generic
  - System.IO
  - System.Linq
  - System.Net.Http
  - System.Threading
  - System.Threading.Tasks
- Web
  - System.Net.Http.Json
  - Microsoft.AspNetCore.Builder
  - Microsoft.AspNetCore.Hosting
  - Microsoft.AspNetCore.Http
  - Microsoft.AspNetCore.Routing
  - Microsoft.Extensions.Configuration
  - Microsoft.Extensions.DependencyInjection
  - Microsoft.Extensions.Hosting
  - Microsoft.Extensions.Logging