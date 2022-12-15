using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ProfilesAPI.Core.Exceptions.UserExceptions
{
    public class ReceptionistNotFoundException : NotFoundException
    {
        public ReceptionistNotFoundException(Guid receptionistId) 
            : base($"The receptionist with the identifier {receptionistId} was not found.")
        {
        }
    }
}
