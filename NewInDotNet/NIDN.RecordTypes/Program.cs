using NIDN.RecordTypes.Gadgets;
using NIDN.RecordTypes.Resumes;

// ================================ Records come with friendly ToString() ========================== //

var inspectorGadget = new GadgetRecord("Inspector Gadget", 1);
Console.WriteLine(inspectorGadget);

// By comparison, classes only come with the Object.ToString() method out of the box,
// which only returns the name of the type
var inspectorGadgetClass = new GadgetClass("Inspector Gadget", 1);
Console.WriteLine(inspectorGadgetClass);

// ========================== Positional records come with deconstruct method ====================== //

var (doodadName, _) = inspectorGadget;
inspectorGadget.Deconstruct(out var dName, out var dVersion);

// ============================== Records come with value-based equality =========================== //

var firstGadget = new GadgetRecord("Inspector Gadget", 1);
var secondGadget = new GadgetRecord("Inspector Gadget", 1);

if (firstGadget == secondGadget)
{
    Console.WriteLine("The gadget records are the same.");
}
else
{
    Console.WriteLine("The gadget records are NOT the same.");
}

// By comparison, classes use reference-based equality unless the
// Equals method is overridden
var firstGadgetClass = new GadgetClass("Inspector Gadget", 1);
var secondGadgetClass = new GadgetClass("Inspector Gadget", 1);

if (firstGadgetClass == secondGadgetClass)
{
    Console.WriteLine("The gadget class objects are the same.");
}
else
{
    Console.WriteLine("The gadget class objects are NOT the same.");
}

// =============================== Records are immutable (by default) ============================== //

// By default, records produce properties with what is called an "init-only" setter. This
// means that the value can not be mutated directly.
var initialGadget = new GadgetRecord(Version: 1, Name: "Perfect Gadget");

// The following line produces an error:
//initialGadget.Version = 2;

// There is a non-destructive approach to mutations using the "with" expression. With expressions
// create a new instance of the object with its members copied and the specified propertied modified.
var revisedGadget = initialGadget with { Version = 2 };

Console.WriteLine($"The revised gadget is {revisedGadget}");

// It is possible to define a mutable record type, but it's generally discouraged.

// A similar effect can be achieved with init-only property setters (also new in C# 9)
var immutableGadget = new ImmutableGadgetClass
{
    Name = "Immutable",
    Version = 1
};

// The following line produces an error:
//immutableGadget.Name = "Mutable";

// ===================== Value-based equality still respects member type equality ================== //

// One important note to consider when using records for their value-based equality checks is that
// this member-by-member equality check still follows the rules for the type of the member. If
// a member is a reference type, that particular member will still be considered equal only if it is
// referencing the same object
var momContact = new Contact(1, "Mom", "123-456-7890");
var resume = new Resume("Michael", momContact);

Console.WriteLine("Mutating record with new instance of contact that has same values.");
var resumeWithNewContact = resume with { Reference = new Contact(1, "Mom", "123-456-7890") };

if (resume == resumeWithNewContact)
{
    Console.WriteLine("The resume records are the same.");
}
else
{
    Console.WriteLine("The resume records are NOT the same.");
}

// However, using the exact same reference would work.
Console.WriteLine("Mutating record with same instance of contact.");
var resumeWithSameContact = resume with { Reference = momContact };
if (resume == resumeWithSameContact)
{
    Console.WriteLine("The resume records are the same.");
}
else
{
    Console.WriteLine("The resume records are NOT the same.");
}

// By the same nature, these reference types on the record's members may be mutable as well.
resume.Reference.Name = "Dad";
// However, the reference itself is not mutable. The following line produces an error:
//resume.Reference = momContact;