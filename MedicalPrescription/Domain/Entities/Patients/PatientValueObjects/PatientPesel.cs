namespace Domain.Entities.PatientValueObjects;

public record PatientPesel
{
    private string _pesel { get; set; }

    public string Pesel
    {
        get => _pesel;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || value.Length < 8)
            {
                throw new ArgumentException("Pesel cannot be empty or white space.", nameof(value));
            }
            _pesel = value;
        }
    }

    public PatientPesel(string pesel)
    {
        Pesel = pesel;
    }

    public static implicit operator string(PatientPesel pesel) => pesel.Pesel;
    public static implicit operator PatientPesel(string pesel)=> new PatientPesel(pesel);
    
    public override string ToString()
    {
        return $"Patient Pesel: {Pesel}";
    }
};