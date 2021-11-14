namespace NIDN.PatternMatching;

public class Gadget
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly? ReleaseDate { get; set; }

    public Gadget(string name, DateOnly? releaseDate) : this(Guid.NewGuid(), name, releaseDate)
    {
    }

    public Gadget(Guid id, string name, DateOnly? releaseDate)
    {
        Id = id;
        Name = name;
        ReleaseDate = releaseDate;
    }
}

public class BatteryPoweredGadget : Gadget
{
    public BatteryRequirements BatteryRequirements { get; set; }

    public BatteryPoweredGadget(string name, DateOnly? releaseDate, BatteryRequirements batteryRequirements) : base(name, releaseDate)
    {
        BatteryRequirements = batteryRequirements;
    }

    public BatteryPoweredGadget(Guid id, string name, DateOnly? releaseDate, BatteryRequirements batteryRequirements) : base(id, name, releaseDate)
    {
        BatteryRequirements = batteryRequirements;
    }
}

public class BatteryRequirements
{
    public BatterySize BatterySize { get; set; }
    public int Count { get; set; }

    public BatteryRequirements(BatterySize batterySize, int count)
    {
        BatterySize = batterySize;
        Count = count;
    }
}

public enum BatterySize
{
    Unknown = 0,
    A,
    AA,
    AAA,
    C,
    D,
    NineVolt,
    Coin
}