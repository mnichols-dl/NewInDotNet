# Description

The .NET built-in type `DateTime` works great for specific points in time, but falls short when representing only dates or only times. Past solutions often involved ignoring half of that data type and relied on users treating those objects the same.

.NET 6 introduces two new types to address this, `DateOnly` and `TimeOnly`.

These come with a whole host of similar APIs to `DateTime` as well as helpers to make it easy to move between the two paradigms.

Head over to [Program.cs](Program.cs) to walk through some of these behaviors and their effects.

# Key details

- Introduced in .NET 6
- Recommended documentation
  - https://devblogs.microsoft.com/dotnet/date-time-and-time-zone-enhancements-in-net-6/
  - [GitHub issue in EF Core for adding support for DateOnly and TimeOnly](https://github.com/dotnet/efcore/issues/24507)
- This project (and others) include some helpers for enhancing `DateOnly` and `TimeOnly`, since there were some features that did not make it into the release
- Does not work out of the box in EF Core or JsonSerializer yet.