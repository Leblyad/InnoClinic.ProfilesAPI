using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Doctor;
using InnoClinic.ProfilesAPI.Application.Services.Abstractions;
using InnoClinic.ProfilesAPI.Core.Entities.QueryParameters.UserParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.ProfilesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DoctorsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctorsCollection = await _serviceManager.Doctor.GetAllDoctorsAsync();

            return Ok(doctorsCollection);
        }

        [HttpGet("{doctorId:guid}")]
        public async Task<IActionResult> GetDoctorById(Guid doctorId)
        {
            var doctorDto = await _serviceManager.Doctor.GetDoctorAsync(doctorId);

            return Ok(doctorDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorForCreationDto doctor)
        {
            var doctorDto = await _serviceManager.Doctor.CreateDoctorAsync(doctor);

            return CreatedAtAction(nameof(GetDoctorById), new { doctorId = doctorDto.Id }, doctorDto);
        }

        [HttpPut("{doctorId:guid}")]
        public async Task<IActionResult> UpdateDoctor(Guid doctorId, [FromBody] DoctorForUpdateDto doctor)
        {
            await _serviceManager.Doctor.UpdateDoctorAsync(doctorId, doctor);

            return NoContent();
        }

        [HttpDelete("{doctorId:guid}")]
        public async Task<IActionResult> DeleteDoctor(Guid doctorId)
        {
            await _serviceManager.Doctor.DeleteDoctorAsync(doctorId);

            return NoContent();
        }
    }
}
