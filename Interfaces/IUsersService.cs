using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace netapi.Interfaces
{
    public interface IUsersService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}