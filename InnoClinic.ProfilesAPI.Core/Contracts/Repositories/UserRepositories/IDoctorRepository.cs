using InnoClinic.ProfilesAPI.Core.Entities.Models;

namespace InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync(bool trackChanges = false);
        Task<Doctor> GetDoctorAsync(Guid doctorId, bool trackChanges = false);
        Task CreateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(Doctor doctor);
    }
}
