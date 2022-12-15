using InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.ProfilesAPI.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.ProfilesAPI.Infrastructure.Repository.UserClasses
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
        }

        public async Task CreatePatientAsync(Patient patient)
        {
            Create(patient);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(Patient patient)
        {
            Delete(patient);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync(bool trackChanges = false) =>
            await FindAll(trackChanges)
                .OrderBy(patient => patient.LastName)
                .ToListAsync();

        public async Task<Patient> GetPatientAsync(Guid patientId, bool trackChanges = false) =>
            await FindByCondition(patient => patient.Id.Equals(patientId), trackChanges)
                .SingleOrDefaultAsync();
    }
}
