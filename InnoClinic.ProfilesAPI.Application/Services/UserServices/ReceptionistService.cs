using AutoMapper;
using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Doctor;
using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Receptionist;
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
    public class ReceptionistService : IReceptionistService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ReceptionistService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ReceptionistDto> CreateReceptionistAsync(ReceptionistForCreationDto receptionist)
        {
            if (receptionist == null)
            {
                throw new CustomNullReferenceException(typeof(ReceptionistForCreationDto));
            }

            var receptionistEntity = _mapper.Map<Receptionist>(receptionist);
            await _repositoryManager.Receptionists.CreateReceptionistAsync(receptionistEntity);

            return _mapper.Map<ReceptionistDto>(receptionistEntity);
        }

        public async Task DeleteReceptionistAsync(Guid receptionistId)
        {
            var receptionist = await _repositoryManager.Receptionists.GetReceptionistAsync(receptionistId);

            if (receptionist == null)
            {
                throw new ReceptionistNotFoundException(receptionistId);
            }

            await _repositoryManager.Receptionists.DeleteReceptionistAsync(receptionist);
        }

        public async Task<IEnumerable<ReceptionistDto>> GetAllReceptionistsAsync()
        {
            var receptionistsCollection = await _repositoryManager.Receptionists.GetAllReceptionistsAsync();

            return _mapper.Map<IEnumerable<ReceptionistDto>>(receptionistsCollection);
        }

        public async Task<ReceptionistDto> GetReceptionistAsync(Guid receptionistId)
        {
            var receptionist = await _repositoryManager.Receptionists.GetReceptionistAsync(receptionistId);

            if (receptionist == null)
            {
                throw new ReceptionistNotFoundException(receptionistId);
            }

            return _mapper.Map<ReceptionistDto>(receptionist);
        }

        public async Task UpdateReceptionistAsync(Guid receptionistId, ReceptionistForUpdateDto receptionist)
        {
            if (receptionist == null)
            {
                throw new CustomNullReferenceException(typeof(ReceptionistForUpdateDto));
            }

            var receptionistEntity = await _repositoryManager.Receptionists.GetReceptionistAsync(receptionistId, trackChanges: true);

            if (receptionistEntity == null)
            {
                throw new ReceptionistNotFoundException(receptionistId);
            }

            _mapper.Map(receptionist, receptionistEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
