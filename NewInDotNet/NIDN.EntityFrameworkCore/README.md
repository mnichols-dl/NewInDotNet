# Description

New EF Core features highlighted here will cover both runtime and deploytime concerns.

SQL Server temporal tables (a feature of SQL Server 2016 and later) can now be used in EF Core with helpful fluent API methods to provide historical record maintenance for your data directly from SQL Server.

For more, check out the [Program.cs](Program.cs) entrypoint.

## Deployments with Migration Bundles

Migration bundles are a new feature added to EF Core 6 that provide a simpler way to apply bundles at deployment time.

The following was run in the Developer Prompt after creating the initial code-first DbContext and members:

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate --project NIDN.EntityFrameworkCore
```

To create a migration bundle:
```
dotnet ef migrations bundle --project NIDN.EntityFrameworkCore --verbose
```

To run a migration bundle:
```
.\efbundle.exe
```
or
```
.\efbundle.exe --connection "<CONNECTION STRING HERE>"
```

To reset the database:
```
dotnet ef database drop --project NIDN.EntityFrameworkCore -f
dotnet ef migrations bundle --project NIDN.EntityFrameworkCore --verbose
.\efbundle.exe
```

# Key details

- Recommended documentation
  - https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew
  - https://docs.microsoft.com/en-us/sql/relational-databases/tables/temporal-tables?view=sql-server-ver15
