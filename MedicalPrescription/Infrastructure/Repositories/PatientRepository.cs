using Domain.Entities.Patients;
using Domain.Interfaces;
using Infrastructure.Persistance;
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

    public Task<List<Patient>> GetAllPatients()
    {
        _logger.LogInformation("Getting all patients from database");
        throw new NotImplementedException();
    }
}