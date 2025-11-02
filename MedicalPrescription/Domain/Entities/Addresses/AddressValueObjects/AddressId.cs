namespace Domain.Entities.Addresses.AddressValueObjects;

public class AddressId
{
    private Guid _value;

    public AddressId(Guid value)
    {
        Value = value;
    }

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

    public static implicit operator Guid(AddressId addressId) => addressId.Value;
    public static implicit operator AddressId(Guid addressId) => new AddressId(addressId);

    public override string ToString()
    {
        return "AddressId[Value=" + Value + "]";
    }
}