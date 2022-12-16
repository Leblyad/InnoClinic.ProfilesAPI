using InnoClinic.ProfilesAPI.Core.Entities.Models;
using InnoClinic.ProfilesAPI.Core.Entities.QueryParameters.UserParameters;

namespace InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync(bool trackChanges = false);
        Task<Doctor> GetDoctorAsync(Guid doctorId, bool trackChanges = false);
        Task CreateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetDoctorsByParameters(DoctorParameters parameters);
    }
}
