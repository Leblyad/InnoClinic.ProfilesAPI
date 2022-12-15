using AutoMapper;
using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Doctor;
using InnoClinic.ProfilesAPI.Application.Services.Abstractions.UserServices;
using InnoClinic.ProfilesAPI.Core.Contracts.Repositories;
using InnoClinic.ProfilesAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.ProfilesAPI.Core.Entities.Models;
using InnoClinic.ProfilesAPI.Core.Exceptions;
using InnoClinic.ProfilesAPI.Core.Exceptions.UserExceptions;

namespace InnoClinic.ProfilesAPI.Application.Services.UserServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DoctorService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<DoctorDto> CreateDoctorAsync(DoctorForCreationDto doctor)
        {
            if(doctor == null)
            {
                throw new CustomNullReferenceException(typeof(DoctorForCreationDto));
            }

            var doctorEntity = _mapper.Map<Doctor>(doctor);
            await _repositoryManager.Doctors.CreateDoctorAsync(doctorEntity);

            return _mapper.Map<DoctorDto>(doctorEntity);
        }

        public async Task DeleteDoctorAsync(Guid doctorId)
        {
            var doctor = await _repositoryManager.Doctors.GetDoctorAsync(doctorId);

            if(doctor == null)
            {
                throw new DoctorNotFoundException(doctorId);
            }

            await _repositoryManager.Doctors.DeleteDoctorAsync(doctor);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctorsCollection = await _repositoryManager.Doctors.GetAllDoctorsAsync();

            return _mapper.Map<IEnumerable<DoctorDto>>(doctorsCollection);
        }

        public async Task<DoctorDto> GetDoctorAsync(Guid doctorId)
        {
            var doctor = await _repositoryManager.Doctors.GetDoctorAsync(doctorId);

            if(doctor == null)
            {
                throw new DoctorNotFoundException(doctorId);
            }

            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task UpdateDoctorAsync(Guid doctorId, DoctorForUpdateDto doctor)
        {
            if(doctor == null)
            {
                throw new CustomNullReferenceException(typeof(DoctorForUpdateDto));
            }

            var doctorEntity = await _repositoryManager.Doctors.GetDoctorAsync(doctorId, trackChanges: true);

            if(doctorEntity == null)
            {
                throw new DoctorNotFoundException(doctorId);
            }

            _mapper.Map(doctor, doctorEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
