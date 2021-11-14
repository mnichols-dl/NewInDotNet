namespace NIDN.EntityFrameworkCore.Helpers;

public static class ModelConfigurationBuilderExtensions
{
    public static void AddDateOnlySupport(this ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");

        builder.Properties<DateOnly?>()
            .HaveConversion<NullableDateOnlyConverter>()
            .HaveColumnType("date");
    }
}