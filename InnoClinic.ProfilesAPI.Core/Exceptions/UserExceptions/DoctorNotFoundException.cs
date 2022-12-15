using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ProfilesAPI.Core.Exceptions.UserExceptions
{
    public class DoctorNotFoundException : NotFoundException
    {
        public DoctorNotFoundException(Guid doctorId) 
            : base($"The doctor with the identifier {doctorId} was not found.")
        {
        }
    }
}
