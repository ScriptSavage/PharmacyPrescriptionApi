namespace Domain.Entities.Addresses.AddressValueObjects;

public class PostalCode
{
    
    private string _postalCodeName;
    public string PostalCodeName
    {
        get => _postalCodeName;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 5)
            {
                throw new ArgumentException($"{nameof(PostalCodeName)} must contain at least 5 characters.");
            }
            _postalCodeName = value;
        }
    }

    public PostalCode(string postalCodeName) => PostalCodeName = postalCodeName;
    

    public static implicit operator string(PostalCode postalCode) => postalCode.PostalCodeName;
    public static implicit operator PostalCode(string postalCode) => new PostalCode(postalCode);
    
    public override string ToString() => $"PostalCode[Value={PostalCodeName}]";
}