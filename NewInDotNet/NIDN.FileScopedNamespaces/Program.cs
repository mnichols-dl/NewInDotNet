using NIDN.FileScopedNamespaces.Models;

var fileScoped = new FileScopedModel(Guid.NewGuid(), "File-Scoped");
var indented = new IndentedModel(Guid.NewGuid(), "Indented");

Console.WriteLine($"File-Scoped: {fileScoped.GetType().Namespace}");
Console.WriteLine($"Indented: {indented.GetType().Namespace}");