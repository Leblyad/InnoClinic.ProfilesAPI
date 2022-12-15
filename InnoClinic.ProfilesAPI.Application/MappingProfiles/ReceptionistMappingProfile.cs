using AutoMapper;
using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Receptionist;
using InnoClinic.ProfilesAPI.Core.Entities.Models;

namespace InnoClinic.ProfilesAPI.Application.MappingProfiles
{
    public class ReceptionistMappingProfile : Profile
    {
        public ReceptionistMappingProfile()
        {
            CreateMap<Receptionist, ReceptionistDto>();

            CreateMap<ReceptionistForCreationDto, Receptionist>();

            CreateMap<ReceptionistForUpdateDto, Receptionist>().ReverseMap();
        }
    }
}
