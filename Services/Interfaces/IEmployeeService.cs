using HRMS.Models;
using HRMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseModel<IEnumerable<EmployeeDto>>> GetEmployees();

        Task<ResponseModel<EmployeeDto>> GetEmployeeById(int id);

        Task<ResponseModel<EmployeeDto>> CreateEmployees(EmployeeDto employeeDto);

        Task<ResponseModel<EmployeeDto>> UpdateEmployees(int id,EmployeeDto employeeDto);

        Task<ResponseModel<EmployeeDto>> DeleteEmployee(int id);


    }
}
