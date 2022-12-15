using InnoClinic.ProfilesAPI.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InnoClinic.ProfilesAPI.Infrastructure.Repository
{
    public class RepositoryContext : DbContext
    {
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Receptionist> Receptionists { get; set; }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public RepositoryContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
