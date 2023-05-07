using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.ViewModels
{
    public class EmployeeActivityDto
    {
        public int EmployeeActivityId { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeId { get; set; }

        public string ActivityName { get; set; }

        public int ActivityId { get; set; }
    }
}
