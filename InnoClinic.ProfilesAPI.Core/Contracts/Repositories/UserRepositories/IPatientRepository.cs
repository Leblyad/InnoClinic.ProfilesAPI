using InnoClinic.ProfilesAPI.Core.Entities.Models;

namespace InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync(bool trackChanges = false);
        Task<Patient> GetPatientAsync(Guid patientId, bool trackChanges = false);
        Task CreatePatientAsync(Patient patient);
        Task DeletePatientAsync(Patient patient);
    }
}
