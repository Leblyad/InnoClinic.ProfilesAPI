using InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.ProfilesAPI.Core.Entities.Models;
using InnoClinic.ProfilesAPI.Core.Entities.QueryParameters.UserParameters;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.ProfilesAPI.Infrastructure.Repository.UserClasses
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateDoctorAsync(Doctor doctor)
        {
            Create(doctor);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(Doctor doctor)
        {
            Delete(doctor);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync(bool trackChanges = false) =>
            await FindAll(trackChanges)
                .OrderBy(doctor => doctor.LastName)
                .ToListAsync();

        public async Task<Doctor> GetDoctorAsync(Guid doctorId, bool trackChanges = false) =>
            await FindByCondition(doctor => doctor.Id.Equals(doctorId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Doctor>> GetDoctorsByParameters(DoctorParameters parameters)
        {
            return await GetByParameters(parameters).ToListAsync();
        }
    }
}
