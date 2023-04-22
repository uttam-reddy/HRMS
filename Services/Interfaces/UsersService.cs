using AutoMapper;
using HRMS.Models;
using HRMS.Services.Interfaces.Logging;
using HRMS.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Services.Interfaces
{
    public class UsersService : IUsersService
    {
        private readonly HRMSDbContext _context;
        private readonly IMapper mapper;
        private readonly ILog Ilog;
        public UsersService(HRMSDbContext context,IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
            Ilog = Logger.GetInstance();
        }
        public async Task<ResponseModel<IEnumerable<UsersDto>>> GetUsers() 
        {
            ResponseModel<IEnumerable<UsersDto>> response = new ResponseModel<IEnumerable<UsersDto>>();

            try
            {
                var users = await _context.Users.Include(x => x.roles).ToListAsync();

                response.Entity = this.mapper.Map<List<UsersDto>>(users);
                response.Status = true;
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.ReturnMessage.Add(ex.Message);
                Ilog.LogError(ex.Message);
            }
            
            return response;
        }
        public async Task<ResponseModel<UsersDto>> GetUserById(int id)
        {
            ResponseModel<UsersDto> response = new ResponseModel<UsersDto>();

            try
            {
                var users = await _context.Users.Include(i => i.roles).FirstOrDefaultAsync(x => x.Id == id);

                response.Entity = this.mapper.Map<UsersDto>(users);
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.ReturnMessage.Add(ex.Message);
                Ilog.LogError(ex.Message);
            }

            return response;
        }

        //public async Task<ResponseModel<EmployeeDto>> CreateEmployees(EmployeeDto employeeDto)
        //{
        //    ResponseModel<EmployeeDto> response = new ResponseModel<EmployeeDto>();

        //    try
        //    {
        //        var employee = new Employee
        //        {
        //            Address = employeeDto.Address,
        //            Name=employeeDto.Name,
        //            DeptId =employeeDto.DepartmentId,
        //            Salary =employeeDto.Salary,
        //            Status=true,
        //            IsDeleted=false,
        //            DateCreated=DateTime.Now,
        //            DateUpdated=DateTime.Now,
        //            DateDeleted=null
                    
                    

        //        };
        //        _context.Employees.Add(employee);
        //        await _context.SaveChangesAsync();

        //        response.Entity = this.mapper.Map<EmployeeDto>(employee);
        //        response.Status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.ReturnMessage.Add(ex.Message);
        //        Ilog.LogError(ex.Message);
        //    }

        //    return response;
        //}

        //public async Task<ResponseModel<EmployeeDto>> UpdateEmployees(int id, EmployeeDto employeeDto)
        //{
        //    ResponseModel<EmployeeDto> response = new ResponseModel<EmployeeDto>();

        //    try
        //    {
        //        var employee = await _context.Employees.FindAsync(id);
        //        if (employee == null)
        //        {
        //            response.Status = false;
        //            response.ReturnMessage.Add("Employee not found.");
        //            return response;
        //        }
        //        else
        //        {
        //            if(id != employee.Id)
        //            {
        //                response.Status = false;
        //                return response;
        //            }
        //            employee.Name = employeeDto.Name;
        //            employee.Salary = employeeDto.Salary;
        //            employee.Address = employeeDto.Address;
        //            _context.Entry(employee).State = EntityState.Modified;
        //            await _context.SaveChangesAsync();
        //            var employeeupdate = await _context.Employees.FindAsync(id);
        //            response.Entity = this.mapper.Map<EmployeeDto>(employeeupdate);
        //            response.Status = true;
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.ReturnMessage.Add(ex.Message);
        //        Ilog.LogError(ex.Message);
        //    }

        //    return response;
        //}

        //public async Task<ResponseModel<EmployeeDto>> DeleteEmployee(int id)
        //{
        //    ResponseModel<EmployeeDto> response = new ResponseModel<EmployeeDto>();

        //    try
        //    {
        //        var employee = await _context.Employees.FindAsync(id);
        //        if (employee == null)
        //        {
        //            response.Status = false;
        //            response.ReturnMessage.Add("Employee not found.");
        //            return response;
        //        }
        //        else
        //        {
        //            if (id != employee.Id)
        //            {
        //                response.Status = false;
        //                return response;
        //            }
                    
        //            employee.Status = false;
        //            employee.IsDeleted = true;
        //            _context.Entry(employee).State = EntityState.Modified;
        //            await _context.SaveChangesAsync();
        //            var employeeupdate = await _context.Employees.FindAsync(id);
        //            response.Entity = this.mapper.Map<EmployeeDto>(employeeupdate);
        //            response.Status = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.ReturnMessage.Add(ex.Message);
        //        Ilog.LogError(ex.Message);
        //    }

        //    return response;
        //}


    }
}
