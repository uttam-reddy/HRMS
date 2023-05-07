using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public class Activities
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        
        

        public DateTime? DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsDeleted { get; set; }

        public bool Status { get; set; }

        public List<EmployeeActivites> employeeActivites { get; set; }



    }
}
