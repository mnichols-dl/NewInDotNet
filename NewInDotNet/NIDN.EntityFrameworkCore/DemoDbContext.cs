using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NIDN.EntityFrameworkCore.Helpers;

namespace NIDN.EntityFrameworkCore;

public class DemoDbContext : DbContext
{
    // Using the readonly property is recommended when Nullable Reference Types are in use.
    // For more, see: https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types
    public DbSet<User> Users => Set<User>();
    public DbSet<TimeOffRequest> TimeOffRequests => Set<TimeOffRequest>();
    public DbSet<Permission> Permissions => Set<Permission>();

    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tables can be defined as Temporal Tables now (a SQL Server feature)
        // through the `IsTemporal()` fluent API on the `TableBuilder`. By default, this generates
        // `PeriodEnd` and `PeriodStart` datetime2 columns, a history table for this entity, and
        // enables system versioning on the table.
        modelBuilder
            .Entity<User>()
            .ToTable("Users", b => b.IsTemporal())
            .HasMany(u => u.TimeOffRequests)
            .WithOne(tor => tor.RequestingUser);

        modelBuilder
            .Entity<TimeOffRequest>()
            .ToTable("TimeOffRequests", b => b.IsTemporal());

        modelBuilder
            .Entity<Permission>()
            .ToTable("Permissions", b => b.IsTemporal());

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Support for DateOnly did not make it in to .NET 6, so this custom extension
        // method adds a couple of configurations to add support until it is official in
        // a future version of EF Core.
        configurationBuilder.AddDateOnlySupport();

        base.ConfigureConventions(configurationBuilder);
    }
}

[NotMapped]
public abstract class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.Empty;
}

public class User : BaseEntity
{
    public string UserName { get; set; }

    public virtual ICollection<TimeOffRequest> TimeOffRequests { get; } = new List<TimeOffRequest>();
    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public User(string userName)
    {
        UserName = userName;
    }
}

public class TimeOffRequest : BaseEntity
{
    public Guid RequestingUserId { get; set; }
    [ForeignKey(nameof(RequestingUserId))]
    public User RequestingUser { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public Guid? ReviewingUserId { get; set; }
    [ForeignKey(nameof(ReviewingUserId))]
    public User? ReviewingUser { get; set; }
    public bool? Approved { get; set; }

    public TimeOffRequest(DateOnly startDate, DateOnly endDate, bool? approved = null)
    {
        StartDate = startDate;
        EndDate = endDate;
        Approved = approved;
    }
}

public class Permission : BaseEntity
{
    public string PermissionName { get; set; }

    public virtual ICollection<User> UsersWithPermissions { get; set; } = new List<User>();
}