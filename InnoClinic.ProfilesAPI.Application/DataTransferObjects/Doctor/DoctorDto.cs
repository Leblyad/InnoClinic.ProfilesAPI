using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ProfilesAPI.Application.DataTransferObjects.Doctor
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public Guid PhotoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid OfficeId { get; set; }
        public string CareerStartYear { get; set; }
        public string Status { get; set; }
    }
}
