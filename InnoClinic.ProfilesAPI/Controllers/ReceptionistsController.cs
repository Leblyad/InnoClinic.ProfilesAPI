using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Receptionist;
using InnoClinic.ProfilesAPI.Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.ProfilesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ReceptionistsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetReceptionists()
        {
            var receptionistsCollection = await _serviceManager.Receptionist.GetAllReceptionistsAsync();

            return Ok(receptionistsCollection);
        }

        [HttpGet("{receptionistId:guid}")]
        public async Task<IActionResult> GetReceptionistById(Guid receptionistId)
        {
            var receptionistDto = await _serviceManager.Receptionist.GetReceptionistAsync(receptionistId);

            return Ok(receptionistDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceptionist([FromBody] ReceptionistForCreationDto receptionist)
        {
            var receptionistDto = await _serviceManager.Receptionist.CreateReceptionistAsync(receptionist);

            return CreatedAtAction(nameof(GetReceptionistById), new { receptionistId = receptionistDto.Id }, receptionistDto);
        }

        [HttpPut("{receptionistId:guid}")]
        public async Task<IActionResult> UpdateReceptionist(Guid receptionistId, [FromBody] ReceptionistForUpdateDto receptionist)
        {
            await _serviceManager.Receptionist.UpdateReceptionistAsync(receptionistId, receptionist);

            return NoContent();
        }

        [HttpDelete("{receptionistId:guid}")]
        public async Task<IActionResult> DeleteReceptionist(Guid receptionistId)
        {
            await _serviceManager.Receptionist.DeleteReceptionistAsync(receptionistId);

            return NoContent();
        }
    }
}
