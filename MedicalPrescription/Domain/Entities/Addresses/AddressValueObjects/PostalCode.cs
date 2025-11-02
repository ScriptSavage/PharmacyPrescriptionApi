namespace Domain.Entities.Addresses.AddressValueObjects;

public class PostalCode
{
    
    private string _postalCodeNameName;
    private string PostalCodeName
    {
        get => _postalCodeNameName;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 5)
            {
                throw new ArgumentException($"{nameof(PostalCodeName)} must contain at least 5 characters.");
            }
            _postalCodeNameName = value;
        }
    }

    public PostalCode(string postalCode)
    {
        PostalCodeName = postalCode;
    }

    public static implicit operator string(PostalCode postalCode) => postalCode.PostalCodeName;
    public static implicit operator PostalCode(string postalCode) => new PostalCode(postalCode);
    
    public override string ToString() => $"PostalCode[Value={PostalCodeName}]";
}