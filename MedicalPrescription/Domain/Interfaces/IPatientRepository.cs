using Domain.Entities.Addresses;
using Domain.Entities.Patients;

namespace Domain.Interfaces;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllPatients(string searchOption);
    Task<Patient> GetPatientAddressById(Guid patientId);
    
    Task<bool> DoesPatientExist(Guid patientId);
    
    Task<int> AddNewPatient(Patient patient , Address address);
}