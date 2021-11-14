using System.Text.Json;
using NIDN.Linq;
using NIDN.Linq.Helpers;

// ====================================== MaxBy and MinBy ========================================== //

var maxItems = new List<GadgetModel>
{
    new ("Alpha", 3),
    new ("Bravo", 10),
    new ("Charlie", 1),
    new ("Delta", 4)
};

// New LINQ methods added in .NET 6 which selects an object with the max value of the key selector.
// (e.g. "Find the object with the max by the Version property")
var maxByResult = maxItems.MaxBy(x => x.Version);

// The return type is null
Console.WriteLine($"Name of max result using MaxBy(): {maxByResult?.Name}");

// Comparison with similar LINQ statement
var similarLinqMaxResult = maxItems.OrderByDescending(x => x.Version).First();
Console.WriteLine($"Name of max result using OrderByDescending() and First(): {similarLinqMaxResult.Name}");

// Similar approach for MinBy()
var minByResult = maxItems.MinBy(x => x.Version);
Console.WriteLine($"Name of min result using MinBy(): {minByResult?.Name}");

// ======================================= DistinctBy ============================================== //

var duplicatedItems = new List<GadgetModel>
{
    new ("Alpha", 3),
    new ("Alpha", 2),
    new ("Alpha", 1),
    new ("Bravo", 10)
};

var distinctByResult = duplicatedItems.DistinctBy(x => x.Name).ToList();
Console.WriteLine($"List of items after DistinctBy(): {JsonSerializer.Serialize(distinctByResult)}");

// ======================================= Defaults for ___OrDefault =============================== //

// There are new method overloads for the LINQ methods that return a default value to allow specifying
// what the default should be.

var emptyList = new List<GadgetModel>();

var firstOrDefaultGadget = emptyList.FirstOrDefault(new GadgetModel("Default Gadget", 1));
var firstOrDefaultAsSpecifiedGadget = duplicatedItems.FirstOrDefault(x => x.Version == 4, new GadgetModel("Default Gadget", 1));
var singleOrDefaultGadget = emptyList.SingleOrDefault(new GadgetModel("Default Gadget", 1));
var lastOrDefaultGadget = duplicatedItems.LastOrDefault(new GadgetModel("Default Gadget", 1));

// ======================================= TryGetNonEnumeratedCount ================================ //

// IEnumerable.TryGetNonEnumeratedCount() is a new (.NET 6) `Try` style API for getting a count of an enumerable without
// the performance hit of enumerating it if it isn't needed. This is a performance optimization primarily.
if (!duplicatedItems.TryGetNonEnumeratedCount(out var count))
{
    Console.WriteLine("Enumerating to get count");
    count = duplicatedItems.Count();
}
else
{
    Console.WriteLine("Got count without enumeration performance overhead");
}

// The Helpers folder contains an extension method to do the above using Count() as a fallback when
// NonEnumeratedCount not available
Console.WriteLine(duplicatedItems.CountWithoutEnumerationIfPossible());

// ========================================== Chunk ================================================ //

// The Chunk() method splits an enumerable up into groupings of a specific size. This can be a
// more semantic way to handle batch processing.

var listOfAllItems = Enumerable.Range(0, 95).ToList();

foreach (var chunk in listOfAllItems.Chunk(20))
{
    Console.WriteLine($"Processing items {JsonSerializer.Serialize(chunk)}");
}

// By comparison, using a for loop to accomplish the same
for (int i = 0; i < listOfAllItems.Count(); i += 20)
{
    var currentChunk = listOfAllItems.Skip(i).Take(20);
    Console.WriteLine($"Processing by for loop: {JsonSerializer.Serialize(currentChunk)}");
}