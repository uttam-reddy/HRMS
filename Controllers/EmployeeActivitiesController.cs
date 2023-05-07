using HRMS.Models;
using HRMS.Services.Interfaces;
using HRMS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeActivitiesController : Controller
    {
        private readonly IEmployeeActivityService employeeActivityService;

        public EmployeeActivitiesController(IEmployeeActivityService employeeActivityService)
        {
            this.employeeActivityService = employeeActivityService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<IEnumerable<EmployeeActivityDto>>>> Get()
        {
            ResponseModel<IEnumerable<EmployeeActivityDto>> response = new ResponseModel<IEnumerable<EmployeeActivityDto>>();
            try
            {
                response = await this.employeeActivityService.GetEmployeeActivities();
                if (!response.Status)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception)
            {
                response.Status = false;
                return BadRequest(response);
                throw;
            }



        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<IEnumerable<EmployeeActivityDto>>>> Get(int id)
        {
            ResponseModel<IEnumerable<EmployeeActivityDto>> response = new ResponseModel<IEnumerable<EmployeeActivityDto>>();
            try
            {
                response = await this.employeeActivityService.GetActivitiesByEmployeeId(id);
                if (!response.Status)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception)
            {
                response.Status = false;
                return BadRequest(response);
                throw;
            }



        }

    }
}
