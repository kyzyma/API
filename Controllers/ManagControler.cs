using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netapi.Services;
using Microsoft.AspNetCore.Mvc;
using netapi;
using netapi.Interfaces;

namespace netapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagController : ControllerBase
    {
        private IUsersService usersService;

        public ManagController(IUsersService service){
            usersService = service;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await usersService.GetUsers());
           // return Ok(await Startup.parking.AddCarOnParking()) ;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return Ok(await usersService.GetUser(id));
        }

        [HttpPost]
        public void Post()
        {            
            Startup.parking.AddCarOnParking() ;
        }
    }
}