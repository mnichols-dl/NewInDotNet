using NIDN.PatternMatching;
using NIDN.PatternMatching.Helpers;

var gadgetList = new List<Gadget>
{
    new Gadget("Cool Compass", new DateOnly(2021, 12, 7)),
    new BatteryPoweredGadget("Rad Radio", new DateOnly(2021, 12, 5), new BatteryRequirements(BatterySize.AA, 4)),
    new BatteryPoweredGadget("Sufficient Smoke Alarm", new DateOnly(2021, 11, 25), new BatteryRequirements(BatterySize.NineVolt, 1)),
    new BatteryPoweredGadget("Somewhat Safe Smoke Alarm", new DateOnly(2021, 3, 1), new BatteryRequirements(BatterySize.NineVolt, 0))
};

// Not using true current date for demonstrative purposes
var today = new DateOnly(2021, 12, 8);

foreach (var gadget in gadgetList)
{
    Console.WriteLine($"Gadget: {gadget.Name}");

    if (gadget is BatteryPoweredGadget batteryPoweredGadget)
    {
        Console.WriteLine($"Requires {batteryPoweredGadget.BatteryRequirements.Count} {batteryPoweredGadget.BatteryRequirements.BatterySize} batter{(batteryPoweredGadget.BatteryRequirements.Count == 1 ? "y": "ies")}");
    }

    // =================================== Relational Patterns ===================================== //
    // Pattern matching can now (C# 9) use relational patterns comparing the value to another
    // constant value with less than (<), less than or equal to (<=), greater than (>),  or greater than or equal to (>=)
    if (gadget.ReleaseDate is not null)
    {
        // Relational patterns (like < 0 and < 30) are new to C# 9
        var releaseDateText = today.Subtract(gadget.ReleaseDate.Value).Days switch
        {
            < 0 => "Unreleased",
            0 => $"Today", // Value patterns existed already
            1 => "Yesterday", // Like these without comparison operators
            < 7 => "Less than a week ago",
            < 30 => "Less than a month ago",
            < 365 => "Less than a year ago",
            _ => "Who knows?!" // The discard existed already as well
        };

        Console.WriteLine($"Released: {releaseDateText} ({gadget.ReleaseDate.Value})");
    }

    // ============================== Extended Property Patterns =================================== //
    // Property pattern matching existed previously, but now (C# 10) you can use the dot (.) operator to
    // use nested properties. The following is a pattern matching statement which is only true
    // if the gadget is of type BatteryPoweredGadget with a BatteryRequirements property having 
    // a BatterySize of NineVolt.
    if (gadget is BatteryPoweredGadget { BatteryRequirements.BatterySize: BatterySize.NineVolt })
    {
        Console.WriteLine("WARNING: Do not stick 9V battery to tongue.");
    }

    switch (gadget)
    {
        case BatteryPoweredGadget { BatteryRequirements.BatterySize: BatterySize.NineVolt }:
            Console.WriteLine("WARNING: You will get zapped.");
            break;
    }

    // Previously in C# 8, this could be done with the following:
    if (gadget is BatteryPoweredGadget { BatteryRequirements: { BatterySize: BatterySize.NineVolt } })
    {
        Console.WriteLine("Warning you again...");
    }

    // ================================= Pattern Boolean Logic ===================================== //
    // Patterns can now (C# 9) be combined using `and`, `or`, and `not`
    if (gadget is BatteryPoweredGadget { BatteryRequirements.Count: <= 0 } and { ReleaseDate.Year: > 2020 })
    {
        Console.WriteLine("This Gadget requires batteries but the count is an invalid number. All BatteryPoweredGadgets released after 2020 require at least one battery.");
    }

    // Separator
    Console.WriteLine(new string('=', Console.WindowWidth));
}