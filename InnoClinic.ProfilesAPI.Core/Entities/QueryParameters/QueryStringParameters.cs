using InnoClinic.ProfilesAPI.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ProfilesAPI.Core.Entities.QueryParameters
{
    public abstract class QueryStringParameters
    {
        const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        protected Type PropertyType { get; set; }

        public virtual Type GetEntityType()
        {
            return PropertyType;
        }
    }
}
