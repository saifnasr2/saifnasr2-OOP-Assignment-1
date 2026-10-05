namespace Part3_BuilderPattern;

public class AddressBuilder
{
    private string _street = string.Empty;
    private string _city = string.Empty;
    private string _state = string.Empty;
    private string _zipCode = string.Empty;
    private string _country = string.Empty;

    public AddressBuilder SetStreet(string street)
    {
        _street = street;
        return this;
    }

    public AddressBuilder SetCity(string city)
    {
        _city = city;
        return this;
    }

    public AddressBuilder SetState(string state)
    {
        _state = state;
        return this;
    }

    public AddressBuilder SetZipCode(string zipCode)
    {
        _zipCode = zipCode;
        return this;
    }

    public AddressBuilder SetCountry(string country)
    {
        _country = country;
        return this;
    }

    public Address Build()
    {
        return new Address(
            _street,
            _city,
            _state,
            _zipCode,
            _country);
    }
}