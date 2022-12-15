namespace InnoClinic.ProfilesAPI.Application.DataTransferObjects.Receptionist
{
    public class ReceptionistDto
    {
        public Guid Id { get; set; }
        public Guid PhotoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public Guid OfficeId { get; set; }
    }
}
