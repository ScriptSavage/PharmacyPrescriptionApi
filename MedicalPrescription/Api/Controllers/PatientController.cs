using Application.Interfaces;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    private readonly ILogger<PatientController> _logger;

    public PatientController(IPatientService patientService, ILogger<PatientController> logger)
    {
        _patientService = patientService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPatients([FromQuery] string searchPhrase)
    {
        _logger.LogInformation("Getting all patients from Controller");
       var patientsDto =  await _patientService.GetPatientsAsync(searchPhrase);
       return Ok(patientsDto);
    }

    [HttpGet("{id:int}/address")]
    public async Task<IActionResult> GetPatient(Guid id)
    {
       var data =  await _patientService.GetPatientAddressByIdAsync(id);
       _logger.LogInformation($"Getting patient Address with id {id} from Controller");
       return Ok(data);
    }

    
}