using Application.Interfaces;
using Domain.Dto;
using Domain.Entities.Patients.PatientValueObjects;
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

    public async Task<PatientAddressDto> GetPatientAddressByIdAsync(PatientId id)
    {
        var data = await _patientRepository.GetPatientAddressById(id);

      var doesPatientExists =  await _patientRepository.DoesPatientExist(id);
      if (!doesPatientExists)
      {
          _logger.LogError($"Patient with id {id} does not exist");
          throw new Exception($"Patient was not found");
      }

      var newPatientAddressDto = new PatientAddressDto()
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            PhoneNumber = data.PhoneNumber,
            Pesel = data.Pesel,
            EmailAddress = data.EmailAddress,
            AddressDto = new AddressDto()
            {
                PostalCode = data.Address.PostalCode,
                City = data.Address.City,
                Street = data.Address.Street,
            }
        };

        return newPatientAddressDto;
        
    }
}