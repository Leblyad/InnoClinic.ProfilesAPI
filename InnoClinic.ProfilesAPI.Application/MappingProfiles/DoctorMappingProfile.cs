using AutoMapper;
using InnoClinic.ProfilesAPI.Application.DataTransferObjects.Doctor;
using InnoClinic.ProfilesAPI.Core.Entities.Models;

namespace InnoClinic.ProfilesAPI.Application.MappingProfiles
{
    public class DoctorMappingProfile : Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<Doctor, DoctorDto>().ForMember(dest => dest.CareerStartYear, opt => opt.MapFrom(src => src.CareerStartYear.Date.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy")));

            CreateMap<DoctorForCreationDto, Doctor>();

            CreateMap<DoctorForUpdateDto, Doctor>().ReverseMap();
        }
    }
}
