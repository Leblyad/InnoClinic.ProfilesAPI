using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Doctor;
using InnoClinic.ProfilesAPI.Core.Entities.Models;

namespace InnoClinic.ProfilesAPI.Application.Services.Abstractions.UserServices
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto> GetDoctorAsync(Guid doctorId);
        Task<DoctorDto> CreateDoctorAsync(DoctorForCreationDto doctor);
        Task UpdateDoctorAsync(Guid doctorId, DoctorForUpdateDto doctor);
        Task DeleteDoctorAsync(Guid doctorId);
    }
}
