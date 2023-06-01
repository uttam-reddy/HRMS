using HRMS.Models;
using HRMS.Services.Interfaces;
using HRMS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ResponseModel<IEnumerable<EmployeeDto>>>> Get()
        {
            ResponseModel<IEnumerable<EmployeeDto>> response = new ResponseModel<IEnumerable<EmployeeDto>>();
            try
            {
                response = await _employeeService.GetEmployees();
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


        [HttpGet("departments")]
        [Authorize]
        public async Task<ActionResult<ResponseModel<IEnumerable<DepartmentDto>>>> GetDepatrments()
        {
            ResponseModel<IEnumerable<DepartmentDto>> response = new ResponseModel<IEnumerable<DepartmentDto>>();
            try
            {
                response = await _employeeService.GetDepartments();
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

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ResponseModel<EmployeeDto>>> Get(int id)
        {
            //var employee = await _employeeService.GetEmployeeById(id);

            ResponseModel<EmployeeDto> response = new ResponseModel<EmployeeDto>();
            try
            {
                response = await _employeeService.GetEmployeeById(id);
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

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Post([FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ResponseModel<EmployeeDto> response = new ResponseModel<EmployeeDto>();
            try
            {
                response = await _employeeService.CreateEmployees(employeeDto);
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

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> Put(int id, [FromBody] EmployeeDto employeeDto)
        {
            ResponseModel<EmployeeDto> response = new ResponseModel<EmployeeDto>();
            try
            {
                response = await _employeeService.UpdateEmployees(id,employeeDto);
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

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDto>> Delete(int id)
        {
            ResponseModel<EmployeeDto> response = new ResponseModel<EmployeeDto>();
            try
            {
                response = await _employeeService.DeleteEmployee(id);
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
