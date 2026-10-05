namespace Part1_ProceduralToOOP;

public class Customer
{
 

    public int Id {get; }
    public string Name {get; }
    public string Email {get; }
    public string City {get; }
    public bool IsVip {get; } 


    public Customer(int id, string? name, string email, string city, bool isVip)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        ArgumentNullException.ThrowIfNullOrEmpty(name);
        ArgumentNullException.ThrowIfNullOrEmpty(city);
        ArgumentNullException.ThrowIfNullOrEmpty(email);

        Id = id;
        Name = name;
        Email = email;
        City = city;
        IsVip = isVip;
    }


}
