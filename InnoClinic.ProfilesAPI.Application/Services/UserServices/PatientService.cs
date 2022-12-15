using AutoMapper;
using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Doctor;
using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Patient;
using InnoClinic.ProfilesAPI.Application.Services.Abstractions.UserServices;
using InnoClinic.ProfilesAPI.Core.Contracts.Repositories;
using InnoClinic.ProfilesAPI.Core.Entities.Models;
using InnoClinic.ProfilesAPI.Core.Exceptions;
using InnoClinic.ProfilesAPI.Core.Exceptions.UserExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ProfilesAPI.Application.Services.UserServices
{
    public class PatientService : IPatientService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PatientService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<PatientDto> CreatePatientAsync(PatientForCreationDto patient)
        {
            if (patient == null)
            {
                throw new CustomNullReferenceException(typeof(PatientForCreationDto));
            }

            var patientEntity = _mapper.Map<Patient>(patient);
            await _repositoryManager.Patients.CreatePatientAsync(patientEntity);

            return _mapper.Map<PatientDto>(patientEntity);
        }

        public async Task DeletePatientAsync(Guid patientId)
        {
            var patient = await _repositoryManager.Patients.GetPatientAsync(patientId);

            if (patient == null)
            {
                throw new PatientNotFoundException(patientId);
            }

            await _repositoryManager.Patients.DeletePatientAsync(patient);
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patientsCollection = await _repositoryManager.Patients.GetAllPatientsAsync();

            return _mapper.Map<IEnumerable<PatientDto>>(patientsCollection);
        }

        public async Task<PatientDto> GetPatientAsync(Guid patientId)
        {
            var patient = await _repositoryManager.Patients.GetPatientAsync(patientId);

            if (patient == null)
            {
                throw new PatientNotFoundException(patientId);
            }

            return _mapper.Map<PatientDto>(patient);
        }

        public async Task UpdatePatientAsync(Guid patientId, PatientForUpdateDto patient)
        {
            if (patient == null)
            {
                throw new CustomNullReferenceException(typeof(PatientForUpdateDto));
            }

            var patientEntity = await _repositoryManager.Patients.GetPatientAsync(patientId, trackChanges: true);

            if (patientEntity == null)
            {
                throw new PatientNotFoundException(patientId);
            }

            _mapper.Map(patient, patientEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
