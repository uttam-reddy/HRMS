
using HRMS.Models;
using HRMS.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ResponseModel<IEnumerable<UsersDto>>> GetUsers(string connectionstring);

        Task<ResponseModel<UsersDto>> GetUserById(int id, string connectionstring);

       
    }
}
