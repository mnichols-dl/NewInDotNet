namespace NIDN.RecordTypes.Resumes;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Contact(int id, string name, string phoneNumber)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
    }
}