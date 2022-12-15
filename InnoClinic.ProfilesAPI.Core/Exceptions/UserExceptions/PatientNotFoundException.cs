using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ProfilesAPI.Core.Exceptions.UserExceptions
{
    public class PatientNotFoundException : NotFoundException
    {
        public PatientNotFoundException(Guid patientId) 
            : base($"The patient with the identifier {patientId} was not found.")
        {
        }
    }
}
