namespace DotnetUpskilling.ADO.Net.Entity;

public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsActive { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(IsActive)}: {IsActive}";
    }
}