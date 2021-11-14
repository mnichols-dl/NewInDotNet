namespace NIDN.RecordTypes.Gadgets;

public class ImmutableGadgetClass
{
    // These `init-only setters` allow for making immutable properties without
    // needing a constructor. These can only be set at the time of initialization,
    // either with a constructor or an initializer.
    public string Name { get; init; }
    public int Version { get; init; }
}

// Static code to demonstrate "init-only setters"
public static class InitOnlySetter
{
    public static void MakeImmutableGadgetClass()
    {
        var igc = new ImmutableGadgetClass
        {
            Name = "Something",
            Version = 1
        };

        // Because the properties are init-only, the following line produces an error:
        //igc.Name = "Something else";
    }
}