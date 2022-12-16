using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ProfilesAPI.Application.DataTransferObjects.Receptionist
{
    public class ReceptionistForCreationDto
    {
        public Guid PhotoId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Guid OfficeId { get; set; }
    }
}
