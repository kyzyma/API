using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netapi.Services;
using Microsoft.AspNetCore.Mvc;
using netapi;

namespace netapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            switch (id)
            {
                case 1:
                    return Ok(Setting.ShowListAllTransacForMinute());                       
                case 2:
                    return Ok(Setting.ReadFromoFileTransactions());
            }
            return new string [] {"List of Transactions is 1 or 2"};
        }

        [HttpPost("{time}")]
        public ActionResult Post(int time, Car car)
        {            
            Startup.parking.AddCarOnParking(car, time);
            return Ok(car);
        }

         // PUT api/values/
        [HttpPut("{amount}")]
        public ActionResult Put(double amount, [FromBody]Car car)
        {
            Startup.parking.RefillBalance(amount, car);
            return Ok(car);
        }

        // Delete api//values
        [HttpDelete]
        public ActionResult Delete([FromBody]Car car)
        {
            Startup.parking.RemoveCarFromParking(car);
            return Ok(car);
        }
    }
}