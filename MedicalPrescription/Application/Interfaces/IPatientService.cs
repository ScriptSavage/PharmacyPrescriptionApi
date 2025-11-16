using Domain.Dto;
using Domain.Entities.Patients.PatientValueObjects;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<List<PatientDto>> GetPatientsAsync(string searchOption);
    
    Task<PatientAddressDto> GetPatientAddressByIdAsync(PatientId id);
    
    Task<int> AddNewPatientAsync(PatientAddressDto patientAddressDto);
}