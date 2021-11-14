# Description

A record is a special type of class which the compiler generates certain immutable and value-focused behaviors.

Additionally, init-only setters were introduced to make creating immutable classes simpler.

Head over to [Program.cs](Program.cs) to walk through some of these behaviors and their effects.

# Key details

- Record types and init-only setter introduced in C# 9, expanded to structs in C# 10
- Recommended documentation
  - https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records
  - https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records
  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/init
- Positional records provide the following differences from classes or structs
  - Concise positional parameter definition
  - Value-based equality using members
  - Support for `with` expression
  - Human-readable `ToString()` method generated
  - `Deconstruct()` method generated
- Not suitable for Entity Framework