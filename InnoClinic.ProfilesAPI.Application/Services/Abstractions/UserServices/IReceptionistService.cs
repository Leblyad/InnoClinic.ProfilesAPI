using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Receptionist;
using InnoClinic.ProfilesAPI.Core.Entities.Models;

namespace InnoClinic.ProfilesAPI.Application.Services.Abstractions.UserServices
{
    public interface IReceptionistService
    {
        Task<IEnumerable<ReceptionistDto>> GetAllReceptionistsAsync();
        Task<ReceptionistDto> GetReceptionistAsync(Guid receptionistId);
        Task<ReceptionistDto> CreateReceptionistAsync(ReceptionistForCreationDto receptionist);
        Task UpdateReceptionistAsync(Guid receptionistId, ReceptionistForUpdateDto receptionist);
        Task DeleteReceptionistAsync(Guid receptionistId);
    }
}
