using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.ViewModels
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public string Address { get; set; }
       

        public int Salary { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; }

        public bool Status { get; set; }

        public string  DepartmentName { get; set; }

        public int DepartmentId { get; set; }


    }

    public class DepartmentDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        

        public DateTime DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; }

        public bool Status { get; set; }

      


    }

}
