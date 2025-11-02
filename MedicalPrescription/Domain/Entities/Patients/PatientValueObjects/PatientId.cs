namespace Domain.Entities.PatientValueObjects;

public sealed record PatientId
{
    public Guid Value { get; }

    private PatientId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("PatientId cannot be empty.", nameof(value));

        Value = value;
    }
    
    public static implicit operator Guid(PatientId id) => id.Value;

    public static implicit operator PatientId(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("PatientId cannot be empty.", nameof(id));
        }

        return new PatientId(id);
    }

    public override string ToString() => Value.ToString();
}