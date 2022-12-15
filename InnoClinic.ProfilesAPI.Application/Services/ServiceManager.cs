using AutoMapper;
using InnoClinic.ProfilesAPI.Application.Services.Abstractions;
using InnoClinic.ProfilesAPI.Application.Services.Abstractions.UserServices;
using InnoClinic.ProfilesAPI.Application.Services.UserServices;
using InnoClinic.ProfilesAPI.Core.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ProfilesAPI.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDoctorService> _lazyDoctorService;
        private readonly Lazy<IReceptionistService> _lazyReceptionistService;
        private readonly Lazy<IPatientService> _lazyPatientService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyDoctorService = new Lazy<IDoctorService>(() => new DoctorService(repositoryManager, mapper));
            _lazyReceptionistService = new Lazy<IReceptionistService>(() => new ReceptionistService(repositoryManager, mapper));
            _lazyPatientService = new Lazy<IPatientService>(() => new PatientService(repositoryManager, mapper));
        }

        public IDoctorService Doctor => _lazyDoctorService.Value;

        public IReceptionistService Receptionist => _lazyReceptionistService.Value;

        public IPatientService Patient => _lazyPatientService.Value;
    }
}
