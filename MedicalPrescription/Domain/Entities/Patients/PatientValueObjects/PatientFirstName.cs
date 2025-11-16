namespace Domain.Entities.Patients.PatientValueObjects;

public class PatientFirstName
{
    private string _firstName;

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid first name");
            }
            _firstName = value;
        }
    }

    public PatientFirstName(string firstName)
    {
        FirstName = firstName;
    }
    
    public static implicit operator string(PatientFirstName patientFirstName) => patientFirstName.FirstName;
    public static implicit operator PatientFirstName(string firstName) => new PatientFirstName(firstName);

    public override string ToString()
    {
        return $"Patient first name: {FirstName}";
    }
}
    