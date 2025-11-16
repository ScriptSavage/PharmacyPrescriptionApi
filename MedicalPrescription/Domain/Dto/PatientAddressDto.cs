namespace Domain.Dto;

public class PatientAddressDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Pesel { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }

    public AddressDto AddressDto { get; set; }
}


public class AddressDto
{
    public string City { get; set; }

    public string Street { get; set; }

    public string PostalCode { get; set; }
}