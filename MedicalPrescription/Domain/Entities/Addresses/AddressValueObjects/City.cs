namespace Domain.Entities.Addresses.AddressValueObjects;

public class City
{
    private string _cityName{ get; set; }

    public string CityName
    {
        get => _cityName;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 1)
            {
                throw new ArgumentException($"The value '{value}' cannot be empty or whitespace.");
            }
            _cityName = value;
        }
    }

    public City(string cityName)
    {
        CityName = cityName;
    }
    
    public static implicit operator string(City city) => city.CityName;
    public static implicit operator City(string cityName) => new City(cityName);

    override public string ToString() => $"City Name: {CityName}";
}