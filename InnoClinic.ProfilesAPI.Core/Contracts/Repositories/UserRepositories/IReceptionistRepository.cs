using InnoClinic.ProfilesAPI.Core.Entities.Models;

namespace InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories
{
    public interface IReceptionistRepository
    {
        Task<IEnumerable<Receptionist>> GetAllReceptionistsAsync(bool trackChanges = false);
        Task<Receptionist> GetReceptionistAsync(Guid receptionistId, bool trackChanges = false);
        Task CreateReceptionistAsync(Receptionist receptionist);
        Task DeleteReceptionistAsync(Receptionist receptionist);
    }
}
