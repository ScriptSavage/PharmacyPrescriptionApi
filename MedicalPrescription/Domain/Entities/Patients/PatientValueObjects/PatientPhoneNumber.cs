namespace Domain.Entities.PatientValueObjects;

public class PatientPhoneNumber
{
    private string _phoneNumber { get; set; }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 4)
            {
                throw new ArgumentException("Invalid phone number");
            }
            _phoneNumber = value;
        }
    }

    public PatientPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public static implicit operator string(PatientPhoneNumber phoneNumber) => phoneNumber.PhoneNumber;
    public static implicit operator PatientPhoneNumber(string phoneNumber) => new PatientPhoneNumber(phoneNumber);

    public override string ToString()
    {
        return $"Patient Phone Number {PhoneNumber}";
    }
}