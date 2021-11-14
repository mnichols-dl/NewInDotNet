namespace NIDN.FileScopedNamespaces.Models;

internal class FileScopedModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public FileScopedModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
