using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        

        public DateTime? DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }

        public bool Status { get; set; }

        public virtual List<Employee> Employees { get; set; }

    }
}
