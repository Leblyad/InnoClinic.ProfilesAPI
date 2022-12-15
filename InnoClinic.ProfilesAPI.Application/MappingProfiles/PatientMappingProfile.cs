using AutoMapper;
using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Patient;
using InnoClinic.ProfilesAPI.Core.Entities.Models;

namespace InnoClinic.ProfilesAPI.Application.MappingProfiles
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy")));

            CreateMap<PatientForCreationDto, Patient>();

            CreateMap<PatientForUpdateDto, Patient>().ReverseMap();
        }
    }
}
