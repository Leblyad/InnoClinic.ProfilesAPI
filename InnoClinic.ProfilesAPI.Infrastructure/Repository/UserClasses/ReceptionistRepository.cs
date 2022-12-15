using InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.ProfilesAPI.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.ProfilesAPI.Infrastructure.Repository.UserClasses
{
    public class ReceptionistRepository : RepositoryBase<Receptionist>, IReceptionistRepository
    {
        public ReceptionistRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateReceptionistAsync(Receptionist receptionist)
        {
            Create(receptionist);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteReceptionistAsync(Receptionist receptionist)
        {
            Delete(receptionist);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Receptionist>> GetAllReceptionistsAsync(bool trackChanges = false) =>
            await FindAll(trackChanges)
                .OrderBy(receptionist => receptionist.LastName)
                .ToListAsync();

        public async Task<Receptionist> GetReceptionistAsync(Guid receptionistId, bool trackChanges = false) =>
            await FindByCondition(receptionist => receptionist.Id.Equals(receptionistId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
