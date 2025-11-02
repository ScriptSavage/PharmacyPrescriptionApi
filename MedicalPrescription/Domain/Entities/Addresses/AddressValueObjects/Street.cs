namespace Domain.Entities.Addresses.AddressValueObjects;

public class Street
{
    private string _streetName { get; set; }

    public string StreetName
    {
        get => _streetName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || value.Length < 2)
            {
                throw new ArgumentException("Street Name cannot be null or empty");
            }
            _streetName = value;
        }
    }

    public Street(string streetName)
    {
        StreetName = streetName;
    }
    
    public static implicit operator string(Street street) => street.StreetName;
    public static implicit operator Street(string streetName) => new Street(streetName);
    
    override public string ToString() => $"StreetName[Value={StreetName}]";
}