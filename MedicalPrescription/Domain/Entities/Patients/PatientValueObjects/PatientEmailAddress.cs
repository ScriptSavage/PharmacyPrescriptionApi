namespace Domain.Entities.PatientValueObjects;

public record PatientEmailAddress
{
    private string _emailAddress;

    public string EmailAddress
    {
        get => _emailAddress;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || !value.Contains("@"))
            {
                throw new ArgumentException("Email address not correct", nameof(value));
            }
        }
    }

    public PatientEmailAddress(string value)
    {
        EmailAddress = value;
    }
    
    public static implicit operator string(PatientEmailAddress emailAddress) => emailAddress.EmailAddress;
    public static implicit operator PatientEmailAddress(string value)=> new PatientEmailAddress(value);
    
    public override string ToString() => EmailAddress;
    
    
};