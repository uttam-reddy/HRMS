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
    public class EmployeeActivityService : IEmployeeActivityService
    {
        private readonly HRMSDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILog Ilog;
        public EmployeeActivityService(HRMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Ilog = Logger.GetInstance();
        }

        

        public async Task<ResponseModel<IEnumerable<EmployeeActivityDto>>> GetEmployeeActivities()
        {
            ResponseModel<IEnumerable<EmployeeActivityDto>> response = new ResponseModel<IEnumerable<EmployeeActivityDto>>();

            try
            {
                var employees = await (from ea in _context.EmployeeActivites
                                       join emp in _context.Employees on ea.EmployeeId equals emp.Id
                                       join act in _context.Activities on ea.ActivityId equals act.Id
                                       
                                       select new EmployeeActivityDto
                                       {
                                           ActivityId = ea.ActivityId,
                                           ActivityName = act.ActivityName,
                                           EmployeeId = emp.Id,
                                           EmployeeName = emp.Name,
                                           EmployeeActivityId = ea.Id
                                       }
                                 ).ToListAsync();


                response.Entity = (employees);
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


        public async Task<ResponseModel<IEnumerable<EmployeeActivityDto>>> GetActivitiesByEmployeeId(int id)
        {
            ResponseModel<IEnumerable<EmployeeActivityDto>> response = new ResponseModel<IEnumerable<EmployeeActivityDto>>();

            try
            {
                var employees = await (from ea in _context.EmployeeActivites
                                      join emp in _context.Employees on ea.EmployeeId equals emp.Id
                                      join act in _context.Activities on ea.ActivityId equals act.Id
                                      where emp.Id == id
                                      select new EmployeeActivityDto
                                      {
                                          ActivityId = ea.ActivityId,
                                          ActivityName = act.ActivityName,
                                          EmployeeId = emp.Id,
                                          EmployeeName = emp.Name,
                                          EmployeeActivityId = ea.Id
                                      }
                                 ).ToListAsync();


                response.Entity = (employees);
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
    }
}
