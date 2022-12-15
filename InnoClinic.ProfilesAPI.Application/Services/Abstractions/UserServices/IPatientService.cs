using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Patient;
using InnoClinic.ProfilesAPI.Core.Entities.Models;

namespace InnoClinic.ProfilesAPI.Application.Services.Abstractions.UserServices
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> GetPatientAsync(Guid patientId);
        Task<PatientDto> CreatePatientAsync(PatientForCreationDto patient);
        Task UpdatePatientAsync(Guid patientId, PatientForUpdateDto patient);
        Task DeletePatientAsync(Guid patientId);
    }
}
