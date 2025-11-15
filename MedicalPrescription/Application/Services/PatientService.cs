using Application.Interfaces;
using Domain.Dto;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly ILogger<PatientService> _logger;

    public PatientService(IPatientRepository patientRepository, ILogger<PatientService> logger)
    {
        _patientRepository = patientRepository;
        _logger = logger;
    }


    public async Task<List<PatientDto>> GetPatientsAsync()
    {
        var data = await _patientRepository.GetAllPatients();

      return  data.Select(e => new PatientDto()
        {
                FirstName = e.FirstName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                Pesel = e.Pesel,
                EmailAddress = e.EmailAddress
        }).ToList();
      
    }
}