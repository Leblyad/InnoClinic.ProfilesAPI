using InnoClinic.ProfilesAPI.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ProfilesAPI.Core.Entities.QueryParameters.UserParameters
{
    public class DoctorParameters : QueryStringParameters
    {
        public override Type GetEntityType()
        {
            return typeof(Doctor);
        }
    }
}
