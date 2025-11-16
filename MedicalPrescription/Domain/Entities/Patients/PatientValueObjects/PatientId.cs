namespace Domain.Entities.Patients.PatientValueObjects;

public sealed record PatientId
{
    private Guid _patientId { get; set; }


    public Guid PatientIdValue
    {
        get => _patientId;
        set
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException(nameof(value));
            }
            _patientId = value;
        }
    }

    public PatientId(Guid patientIdValue)
    {
        PatientIdValue = patientIdValue;
    }
    
    public static implicit operator Guid(PatientId id) => id.PatientIdValue;

    public static implicit operator PatientId(Guid id) =>  new PatientId(id);

    public override string ToString() => $"PatientId {PatientIdValue}";
}