# New in .NET

This repository is intended to showcase some of the recent changes and improvements to C# and .NET. Each feature or topic will have its own `.csproj` as an entrypoint and a `README.md` to provide context. To run any of the examples, right-click the project and choose `Set as Startup Project`.

This solution and documentation are not meant to be comprehensive, but rather a survey. Microsoft puts out really good documentation about these new features (and in general with .NET features), and it's highly recommended you explore them -- you may find some features not covered here very useful for your work.

- [What's new in C# 10](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10)
- [What's new in C# 9](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)
- [What's new in .NET 6](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
- [What's new in .NET 5](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-5)
- [What's new in EF Core 6](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew)
- [What's new in EF Core 5](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/whatsnew)
- [What's new in ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-6.0?view=aspnetcore-6.0)
- [What's new in ASP.NET Core 5](https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-5.0?view=aspnetcore-5.0)

## Versioning

.NET 6 is a [Long Term Support (LTS) release](https://dotnet.microsoft.com/platform/support/policy), meaning the version will receive patches and support for three years after release, until November 8, 2024. Accompanying this release is C# 10, Visual Studio 2022, and F# 6.

C# 10 is only supported with .NET 6. Visual Studio 2022 is required to use Visual Studio with .NET 6 projects.

### .NET, .NET Core, .NET Framework, .NET Standard

In a nutshell:
- .NET Framework: In the beginning...
- .NET Core: Separate runtime to go cross-platform without breaking Windows users
- .NET Standard: Keep parts .NET Core and .NET Framework have in common aligned in new releases
- .NET: Simplified cross-platform path forward
- There are NO new versions of .NET Standard coming out.
- .NET Standard should only be targeted if the code will need to be used by more than one of the .NET implementers (i.e. code will be used in .NET 6 apps as well as legacy .NET Framework 4.7.2 apps, maybe Mono or Xamarin).
- Prefer targetting .NET going forward
- For more: https://docs.microsoft.com/en-us/dotnet/standard/net-standard

## Getting Started

To start using .NET 6, you'll need:

- .NET 6 SDK
  - Via browser: https://dotnet.microsoft.com/download/dotnet/6.0
  - Via Chocolatey: `choco install dotnet-sdk`
- Visual Studio 2022 (v17)
  - Via browser: https://visualstudio.microsoft.com/

## Other tools

Some other (optional) tooling may be useful to explore these changes as well:

- ILSpy
  - Decompile the .NET 6 assemblies to inspect what the compiler is doing
  - Via browser: https://github.com/icsharpcode/ILSpy
- Markdown Editor for Visual Studio
  - An extension for editing and previewing markdown files in Visual Studio
  - Via browser: https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor
  - Via `Visual Studio > Extensions > Manage Extensions`

# General Notes

- Performance
  - A lot of focus has been placed on performance with recent .NET releases, and this one is no exception. Many existing APIs run faster out of the box, and many more performance-optimizing APIs were added. Improvements were made to source generation, JIT, file IO, SignalR, HTTP/3 preview, and more.
  - https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/
- Hot Reload - Visual Studio 2022 and the `dotnet` CLI have support for hot reload to reduce turnaround time to try out changes.
- Blazor is still seeing lots of activity and improvements
- .NET MAUI (still in preview) is an ambitious unified UI kit for building native apps for Windows, macOS, iOS, and Android