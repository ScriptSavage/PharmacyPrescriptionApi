using Domain.Dto;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<List<PatientDto>> GetPatientsAsync();
}