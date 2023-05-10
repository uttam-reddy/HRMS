using HRMS.Models;
using HRMS.Services.Interfaces;
using HRMS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IConfiguration _configuration;
        
        private readonly IUsersService _usersService;

        public UsersController(IConfiguration configuration,IUsersService usersService)
        {
            _configuration = configuration;
           
            _usersService = usersService;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<UsersDto>> GetUsers()
        {
            ResponseModel<IEnumerable<UsersDto>> response = new ResponseModel<IEnumerable<UsersDto>>();
            try
            {
                var connectionstring = _configuration.GetConnectionString("HRMSDBConnection");
                response = await _usersService.GetUsers(connectionstring);
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
        
        [Authorize(Roles = "User")]
        public async Task<ActionResult<UsersDto>> GetUserById(int id)
        {
            ResponseModel<UsersDto> response = new ResponseModel<UsersDto>();
            try
            {
                var connectionstring = _configuration.GetConnectionString("HRMSDBConnection");
                response = await _usersService.GetUserById(id,connectionstring);
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
