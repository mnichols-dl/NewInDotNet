using NIDN.EntityFrameworkCore;
using NIDN.EntityFrameworkCore.Helpers;

// Startup code
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<TemporalDataGenerator>();
        services.AddDbContext<DemoDbContext>(options =>
            options.UseSqlServer("Server=.;Database=NIDN_EntityFrameworkCore;Trusted_Connection=True;"));
    })
    .Build();

var dbContext = host.Services.GetRequiredService<DemoDbContext>();
var tempDataGenerator = host.Services.GetRequiredService<TemporalDataGenerator>();

// Prepare the database with some data entered at different times
await dbContext.Database.EnsureDeletedAsync();
await dbContext.Database.MigrateAsync();
var (requestOpened, requestDenied, requestOverturned) = await tempDataGenerator.GenerateTemporalDataAsync();

// ============================= SQL Server Temporal Tables ======================================== //

Console.WriteLine($"Current count of TimeOffRequest without Temporal: {dbContext.TimeOffRequests.Count()}");

// You use TemporalAsOf() with join support out of the box. Note that the time is stored in SQL Server as UTC
var requestsOneYearAgo = dbContext.TimeOffRequests.TemporalAsOf(DateTime.UtcNow.AddYears(-1)).ToList();
var requestsWhenOpened = dbContext.TimeOffRequests.TemporalAsOf(requestOpened.ToUniversalTime()).ToList();
var requestsWhenDenied = dbContext.TimeOffRequests.TemporalAsOf(requestDenied.ToUniversalTime()).ToList();
var requestsWhenOverturned = dbContext.TimeOffRequests.TemporalAsOf(requestOverturned.ToUniversalTime()).ToList();
var requestsNow = dbContext.TimeOffRequests.ToList();

// TemporalAll() gets all versions of the entity set
var timeOffRequestHistory = dbContext
    .TimeOffRequests
    .TemporalAll()
    .Select(x => new
    {
        Entry = x,
        PeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
        PeriodEnd = EF.Property<DateTime>(x, "PeriodEnd")
    });

// A convenience extension method and generic class is included in this demo project
// to simplify some use cases.
var timeOffHistory = dbContext.TimeOffRequests
    .TemporalAll()
    .AsTemporalRecord(true);

var formattedTimeOffHistory = timeOffHistory.Select(x => new
{
    x.Record.Approved,
    x.Record.RequestingUserId,
    x.Record.ReviewingUserId,
    x.PeriodStart
});

await formattedTimeOffHistory.ForEachAsync((x) => Console.WriteLine($"{x.PeriodStart:u}: Requester {x.RequestingUserId}, Reviewer {x.ReviewingUserId}, Approval {x.Approved}"));

// ========================================== Other new features =================================== //
// EF Core 5 introduced built-in support for splitting out queries into multiple trips to the database.
// This is a tradeoff often helpful when EF produces joins and orderings that perform poorly. EF will perform
// a number of individual queries and join up the data in-memory as needed.

dbContext.Users.Include(x => x.TimeOffRequests).ToList();
dbContext.Users.Include(x => x.TimeOffRequests).AsSplitQuery().ToList();

// .ToQueryString() is new to EF Core 5 and useful for debugging.
var dbCommand = dbContext.Users.Include(x => x.TimeOffRequests).ToQueryString();
var dbCommandSplit = dbContext.Users.Include(x => x.TimeOffRequests).AsSplitQuery().ToQueryString();
Console.WriteLine(dbCommand);

// Filtered includes is new to EF Core 5 and provides a way to eagerly load only certain nav properties
dbContext.Users.Include(x => x.TimeOffRequests
    .Where(tor => tor.Approved == null))
    .ToList();

// Many-to-Many is handled correctly from CodeFirst now -- the join table does not need to be mapped explicitly
// (i.e. no UserPermission entity is needed)
dbContext.Users.Include(x => x.Permissions).ToList();
dbContext.Permissions.Include(x => x.UsersWithPermissions).ToList();