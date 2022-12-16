using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ProfilesAPI.Application.DataTransferObjects.Patient
{
    public class PatientForCreationDto
    {
        public Guid PhotoId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
