namespace NIDN.Linq;

public class GadgetModel
{
    public string Name { get; set; }
    public int Version { get; set; }

    public GadgetModel(string name, int version)
    {
        Name = name;
        Version = version;
    }
}
