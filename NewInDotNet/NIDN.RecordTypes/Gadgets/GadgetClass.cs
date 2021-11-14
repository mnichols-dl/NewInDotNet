namespace NIDN.RecordTypes.Gadgets;

// This is a similar class definition of the GadgetRecord.
public class GadgetClass
{
    public string Name { get; set; }
    public int Version { get; set; }

    public GadgetClass(string name, int version)
    {
        Name = name;
        Version = version;
    }
}
