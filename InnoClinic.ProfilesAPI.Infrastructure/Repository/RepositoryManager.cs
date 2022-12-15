using InnoClinic.ProfilesAPI.Core.Contracts.Repositories;
using InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.ProfilesAPI.Infrastructure.Repository.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ProfilesAPI.Infrastructure.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IDoctorRepository _doctorRepository;
        private IPatientRepository _patientRepository;
        private IReceptionistRepository _receptionistRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IDoctorRepository Doctors
        {
            get
            {
                if (_doctorRepository == null)
                    _doctorRepository = new DoctorRepository(_repositoryContext);

                return _doctorRepository;
            }
        }

        public IPatientRepository Patients
        {
            get
            {
                if (_patientRepository == null)
                    _patientRepository = new PatientRepository(_repositoryContext);

                return _patientRepository;
            }
        }

        public IReceptionistRepository Receptionists
        {
            get
            {
                if (_receptionistRepository == null)
                    _receptionistRepository = new ReceptionistRepository(_repositoryContext);

                return _receptionistRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
