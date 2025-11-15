namespace Domain.Entities.PatientValueObjects;

public class PatientEmailAddress
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

    public PatientEmailAddress(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public static implicit operator string(PatientEmailAddress emailAddress) => emailAddress.EmailAddress;
    public static implicit operator PatientEmailAddress(string emailAddress)=> new PatientEmailAddress(emailAddress);
    
    public override string ToString() => $"Patient email address: {EmailAddress}";
    
    
};