using Domain.Entities.Patients;

namespace Domain.Interfaces;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllPatients();
    Task<Patient> GetPatientAddressById(Guid patientId);
    
    Task<bool> DoesPatientExist(Guid patientId);
}