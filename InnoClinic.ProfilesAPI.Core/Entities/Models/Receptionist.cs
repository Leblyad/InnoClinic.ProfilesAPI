using System.ComponentModel.DataAnnotations;

namespace InnoClinic.ProfilesAPI.Core.Entities.Models
{
    public class Receptionist
    {
        [Required]
        public Guid Id { get; set; }
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
