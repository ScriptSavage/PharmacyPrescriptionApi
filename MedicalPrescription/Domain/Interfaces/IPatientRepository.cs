using Domain.Entities.Patients;

namespace Domain.Interfaces;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllPatients();
}