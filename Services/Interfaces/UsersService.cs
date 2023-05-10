using AutoMapper;
using AutoMapper.Configuration;
using HRMS.Models;
using HRMS.Services.Interfaces.Logging;
using HRMS.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Services.Interfaces
{
    public class UsersService : IUsersService
    {
        private readonly HRMSDbContext _context;
        private readonly IMapper mapper;
        private readonly ILog Ilog;
        
        //private readonly Confi { get; set; }
        public UsersService(HRMSDbContext context,IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
            Ilog = Logger.GetInstance();
            
        }
        public async Task<ResponseModel<IEnumerable<UsersDto>>> GetUsers(string conn) 
        {
            ResponseModel<IEnumerable<UsersDto>> response = new ResponseModel<IEnumerable<UsersDto>>();

            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = conn;

                connection.Open();
                string procedureName = "[dbo].[GetUsers]";
                var result = new List<UsersDto>();
                using(SqlCommand sqlCommand = new SqlCommand(procedureName,connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using(SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = int.Parse(reader[0].ToString());
                            string Username = reader[1].ToString();
                            string Email = reader[2].ToString();
                            int roleid= int.Parse(reader[3].ToString());
                            DateTime datecreted = (DateTime)reader[4];
                            DateTime dateupdated = (DateTime)reader[5];
                            bool status = (bool)reader[6];
                            bool deleted = (bool)reader[7];
                            string rolename = reader[8].ToString();




                            UsersDto usersDto = new UsersDto()
                            {
                                Id = id,
                                UserName = Username,
                                Email = Email,
                                RoleId = roleid,
                                DateCreated = datecreted,
                                DateUpdated = dateupdated,
                                DateDeleted = null,
                                Status = status,
                                IsDeleted = deleted,
                                RoleName = rolename
                            };
                            result.Add(usersDto);

                        }
                    }
                }

                connection.Close();
                //var users = await _context.Users.Include(x => x.roles).ToListAsync();

                response.Entity = result;
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
        public async Task<ResponseModel<UsersDto>> GetUserById(int id,string conn)
        {
            ResponseModel<UsersDto> response = new ResponseModel<UsersDto>();

            try
            {
                //var users = await _context.Users.Include(i => i.roles).FirstOrDefaultAsync(x => x.Id == id);

                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = conn;

                connection.Open();
                string procedureName = "[dbo].[GetUsers]";
                var result = new UsersDto();
                using (SqlCommand sqlCommand = new SqlCommand(procedureName, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = id;
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ids = int.Parse(reader[0].ToString());
                            string Username = reader[1].ToString();
                            string Email = reader[2].ToString();
                            int roleid = int.Parse(reader[3].ToString());
                            DateTime datecreted = (DateTime)reader[4];
                            DateTime dateupdated = (DateTime)reader[5];
                            bool status = (bool)reader[6];
                            bool deleted = (bool)reader[7];
                            string rolename = reader[8].ToString();




                            UsersDto usersDto = new UsersDto()
                            {
                                Id = ids,
                                UserName = Username,
                                Email = Email,
                                RoleId = roleid,
                                DateCreated = datecreted,
                                DateUpdated = dateupdated,
                                DateDeleted = null,
                                Status = status,
                                IsDeleted = deleted,
                                RoleName = rolename
                            };
                            result=(usersDto);

                        }
                    }
                }

                connection.Close();


                response.Entity = result;
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
