using InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories;

namespace InnoClinic.ProfilesAPI.Core.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }
        IReceptionistRepository Receptionists { get; }

        Task SaveAsync();
    }
}
