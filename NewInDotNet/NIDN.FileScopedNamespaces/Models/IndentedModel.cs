namespace NIDN.FileScopedNamespaces.Models
{
    internal class IndentedModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IndentedModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
