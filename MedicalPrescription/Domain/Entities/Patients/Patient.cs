using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.PatientValueObjects;

namespace Domain.Entities.Patients;

[Table("Patients")]
public class Patient
{
    public PatientId PatientId { get; private set; }
    public PatientFirstName FirstName { get; private set; }
    public PatientLastName LastName { get; private set; }
    public PatientPesel Pesel { get; private set; }
    public PatientPhoneNumber PhoneNumber { get; private set; }
    public PatientEmailAddress EmailAddress { get; private set; }
    
    public Patient(PatientId patientId, PatientFirstName firstName, PatientLastName lastName, PatientPesel pesel, 
        PatientPhoneNumber phoneNumber, PatientEmailAddress emailAddress)
    {
        PatientId = patientId;
        FirstName = firstName;
        LastName = lastName;
        Pesel = pesel;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;
    }

    public Patient()
    {
    }

    public void ChangeEmailAddress(string newEmailAddress)
    {
        if (string.IsNullOrWhiteSpace(newEmailAddress) || newEmailAddress.Length < 3 ||
            string.IsNullOrWhiteSpace(newEmailAddress))
        {
            throw new ArgumentException("Email address not correct", nameof(newEmailAddress));
        }

        EmailAddress = newEmailAddress;
    }


}


