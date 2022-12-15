using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ProfilesAPI.Core.Exceptions
{
    public class CustomNullReferenceException : NullReferenceException
    {
        public CustomNullReferenceException(Type type)
            : base($"Object of type: {type.Name} is null.")
        { }
    }
}
