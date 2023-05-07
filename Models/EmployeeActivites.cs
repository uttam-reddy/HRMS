using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public class EmployeeActivites
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int ActivityId { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsDeleted { get; set; }

        public bool Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual  Activities Activity { get; set; }
}
}
