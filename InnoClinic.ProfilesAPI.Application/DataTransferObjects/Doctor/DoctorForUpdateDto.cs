using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ProfilesAPI.Application.DataTransferObjects.Doctor
{
    public class DoctorForUpdateDto
    {
        public Guid PhotoId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Guid SpecializationId { get; set; }
        [Required]
        public Guid OfficeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CareerStartYear { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
