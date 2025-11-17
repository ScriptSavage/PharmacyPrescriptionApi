using Domain.Entities.Addresses;
using Domain.Entities.Patients;
using Domain.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ProjectContext _context;
    private readonly ILogger<PatientRepository> _logger;

    public PatientRepository(ProjectContext context, ILogger<PatientRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Patient>> GetAllPatients(string? searchOption)
    {
        _logger.LogInformation("Getting all patients from database");
        
        return await _context.Patients
            .Where(e=>searchOption == null || e.Address.City.CityName.ToLower().Contains(searchOption.ToLower()))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Patient> GetPatientAddressById(Guid patientId)
    {
        var patientAddress = await _context.Patients
            .AsNoTracking()
            .Include(e => e.Address)
            .FirstOrDefaultAsync(e=>e.PatientId.PatientIdValue ==  patientId);
        
        return patientAddress;
    }

    public async Task<bool> DoesPatientExist(Guid patientId)
    {
        
        var patientExists = await _context.Patients.AnyAsync(e => e.PatientId.PatientIdValue == patientId);

        if (!patientExists)
        {
            _logger.LogInformation("Patient with id {PatientId} does not exist", patientId);
            throw new NotFoundException("Patient does not exist");
        }

        return patientExists;
    }

    public async Task<int> AddNewPatient(Patient patient , Address address)
    {
         await _context.Patients.AddAsync(patient);
        patient.Address = address;
        _logger.LogInformation("Adding new Patient with Address");
        return await _context.SaveChangesAsync();
    }
}