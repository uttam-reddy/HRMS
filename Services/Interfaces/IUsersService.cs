using HRMS.Models;
using HRMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ResponseModel<IEnumerable<UsersDto>>> GetUsers();

        Task<ResponseModel<UsersDto>> GetUserById(int id);

       
    }
}
