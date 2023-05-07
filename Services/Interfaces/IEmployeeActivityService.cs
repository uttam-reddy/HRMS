using HRMS.Models;
using HRMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Services.Interfaces
{
    public interface IEmployeeActivityService
    {
        Task<ResponseModel<IEnumerable<EmployeeActivityDto>>> GetEmployeeActivities();

        Task<ResponseModel<IEnumerable<EmployeeActivityDto>>> GetActivitiesByEmployeeId(int id);




    }
}
