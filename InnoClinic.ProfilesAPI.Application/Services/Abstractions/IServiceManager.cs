using InnoClinic.ProfilesAPI.Application.Services.Abstractions.UserServices;

namespace InnoClinic.ProfilesAPI.Application.Services.Abstractions
{
    public interface IServiceManager
    {
        IDoctorService Doctor { get; }
        IPatientService Patient { get; }
        IReceptionistService Receptionist { get; }
    }
}
