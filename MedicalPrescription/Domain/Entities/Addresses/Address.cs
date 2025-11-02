using Domain.Entities.Addresses.AddressValueObjects;

namespace Domain.Entities.Addresses;

public class Address
{
    public AddressId AddressId { get; private set; }

    public City City { get; private set; }

    public Street Street { get; private set; }

    public PostalCode PostalCode { get; private set; }

    public Address(AddressId addressId, City city, Street street, PostalCode postalCode)
    {
        AddressId = addressId;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    public Address()
    {
        
    }

    public void ChangeStreet(Street newStreet)
    {
        Street = newStreet;
    }

    public override string ToString()
    {
        return $"Address[AddressId={AddressId}][City={City}][Street={Street} PostalCode={PostalCode}]";
    }
}