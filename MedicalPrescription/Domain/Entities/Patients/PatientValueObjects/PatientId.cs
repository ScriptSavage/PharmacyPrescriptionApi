namespace Domain.Entities.PatientValueObjects;

public sealed record PatientId
{
    public Guid _value { get; set; }


    public Guid Value
    {
        get => _value;
        set
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException(nameof(value));
            }
            _value = value;
        }
    }

    public PatientId(Guid value)
    {
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

    public override string ToString() => $"PatientId {Value}";
}