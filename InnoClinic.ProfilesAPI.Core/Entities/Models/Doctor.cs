using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnoClinic.ProfilesAPI.Core.Entities.Models
{
    public class Doctor
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
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Guid SpecializationId { get; set; }
        [Required]
        public Guid OfficeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime CareerStartYear { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
