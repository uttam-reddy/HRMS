using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.ViewModels
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
      
        public int RoleId { get; set; }

        public int Salary { get; set; }

        public string RoleName { get; set; }


        public DateTime? DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsDeleted { get; set; }

        public bool? Status { get; set; }

        //public virtual Role roles { get; set; }

    }
}
