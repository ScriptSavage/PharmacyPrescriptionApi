using Domain.Dto;
using Domain.Entities.Patients.PatientValueObjects;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<List<PatientDto>> GetPatientsAsync();
    
    Task<PatientAddressDto> GetPatientAddressByIdAsync(PatientId id);
}