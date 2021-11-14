namespace NIDN.RecordTypes.Gadgets;

// This is a record class, introduced in C# 9. This more concise definition is called
// a positional record.
public record GadgetRecord(string Name, int Version);