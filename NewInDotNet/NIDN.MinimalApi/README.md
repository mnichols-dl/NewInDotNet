# Description

One of the major changes with .NET 6 is the new Minimal API approach that is available as an option.

This approach does not replace MVC controllers at all, but rather provides another way to get up and running with very lightweight and simple endpoints.

Some scenarios this may make sense:
 - Rapid prototyping
 - Microservices

Many new features like top-level statements, file-scoped namespaces, and the combined startup approach all contribute to how brief it can now be to define a completely functional API.

This project is more or less the ASP.NET Core Web API starter template when `Use controllers` is unchecked.

# Key details

- Recommended documentation
  - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0
  - https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio#differences-between-minimal-apis-and-apis-with-controllers
  - https://andrewlock.net/exploring-dotnet-6-part-2-comparing-webapplicationbuilder-to-the-generic-host/
  - https://gist.github.com/davidfowl/0e0372c3c1d895c3ce195ba983b1e03d#custom-dependency-injection-container