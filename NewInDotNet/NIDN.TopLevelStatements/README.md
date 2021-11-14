# Description

Top-level statements is a feature added in C# 9 that aimed to remove some of the clutter and boilerplate from getting started with C#. In short, the application entrypoint now no longer needs to be in a 
```csharp
namespace NIDN.TopLevelStatements 
{
    public static class Program 
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Hello world!");
        }
    }
}
```
method. Instead, the above can be written now as
```csharp
System.Console.WriteLine("Hello world!");
```

Head over to [Program.cs](Program.cs) to see it in action.

# Key details

- Introduced in C# 9
- Recommended documentation:
  - https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements
- Only one file per project is allowed to contain top-level statements
- Does not need to be named `Program.cs`
- Project templates now start with top-level statements