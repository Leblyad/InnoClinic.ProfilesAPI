using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Patient;
using InnoClinic.ProfilesAPI.Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.ProfilesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PatientsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patientsCollection = await _serviceManager.Patient.GetAllPatientsAsync();

            return Ok(patientsCollection);
        }

        [HttpGet("{patientId:guid}")]
        public async Task<IActionResult> GetPatientById(Guid patientId)
        {
            var patientDto = await _serviceManager.Patient.GetPatientAsync(patientId);

            return Ok(patientDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientForCreationDto patient)
        {
            var patientDto = await _serviceManager.Patient.CreatePatientAsync(patient);

            return CreatedAtAction(nameof(GetPatientById), new { patientId = patientDto.Id }, patientDto);
        }

        [HttpPut("{patientId:guid}")]
        public async Task<IActionResult> UpdatePatient(Guid patientId, [FromBody] PatientForUpdateDto patient)
        {
            await _serviceManager.Patient.UpdatePatientAsync(patientId, patient);

            return NoContent();
        }

        [HttpDelete("{patientId:guid}")]
        public async Task<IActionResult> DeletePatient(Guid patientId)
        {
            await _serviceManager.Patient.DeletePatientAsync(patientId);

            return NoContent();
        }
    }
}
