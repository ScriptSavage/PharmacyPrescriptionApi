namespace Domain.Entities.PatientValueObjects;

public class PatientLastName
{
    private string _lastName;

    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || value.Length < 2)
            {
                throw new ArgumentException("Invalid last name");
            }
            _lastName = value;
        }
    }

    public PatientLastName(string lastName)
    {
        LastName = lastName;
    }
    
    public static implicit operator string(PatientLastName patientLastName) => patientLastName.LastName;
    public static implicit operator PatientLastName(string lastName) => new PatientLastName(lastName);

    public override string ToString()
    {
        return $"Patient Last Name {LastName}";
    }
}